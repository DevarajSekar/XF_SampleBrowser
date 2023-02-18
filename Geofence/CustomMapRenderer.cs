using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Maps;
using App1.Droid;
using App1;

[assembly: ExportRenderer(typeof(CustomMap),typeof(CustomMapRenderer))]
namespace App1.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;
        CustomMap formsMap;

        public CustomMapRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            NativeMap.SetInfoWindowAdapter(this);

            var marker = new CircleOptions();
            if (formsMap != null)
            {
                marker.InvokeCenter(new LatLng(formsMap.BaseLocation.Latitude, formsMap.BaseLocation.Longitude));
                marker.InvokeRadius(formsMap.BaseRadius * 1000);
                marker.InvokeStrokeColor(Android.Graphics.Color.ParseColor("#e6d9534f"));
                marker.InvokeFillColor(Android.Graphics.Color.ParseColor("#1e009600"));
                marker.InvokeStrokeWidth(3f);
                map.AddCircle(marker);
            }
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            return marker;
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}