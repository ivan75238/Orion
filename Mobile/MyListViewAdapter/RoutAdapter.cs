using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using GlobalLib;
using Android.Graphics;

namespace Mobile
{
    public class RoutAdapter : BaseAdapter<Rout>
    {
        public List<Rout> DataList;
        Context context;

        public RoutAdapter(Context _context, List<Rout> _dataList)
        {
            DataList = _dataList;
            context = _context;
        }

        public override Rout this[int position]
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
            var row = LayoutInflater.From(context).Inflate(Resource.Layout.RoutAdapterLayout, null, false);
            TextView SpinnerItem = row.FindViewById<TextView>(Resource.Id.SpinnerItem);
            LinearLayout RowLayout = row.FindViewById<LinearLayout>(Resource.Id.RowLayout);
            if (position == 0)
            {
                RowLayout.SetBackgroundColor(Color.ParseColor("#d3d3d3"));
            }
            SpinnerItem.Text = DataList[position].name;
            return row;
        }
    }
}