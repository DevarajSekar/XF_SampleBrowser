using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace App1
{
    public class CustomMap : Map
    {
        CustomMapViewModel viewModel;

        public CustomMap()
        {
            viewModel = new CustomMapViewModel();
            this.TrafficEnabled = true;
            MoveToLastRegionOnLayoutChange = false;
            MapType = MapType.Street;
            Latitude = 10.814760476; 
            Longitude = 78.67320788;
            BaseLocation = new Position(Latitude, Longitude);
            BaseRadius = ConvertMilesToKms(5d);
            SetLocation(BaseLocation, BaseRadius);
            SetMapPins();
        }

        private void SetLocation(Position position, double radius)
        {
            MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(radius)));
        }

        private void SetMapPins()
        {
            CustomPins = new List<CustomPin>();
            AddPin(BaseLocation, "", "", "");
            
        }

        private void AddPin(Position position, string label, string address, string groupName)
        {
            CustomPin pin = new CustomPin()
            {
                Position = position,
                Label = label,
                Type = PinType.SearchResult,
                Address = address,
            };
            this.Pins.Add(pin);
            CustomPins.Add(pin);
        }

        private double ConvertMilesToKms(double miles)
        {
            return miles * 1.6;
        }

        public List<CustomPin> CustomPins { get; set; }

        public Position BaseLocation { get; set; }

        public double BaseRadius
        {
            get; set;
        }

        public double Latitude
        {
            get;set;
        }

        public double Longitude
        {
            get;set;
        }
    }

    public class CustomPin : Pin
    {
        public bool IsRepeatedLocation { get; set; }
    }
}
