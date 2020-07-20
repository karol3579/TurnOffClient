using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using System;
using Java.Lang.Reflect;
using Java.Lang;
using System.IO;

namespace TurnOffClient_mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Config config = new Config();

            //check if config file exists, if not - create one 
            config.checkExistence();

            //get our text fields with ip and port
            EditText serverIP = FindViewById<EditText>(Resource.Id.ipField);
            EditText serverPort = (FindViewById<EditText>(Resource.Id.portField));

            //load ip and port from config file
            serverIP.Text = config.loadIp();
            serverPort.Text = config.loadPort();

            //Turn-off button action code
            Button turnoff = FindViewById<Button>(Resource.Id.turnOffButton);
             turnoff.Click += (sender, e) => {
                 string ip = serverIP.Text.ToString();
                 Int32 port = Int32.Parse(serverPort.Text.ToString());
                new Connection(ip,port);
            };

            //Save button action code
            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += (sender, e) => {
                config.saveData(serverIP.Text,serverPort.Text);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}