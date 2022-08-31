using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Android.Resources
{
    internal class ElementListAdapter : BaseAdapter<TableItem>, View.IOnClickListener
    {
        List<TableItem> items;
        Activity context;
        int Width;

        public ElementListAdapter(Activity context, List<TableItem> items, int Width) : base()
        {
            this.context = context;
            this.items = items;
            this.Width = Width;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override TableItem this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.element_list, null);

            LinearLayout Ll = view.FindViewById<LinearLayout>(Resource.Id.linear_layout);
            Ll.SetMinimumWidth(Width - Ll.Height - 100);
            Ll.ContentDescription = item.key + ":" + item.value;
            Ll.SetOnClickListener(this);

            view.FindViewById<TextView>(Resource.Id.key_text_view).Text = item.key.Replace("|.|", ":");

            view.FindViewById<TextView>(Resource.Id.value_text_view).Text = item.value.Replace("|.|", ":");

            ImageView Iv = view.FindViewById<ImageView>(Resource.Id.image_view_list);
            Iv.ContentDescription = "Supprimer " + item.key.Replace("|.|", ":");
            Iv.SetMinimumHeight(Ll.Height - 20);
            Iv.SetMaxHeight(Ll.Height - 20);
            Iv.SetMinimumWidth(Ll.Height - 20);
            Iv.SetMaxWidth(Ll.Height - 20);

            GridLayout Gl = view.FindViewById<GridLayout>(Resource.Id.delete_grid_layout);
            Gl.ContentDescription = item.key + ":" + item.value;
            Gl.SetMinimumWidth(Ll.Height);
            Gl.SetMinimumHeight(Ll.Height);
            Gl.SetOnClickListener(this);

            return view;
        }

        void View.IOnClickListener.OnClick(View v)
        {
            string key = v.ContentDescription.Split(":")[0];
            string value = v.ContentDescription.Split(":")[1];

            if (v.GetType() == typeof(GridLayout))
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                AlertDialog alert = dialog.Create();

                alert.SetTitle($"Supprimer '{key.Replace("|.|", ":")}' ?");
                alert.SetIcon(Resource.Drawable.ic_trash);

                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                View nv = inflater.Inflate(Resource.Layout.delete_element, null);

                nv.FindViewById<Button>(Resource.Id.yes_button).Click += (s, e) => {
                    MainActivity.Instance.RemoveElement(key, value);
                    alert.Cancel();
                };

                nv.FindViewById<Button>(Resource.Id.no_button).Click += (s, e) => {
                    alert.Cancel();
                };

                alert.SetView(nv);
                alert.Show();
            }

            if (v.GetType() == typeof(LinearLayout))
            {
                new ModifElement(context, key + ":" + value);
            }
        }
    }
}