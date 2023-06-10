using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FencePage : PopupPage
    {
        Position defaultLocation;
        double tempLat;
        double tempLon;
        public FencePage()
        {
            InitializeComponent();
            defaultLocation = new Position(this.customMap.Latitude, this.customMap.Longitude);
            tempLat = this.customMap.Latitude;
            tempLon = this.customMap.Longitude;
        }

        private void NewPin(Position newPosition)
        {
            Position position = newPosition;

            if (this.customMap.Pins.Count >= 2)
            {
                this.customMap.Pins.Remove(this.customMap.Pins[1]);
            }

            CustomPin pin = new CustomPin()
            {
                Position = position,
                Label = "",
                Address = ""
            };

            this.customMap.Pins.Add(pin);

            CalculateGeoFencing(new Location(customMap.BaseLocation.Latitude, customMap.BaseLocation.Longitude), new Location(newPosition.Latitude, newPosition.Longitude), (4.5 * 1.6));
        }

        private void CalculateGeoFencing(Location geofenceCentercordinate, Location userLocation, double coveringDistanceFromCenterPoint)
        {
            var distance = (long)Location.CalculateDistance(geofenceCentercordinate, userLocation, DistanceUnits.Kilometers);
            if (distance > coveringDistanceFromCenterPoint)
            {
                DisplayAlert("Geo-Fencing Plotting", "The user location is OUT of geo-fencing \n\n Latitude: " + userLocation.Latitude.ToString() + "\n" + "\n Longitude: " + userLocation.Longitude.ToString()
                    , "OK");
            }
        }

        private async void CloseBtn_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private void up_Clicked(object sender, EventArgs e)
        {
            tempLat = tempLat + 0.015d;
            NewPin(new Position(tempLat, tempLon));
        }

        private void down_Clicked(object sender, EventArgs e)
        {
            tempLat = tempLat - 0.015d;
            NewPin(new Position(tempLat, tempLon));
        }

        private void left_Clicked(object sender, EventArgs e)
        {
            tempLon = tempLon - 0.015d;
            NewPin(new Position(tempLat, tempLon));
        }

        private void right_Clicked(object sender, EventArgs e)
        {
            tempLon = tempLon + 0.015d;
            NewPin(new Position(tempLat, tempLon));
        }

        private async void loc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new RgPage(tempLat, tempLon, false));
        }
    }
}