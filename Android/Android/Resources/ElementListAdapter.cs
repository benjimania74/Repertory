using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Android.Resources{
    internal class ElementListAdapter : BaseAdapter<TableItem>{

        List<TableItem> items;
        Activity context;
        int Width;
        public ElementListAdapter(Activity context, List<TableItem> items, int Width) : base(){
            this.context = context;
            this.items = items;
            this.Width = Width;
        }
        public override long GetItemId(int position){
            return position;
        }
        public override TableItem this[int position]{
            get { return items[position]; }
        }
        public override int Count{
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent){
            var item = items[position];

            if (convertView == null) // no view to re-use, create new
                convertView = context.LayoutInflater.Inflate(Resource.Layout.element_list, null);

            LinearLayout Ll = convertView.FindViewById<LinearLayout>(Resource.Id.linear_layout);
            Ll.SetMinimumWidth(Width - 60);

            TextView KeyTextView = convertView.FindViewById<TextView>(Resource.Id.key_text_view);
            KeyTextView.Text = item.key;

            TextView ValueTextView = convertView.FindViewById<TextView>(Resource.Id.value_text_view);
            ValueTextView.Text = item.value;

            ImageView Iv = convertView.FindViewById<ImageView>(Resource.Id.image_view_list);
            Iv.ContentDescription = "Supprimer " + item.key;

            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle($"Supprimer '{item.key}' ?");
            alert.SetIcon(Resource.Drawable.ic_trash);

            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View nv = inflater.Inflate(Resource.Layout.delete_element, null);
            
            nv.FindViewById<Button>(Resource.Id.yes_button).Click += (s, e) => {
                // Supprimer de la liste
                alert.Cancel();
            };

            nv.FindViewById<Button>(Resource.Id.no_button).Click += (s, e) => {
                alert.Cancel();
            };

            Iv.Click += (s, e) => {
                alert.SetView(nv);
                alert.Show();
            };

            Ll.Click += (s, e) => {
                Toast.MakeText(context, item.key, ToastLength.Short).Show();
            };
            return convertView;
        }
    }
}