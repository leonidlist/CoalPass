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
using CoalPasswordsApp.Controls;
using CoalPasswordsApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace CoalPasswordsApp.Droid.Renderers
{
    class RoundedButtonRenderer : ButtonRenderer
    {
        public RoundedButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            Control.Background = Context.GetDrawable(Resource.Drawable.roundedButton);
            Control.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
        }
    }
}