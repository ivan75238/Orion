using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using GlobalLib;

namespace Mobile
{
    public class TicketAdapter : BaseAdapter<TypeBilet>
    {
        public List<TypeBilet> DataList;
        Context context;

        public TicketAdapter(Context _context, List<TypeBilet> _dataList)
        {
            DataList = _dataList;
            context = _context;
        }

        public override TypeBilet this[int position]
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
            var row = LayoutInflater.From(context).Inflate(Resource.Layout.TicketAdapterLayout, null, false);
            TextView SpinnerItem = row.FindViewById<TextView>(Resource.Id.SpinnerItem);
            SpinnerItem.Text = DataList[position].name;
            return row;
        }
    }
}