using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using GlobalLib;

namespace Mobile
{
    public class SpotsAdapter : BaseAdapter<int>
    {
        public List<int> DataList;
        Context context;

        public SpotsAdapter(Context _context, List<int> _dataList)
        {
            DataList = _dataList;
            context = _context;
        }

        public override int this[int position]
        {
            get { return DataList[position]; }
        }

        public override int Count
        {
            get { return DataList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = LayoutInflater.From(context).Inflate(Resource.Layout.SpotsAdapterLayout, null, false);
            TextView SpinnerItem = row.FindViewById<TextView>(Resource.Id.SpinnerItem);
            SpinnerItem.Text = DataList[position].ToString();
            return row;
        }
    }
}