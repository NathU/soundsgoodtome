﻿using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Org.Libsdl.App;
using Urho;
using Urho.Droid;

namespace SoundsGoodToMe.Droid
{
    [Activity(Label = "SoundsGoodToMe.Droid", MainLauncher = true,
        Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
        ConfigurationChanges = ConfigChanges.KeyboardHidden | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        MyGame myGame;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var layout = new AbsoluteLayout(this);
            var surface = UrhoSurface.CreateSurface<MyGame>(this);
            layout.AddView(surface);
            SetContentView(layout);
            myGame = await surface.Show<MyGame>(new ApplicationOptions("Data"));
            //to stop the game use await surface.Stop().
        }

        protected override void OnResume()
        {
            UrhoSurface.OnResume();
            base.OnResume();
        }

        protected override void OnPause()
        {
            UrhoSurface.OnPause();
            base.OnPause();
        }

        public override void OnLowMemory()
        {
            UrhoSurface.OnLowMemory();
            base.OnLowMemory();
        }

        protected override void OnDestroy()
        {
            UrhoSurface.OnDestroy();
            base.OnDestroy();
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.KeyCode == Android.Views.Keycode.Back)
            {
                this.Finish();
                return false;
            }

            return base.DispatchKeyEvent(e);
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            UrhoSurface.OnWindowFocusChanged(hasFocus);
            base.OnWindowFocusChanged(hasFocus);
        }
    }
}

