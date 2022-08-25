using Android.App;
using Android.Views;
using Android.Widget;
using Context = Android.Content.Context;

namespace Android.Resources
{
    internal class ModifElement
    {
        public ModifElement(Activity context, string element)
        {
            string key = element.Split(":")[0];
            string value = element.Split(":")[1];

            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            AlertDialog alert = dialog.Create();

            alert.SetTitle(key.Replace("|.|", ":"));
            alert.SetIcon(Resource.Drawable.ic_pen);

            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View nv = inflater.Inflate(Resource.Layout.see_element, null);

            EditText KeyET = nv.FindViewById<EditText>(Resource.Id.view_element_key);
            KeyET.Text = key.Replace("|.|", ":");
            EditText ValueET = nv.FindViewById<EditText>(Resource.Id.view_element_value);
            ValueET.Text = value.Replace("|.|", ":");

            Button Save = nv.FindViewById<Button>(Resource.Id.save_btn);
            Save.Click += (s, e) =>
            {
                if (KeyET.Text.Equals("") || ValueET.Equals(""))
                {
                    Toast.MakeText(context, "Le nom et la valeur de l'élément ne peuvent pas être vide", ToastLength.Short);
                    return;
                }

                MainActivity.Instance.ModifElement(key, value, KeyET.Text.Replace(":", "|.|"), ValueET.Text.Replace(":", "|.|"));

                Toast.MakeText(context, key.Replace("|.|", "/") + " a été modifié", ToastLength.Short);
                alert.Cancel();
            };

            nv.FindViewById<Button>(Resource.Id.close_modif).Click += (s, e) => { alert.Cancel(); };

            alert.SetView(nv);
            alert.Show();
        }
    }
}