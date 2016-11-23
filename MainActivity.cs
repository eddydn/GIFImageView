using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Felipecsl.GifImageViewLibrary;
using static Android.Views.View;
using Android.Views;
using System;
using System.Net.Http;

using Android.Graphics;
using static Felipecsl.GifImageViewLibrary.GifImageView;

namespace GIFImageView
{
    [Activity(Label = "GIFImageView", MainLauncher = true, Icon = "@drawable/icon",Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity,IOnClickListener,IOnFrameAvailableListener
    {
        GifImageView gifImageView;
        Button btnStart, btnStop, btnBlur;

        Blur blur;
        bool isBlur;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);


            blur = Blur.NewInstance(this);
            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnStop = FindViewById<Button>(Resource.Id.btnStop);
            btnBlur = FindViewById<Button>(Resource.Id.btnBlur);

            btnStart.SetOnClickListener(this);
            btnStop.SetOnClickListener(this);
            btnBlur.SetOnClickListener(this);

            gifImageView.OnFrameAvailableListener = this;
        }

        public async void OnClick(View v)
        {
            int id = v.Id;
            if(id == Resource.Id.btnStart)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var bytes = await client.GetByteArrayAsync("http://gifdanceparty.giphy.com/assets/dancers/smooch.gif");
                        gifImageView.SetBytes(bytes);
                        gifImageView.StartAnimation();
                    }
                }
                catch(Exception ex)
                {

                }
            }
            else if(id == Resource.Id.btnStop)
            {
                gifImageView.StopAnimation();
            }
            else if(id == Resource.Id.btnBlur)
            {
                isBlur = !isBlur;
            }
        }

        public Bitmap OnFrameAvailable(Bitmap bitmap)
        {
            if (isBlur)
                return blur.BlurImage(bitmap);
            return bitmap;
        }
    }
}

