using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_Yoga_UKK
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList() : base(new List<T>()) { }

        public SortableBindingList(IEnumerable<T> collection) : base(collection.ToList()) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override ListSortDirection SortDirectionCore => _sortDirection;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;
            _isSorted = true;

            var items = this.Items as List<T>;
            if (items == null) return;

            // Urutkan data
            if (direction == ListSortDirection.Ascending)
                items.Sort((x, y) => Compare(prop.GetValue(x), prop.GetValue(y)));
            else
                items.Sort((x, y) => Compare(prop.GetValue(y), prop.GetValue(x)));

            // Beri tahu DataGridView bahwa data telah diurutkan
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
        }

        private int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (x is IComparable xComparable)
                return xComparable.CompareTo(y);

            if (y is IComparable yComparable)
                return yComparable.CompareTo(x);

            return x.ToString().CompareTo(y.ToString());
        }
    }
}
