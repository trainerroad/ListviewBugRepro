using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;

namespace ListviewBugRepro
{
    public class InstrumentedGrid : Grid
    {
        private static Dictionary<string,int> _counts = new Dictionary<string, int>();

        static void IncrementCount(string name)
        {
            if (!_counts.ContainsKey(name))
            {
                _counts[name] = 0;
            }

            _counts[name]++;
        }

        static void DisplayCounts(string className)
        {
            Debug.WriteLine($"{className} counts: " +
                            string.Join(", ", _counts.Keys.Select(k => $"{k}: {_counts[k]}")));
        }

        static InstrumentedGrid()
        {
            Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), RxApp.MainThreadScheduler).Subscribe(
                _ =>
                {
                    DisplayCounts("InstrumentedGrid");
                });
        }

        public InstrumentedGrid()
        {
            IncrementCount("constructor");
        }

        protected override void OnBindingContextChanged()
        {
            IncrementCount(nameof(OnBindingContextChanged));
            base.OnBindingContextChanged();
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            IncrementCount(nameof(OnMeasure));
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            IncrementCount(nameof(LayoutChildren));
            base.LayoutChildren(x, y, width, height);
        }

        protected override void OnParentSet()
        {
            IncrementCount(nameof(OnParentSet));
            base.OnParentSet();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            IncrementCount(nameof(OnSizeAllocated));
            base.OnSizeAllocated(width, height);
        }

        protected override void InvalidateLayout()
        {
            IncrementCount(nameof(InvalidateLayout));
            base.InvalidateLayout();
        }

        protected override void InvalidateMeasure()
        {
            IncrementCount(nameof(InvalidateMeasure));
            base.InvalidateMeasure();
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            IncrementCount(nameof(OnSizeRequest));
            return base.OnSizeRequest(widthConstraint, heightConstraint);
        }
    }
}