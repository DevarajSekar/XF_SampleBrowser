using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using System.ComponentModel;

namespace App1
{
    public partial class RgPage : PopupPage
    {
        public RgPage()
        {
            InitializeComponent();
            LoadAddress();
        }

        private async void LoadAddress()
        {
            try
            {
                double Latitude = 10.790483;
                double Longitude = 78.704673;
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                }

                var placemarks = await Geocoding.GetPlacemarksAsync(Latitude, Longitude);
                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    adminAreaLabel.Text = placemark.AdminArea;
                    countryCodeLabel.Text = placemark.CountryCode;
                    countryNameLabel.Text = placemark.CountryName;
                    featureNameLabel.Text = placemark.FeatureName;
                    localityNameLabel.Text = placemark.Locality;
                    postalCodeNameLabel.Text = placemark.PostalCode;
                    subAdminAreaNameLabel.Text = placemark.SubAdminArea;
                    subThoroughfareNameLabel.Text = placemark.SubThoroughfare;
                    thoroughfareNameLabel.Text = placemark.Thoroughfare;
                    mainAreaNameLabel.Text = placemark.SubLocality;
                }
                customloader.IsRunning = false;
                infoStack.IsVisible = true;
            }
            catch (FeatureNotEnabledException ex)
            {
                DisplayAlert("Feature Not Support", ex.Message, "OK");
            }
        }

        private async void CloseBtn_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}