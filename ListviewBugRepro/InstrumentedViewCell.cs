using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Xamarin.Forms;

namespace ListviewBugRepro
{
    public class InstrumentedViewCell : ViewCell
    {
        private readonly static Dictionary<string, int> _counts = new Dictionary<string, int>();

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

        static InstrumentedViewCell()
        {
            Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), RxApp.MainThreadScheduler).Subscribe(
                _ =>
                {
                    DisplayCounts("InstrumentedViewCell");
                });
        }

        public InstrumentedViewCell()
        {
            IncrementCount("constructor");
        }

        protected override void OnBindingContextChanged()
        {
            IncrementCount(nameof(OnBindingContextChanged));
            base.OnBindingContextChanged();
        }

        protected override void OnAppearing()
        {
            IncrementCount(nameof(OnAppearing));
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            IncrementCount(nameof(OnDisappearing));
            base.OnDisappearing();
        }

        protected override void OnParentSet()
        {
            IncrementCount(nameof(OnParentSet));
            base.OnParentSet();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            IncrementCount(nameof(OnPropertyChanged) + " " + propertyName);
            base.OnPropertyChanged(propertyName);
        }
    }
}
