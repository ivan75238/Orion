using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using GlobalLib.Item;
using GlobalLib;
using Android.Graphics;

namespace Mobile
{
    public class TripsAdapter : BaseAdapter<Trip>
    {
        public List<Trip> DataList;
        Context context;

        public TripsAdapter(Context _context, List<Trip> _dataList)
        {
            DataList = _dataList;
            context = _context;
        }

        public override Trip this[int position]
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
            var row = LayoutInflater.From(context).Inflate(Resource.Layout.TripsAdapterLayout, null, false);
            TextView LabelCount = row.FindViewById<TextView>(Resource.Id.LabelCount);
            LabelCount.Text = "Свободно:" + DataList[position].coun_sv_mest.ToString();
            if (DataList[position].coun_sv_mest == 0)
                LabelCount.SetTextColor(Color.ParseColor("#d63423"));
            return row;
        }
    }
}