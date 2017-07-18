using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewBugRepro
{
    public class ReferenceTracking
    {
        private static List<WeakReference> _references;

        public static void Add(object @object)
        {
            _references.Add(new WeakReference(@object));
        }

        public static void Start()
        {
            if (_references != null)
                return;

            _references = new List<WeakReference>();

            Observable.Interval(TimeSpan.FromSeconds(2)).Subscribe(_ =>
            {
                GC.Collect();
                _references.RemoveAll(r => !r.IsAlive);
                try
                {
                    Debug.WriteLine($"Memory: Total {_references.Count}|" + string.Join("|", _references
                                        .GroupBy(r => r.Target.GetType().Name)
                                        .Select(g => new {Count = g.Count(), Name = g.Key})
                                        .Where(a => a.Count > 1)
                                        .OrderByDescending(a => a.Count).Select(a => $"{a.Count} {a.Name}s")));
                }
                catch
                {
                }
            });
        }
    }
}
