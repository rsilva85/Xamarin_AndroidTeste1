
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Xamarin_AndroidTeste1
{
    public class TableAdapter : BaseAdapter<string[]>
    {
        List<string[]> items;
        Activity context;
        public TableAdapter(Activity context, List<string[]> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override string[] this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item[0];
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item[1];
            //view.FindViewById<ImageView>(Android.Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}