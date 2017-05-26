using System;
using Xamarin.Forms;

namespace ListviewBugRepro
{
    public class ParityDataTemplateSelector : DataTemplateSelector
    {
		public DataTemplate EvenTemplate { get; set; }
		public DataTemplate OddTemplate { get; set; }

        public ParityDataTemplateSelector()
        {
            
        }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
            if (!(item is int))
				return null;
			if (((int)item) % 2 == 0)
				return EvenTemplate;

            return OddTemplate;
		}
    }
}
