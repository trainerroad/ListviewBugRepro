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

		    if (model is EvenListItemModel)
		        return EvenTemplate;
            else if (model is OddListItemModel)
		        return OddTemplate;

            return null;
		}
    }
}
