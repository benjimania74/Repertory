using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.App.AlertDialog;

namespace Android.Resources
{
    internal class AddElement
    {
        public AddElement(Activity context)
        {
            ImageView Btn = context.FindViewById<ImageView>(Resource.Id.add_element_button);
            int s = context.FindViewById<EditText>(Resource.Id.search_bar).Height - 20;

            Btn.SetMinimumHeight(s);
            Btn.SetMinimumWidth(s);
            Btn.SetMaxHeight(s);
            Btn.SetMaxWidth(s);

            Btn.Click += (s, e) =>
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                AlertDialog alert = dialog.Create();

                alert.SetTitle("Ajouter un élément");
                alert.SetIcon(Resource.Drawable.ic_add);

                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                View nv = inflater.Inflate(Resource.Layout.add_element, null);

                Button CreateBtn = nv.FindViewById<Button>(Resource.Id.create_element_btn);
                CreateBtn.Click += (s, e) =>
                {
                    string key = nv.FindViewById<TextView>(Resource.Id.key_input).Text.Replace(":", "|.|");
                    string value = nv.FindViewById<TextView>(Resource.Id.value_input).Text.Replace(":", "|.|");

                    if (key.Length  == 0 || value.Length == 0)
                    {
                        Toast.MakeText(context, "Le nom et la valeur de l'élément ne peuvent pas être vide", ToastLength.Long).Show();
                        return;
                    }

                    MainActivity.Instance.AddElement(key, value);

                    Toast.MakeText(context, key.Replace("|.|", "/") + " a été créé", ToastLength.Long).Show();
                    alert.Cancel();
                };

                nv.FindViewById<Button>(Resource.Id.cancel_create).Click += (s, e) => { alert.Cancel(); };

                alert.SetView(nv);
                alert.Show();
            };
        }
    }
}