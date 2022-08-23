using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Android.Widget;
using AndroidX.CardView.Widget;
using Android.Resources;
using System.Collections.Generic;

namespace Android{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.MaterialComponents.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity{
        private int Width;

        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Width = Resources.DisplayMetrics.WidthPixels;

            EditText Et = FindViewById<EditText>(Resource.Id.search_bar);
            Et.SetWidth(Width - 120);

            ActualiseList();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults){
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void ActualiseList(string Contain = ""){
            ListView Lv = FindViewById<ListView>(Resource.Id.element_list);
            Lv.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels - FindViewById<GridLayout>(Resource.Id.content_layout).Height);

            List<TableItem> items = new List<TableItem>(){
                new TableItem(Key: "Key", Value: "Value"),
                new TableItem(Key: "Hello", Value: "Hey"),
                new TableItem(Key: "Salut !", Value: "Hello !")
            };

            Lv.Adapter = new ElementListAdapter(this, items, Width);
        }
    }
}