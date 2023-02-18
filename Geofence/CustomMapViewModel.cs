using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace App1
{
    public class CustomMapViewModel : INotifyPropertyChanged
    {
        double lat;
        double lon;

        public CustomMapViewModel()
        {
            Lat = 10.790483;
            Lon = 78.704673;
            LoadLocation(); 
        }
        async void LoadLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Lat = location.Latitude;
                    Lon = location.Longitude;
                }
            }
            catch
            {
                throw new Exception("Feature Not Support \n Please Enable Network connection and Location Access!!");
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                OnPropertyChanged("Lat");
            }
        }

        public double Lon
        {
            get
            { return lon; }
            set
            {
                lon = value;
                OnPropertyChanged("Lon");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
