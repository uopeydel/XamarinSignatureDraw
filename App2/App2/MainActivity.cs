using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Graphics;
using System.IO;
using App2.Common;
using System;
using App2.Signature;
using static App2.Common.FileDirectoryUtilities;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private CustomSignaturePadView signature;
      //  private RelativeLayout layout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            signature = FindViewById<CustomSignaturePadView>(Resource.Id.signatureView);
            SignaturePad();
            var btnCall = FindViewById<Button>(Resource.Id.btnCal);
            btnCall.Click += BtnCallMethod;


        }

        private void BtnCallMethod(object sender, EventArgs e)
        {
            SignatureSave();
        }

        public void SignaturePad()
        {
            signature.BackgroundColor = Color.Rgb(205, 55, 155);
            signature.StrokeColor = Color.White;

            var layout = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.WrapContent);
            layout.AddRule(LayoutRules.CenterInParent);
            layout.SetMargins(20, 20, 20, 20);
            signature.BackgroundImageView.LayoutParameters = layout;
        }


        private string SignatureSave()
        {


            string URLPicture = string.Empty;
           
            // SAVE TO SDCARD
            try
            {
                string guidImg = DateTime.Now.ToString("yyyyMMddHHmmss");
                string pathFileTemp = string.Format("{0}{1}", FileDirectoryUtilities.GetDirectory(WokringDir.MyAppDir), WokringDir.TempCamera);
                string fileName = string.Format("{0}{1}.png", pathFileTemp, guidImg);

                Bitmap imagen = signature.GetImage(Color.Black, Color.White, false);

                //if (!Directory.Exists(pathFileTemp))
                //    Directory.CreateDirectory(pathFileTemp);

                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    imagen.Compress(Bitmap.CompressFormat.Png, 100, fs);
                    // Toast.MakeText(this, "Done", ToastLength.Short).Show();
                    fs.Close();
                }

                #region ForSaveTocloud
 
                #endregion
            }
            catch (Exception e)
            {
                //Toast.MakeText(this, "problem", ToastLength.Short).Show();
            }
            return URLPicture;
        }
    }
}

