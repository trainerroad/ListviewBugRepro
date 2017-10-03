using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewBugRepro
{
    public class ListItemModel
    {
        public int Value { get; private set; }

        protected ListItemModel(int value)
        {
            ReferenceTracking.Add(this);
            Value = value;
        }

        public static ListItemModel Create(int value)
        {
            if (value % 2 == 1)
            {
                return new OddListItemModel(value);
            }
            else
            {
                return new EvenListItemModel(value);
            }
        }
    }

    public class OddListItemModel : ListItemModel
    {
        public OddListItemModel(int value) : base(value)
        {
            Debug.Assert(value % 2 == 1);
        }
    }

    public class EvenListItemModel : ListItemModel
    {
        public EvenListItemModel(int value) : base(value)
        {
            Debug.Assert(value % 2 == 0);
        }
    }
}
