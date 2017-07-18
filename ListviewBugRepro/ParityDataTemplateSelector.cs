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
		    var model = item as ListItemModel;

            if (model == null)
				return null;

			if (model.Value % 2 == 0)
				return EvenTemplate;

            return OddTemplate;
		}
    }
}
