using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TodList.Data;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodList
{
    public partial class App : Application
    {

        static todoDatabase database;

        public static todoDatabase Database
        {
            get {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string dbFile = Path.Combine(dir, "items.db");

                //Check to see if DB exists
                if (!File.Exists(dbFile))
                {
                    var resId = Assembly.GetExecutingAssembly().GetManifestResourceNames().First(n => n.Contains("items.db"));
                    var resStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resId);

                    // If not save resource to documentsDirectory
                    var outputStream = File.OpenWrite(dbFile);
                    resStream.CopyTo(outputStream);
                    outputStream.Flush();
                    outputStream.Close();
                }

                database = new todoDatabase(dbFile);
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();

        }
        
        protected async override void OnStart()
        {
            await Permissions.RequestAsync<Permissions.StorageRead>();
            await Permissions.RequestAsync<Permissions.StorageWrite>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
