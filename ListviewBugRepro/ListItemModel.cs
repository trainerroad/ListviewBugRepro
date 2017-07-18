using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewBugRepro
{
    public class ListItemModel
    {
        public int Value { get; private set; }

        public ListItemModel(int value)
        {
            ReferenceTracking.Add(this);
            Value = value;
        }
    }
}
