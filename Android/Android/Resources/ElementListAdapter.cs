﻿using Android.App;
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
using static Android.Content.ClipData;

namespace Android.Resources{
    internal class ElementListAdapter : BaseAdapter<TableItem>, View.IOnClickListener{
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

            View view = convertView;

            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.element_list, null);

            LinearLayout Ll = view.FindViewById<LinearLayout>(Resource.Id.linear_layout);
            Ll.SetMinimumWidth(Width - 80);
            Ll.ContentDescription = item.key + ":" + item.value;
            Ll.SetOnClickListener(this);

            view.FindViewById<TextView>(Resource.Id.key_text_view).Text = item.key.Replace("|.|", ":");

            view.FindViewById<TextView>(Resource.Id.value_text_view).Text = item.value.Replace("|.|", ":");

            ImageView Iv = view.FindViewById<ImageView>(Resource.Id.image_view_list);
            Iv.ContentDescription = "Supprimer " + item.key.Replace("|.|", ":");

            GridLayout Gl = view.FindViewById<GridLayout>(Resource.Id.delete_grid_layout);
            Gl.ContentDescription = item.key + ":" + item.value;
            Gl.SetOnClickListener(this);

            return view;
        }

        void View.IOnClickListener.OnClick(View v) {
            string key = v.ContentDescription.Split(":")[0].Replace("|.|", ":");
            string value = v.ContentDescription.Split(":")[1].Replace("|.|", ":");

            if (v.GetType() == typeof(GridLayout))
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                AlertDialog alert = dialog.Create();

                alert.SetTitle($"Supprimer '{key}' ?");
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

                alert.SetView(nv);
                alert.Show();
            }

            if(v.GetType() == typeof(LinearLayout))
            {
                // Ouvrir Menu Element [modif]
            }
        }
    }
}