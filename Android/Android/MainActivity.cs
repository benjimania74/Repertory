using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Resources;
using System.Collections.Generic;
using System.IO;
using static Android.Renderscripts.Sampler;

namespace Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.MaterialComponents.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private int Width;
        public int Height;
        private List<TableItem> items;
        public static MainActivity Instance;
        string f = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "repertory.ppr");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            items = new List<TableItem>();
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Width = Resources.DisplayMetrics.WidthPixels;
            Height = Resources.DisplayMetrics.HeightPixels;

            EditText Et = FindViewById<EditText>(Resource.Id.search_bar);
            Et.SetWidth(Width - (Et.Height + 130));
            Et.TextChanged += (s, e) =>
            {
                ActualiseList(Et.Text);
            };

            ActualiseList();
            new AddElement(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void ActualiseList(string Contain = "")
        {
            if (!File.Exists(f))
            {
                CreateFile();
            }

            items.Clear();

            using (StreamReader reader = File.OpenText(f))
            {
                string LineContent = "";
                while ((LineContent = reader.ReadLine()) != null)
                {
                    if (LineContent.Contains(":"))
                    {
                        if (LineContent.Split(":")[0].Replace("|.|", ":").ToLower().Contains(Contain.ToLower()))
                        {
                            TableItem Tb = new TableItem(LineContent.Split(":")[0], LineContent.Split(":")[1]);
                            items.Add(Tb);
                        }
                    }
                }
                reader.Close();
            }

            ListView Lv = FindViewById<ListView>(Resource.Id.element_list);
            Lv.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels - FindViewById<GridLayout>(Resource.Id.content_layout).Height);

            Lv.Adapter = new ElementListAdapter(this, items, Width);
        }

        public void AddElement(string key, string value)
        {
            items.Add(new TableItem(key, value));
            using StreamWriter file = new StreamWriter(f, append: true);
            file.WriteLineAsync(key + ":" + value);
            file.Close();
            ActualiseList(FindViewById<EditText>(Resource.Id.search_bar).Text);
        }

        public void RemoveElement(string key, string value)
        {
            using (StreamReader reader = File.OpenText(f))
            {
                List<string> Lines = new List<string>();
                string content = "";
                while ((content = reader.ReadLine()) != null)
                {
                    Lines.Add(content);
                }

                Lines.Remove(key + ":" + value);

                items = new List<TableItem>();

                Lines.ForEach(s =>
                {
                    items.Add(new TableItem(s.Split(":")[0], s.Split(":")[1]));
                });
            }
            Save();
            ActualiseList(FindViewById<EditText>(Resource.Id.search_bar).Text);
        }

        public void ModifElement(string oldKey, string oldValue, string newKey, string newValue)
        {
            using (StreamReader reader = File.OpenText(f))
            {
                List<string> Lines = new List<string>();
                string content = "";
                while ((content = reader.ReadLine()) != null)
                {
                    if(content.Equals(oldKey + ":" + oldValue))
                    {
                        content = content.Replace(oldKey, newKey).Replace(oldValue, newValue);
                    }
                    Lines.Add(content);
                }

                items = new List<TableItem>();

                Lines.ForEach(s =>
                {
                    items.Add(new TableItem(s.Split(":")[0], s.Split(":")[1]));
                });
                reader.Close();
            }

            Save();
            ActualiseList(FindViewById<EditText>(Resource.Id.search_bar).Text);
        }

        private void Save()
        {
            CreateFile();

            using StreamWriter file = new StreamWriter(f, append: true);
            items.ForEach(it =>
            {
                file.WriteLineAsync(it.key + ":" + it.value);
            });
            file.Close();
            ActualiseList();
        }

        private void CreateFile()
        {
            using (FileStream fs = File.Create(f))
            {
                byte[] info = System.Text.Encoding.ASCII.GetBytes("");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }
    }
}