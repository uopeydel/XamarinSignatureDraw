using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App2.Signature
{
    public class CustomSignaturePadView : SignaturePadView
    {
        public CustomSignaturePadView(Context context) : base(context)
        {
        }

        public CustomSignaturePadView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomSignaturePadView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            this.Parent.RequestDisallowInterceptTouchEvent(true);
            switch (e.Action)
            {
                case MotionEventActions.Up:
                    this.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
            }
            return base.OnTouchEvent(e);
        }
    }
}