using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Renderscripts;
using Android.Graphics;

namespace GIFImageView
{
    class Blur
    {
        private static float BLUR_RADIUS = 20f;
        private RenderScript rs;
        private ScriptIntrinsicBlur script;
        private Allocation input, output;
        private bool configured = false;
        private Bitmap tmp;
        private int[] pixels;

        public Blur(Context context)
        {
            rs = RenderScript.Create(context);
        }

        public static Blur NewInstance(Context context)
        {
            return new Blur(context);
        }

        public Bitmap BlurImage(Bitmap image)
        {
            if (image == null)
                return null;
            image = RGB565ToARGB888(image);
            if (!configured)
            {
                input = Allocation.CreateFromBitmap(rs, image);
                output = Allocation.CreateTyped(rs, input.Type);
                script = ScriptIntrinsicBlur.Create(rs, Element.U8_4(rs));
                script.SetRadius(BLUR_RADIUS);
                configured = true;
            }
            else
                input.CopyFrom(image);

            script.SetInput(input);
            script.ForEach(output);
            output.CopyTo(image);

            return image;
        }

        private Bitmap RGB565ToARGB888(Bitmap image)
        {
            int numPixels = image.Width * image.Height;
            if(tmp == null)
            {
                tmp = Bitmap.CreateBitmap(image.Width, image.Height, Bitmap.Config.Argb8888);
                pixels = new int[numPixels];
            }

            image.GetPixels(pixels, 0, image.Width, 0, 0, image.Width, image.Height);
            tmp.SetPixels(pixels, 0, tmp.Width, 0, 0, tmp.Width, tmp.Height);
            return tmp;
        }
    }
}