using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public GeoClassCollection GeoClassCollection { get; set; }
        int index { get; set; }
        double DP { get; set; }
        public MainPage()
        {
            InitializeComponent();
            DP = DependencyService.Get<IServiceDp>().GetDpScale();
            GeoClassCollection = new GeoClassCollection(DP);
            this.BindingContext = GeoClassCollection;
        }

        private void CarouselView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.CenterItemIndex == 0)
            {
                index = 0;
                this.Background = new LinearGradientBrush()
                {
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection()
                {
                    new GradientStop(){ Color= Color.FromHex("#5b1c63") , Offset=0.1f},
                    new GradientStop(){ Color=Color.FromHex("#212a94" ), Offset=1.0f},
                }
                };
            }
            else
            {
                index = 1;
                this.Background = new LinearGradientBrush()
                {
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection()
                {
                    new GradientStop(){ Color= Color.FromHex("#016eb9") , Offset=0.1f},
                    new GradientStop(){ Color=Color.FromHex("#010c12") , Offset=0.8f},
                    new GradientStop(){ Color=Color.FromHex("#010c12") , Offset=1.0f}
                }
                };
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (index == 0)
            {
                await Navigation.PushPopupAsync(new RgPage(10.790483, 78.704673, true));
            }
            else if (index == 1)
            {
                await Navigation.PushPopupAsync(new FencePage());
            }
        }
    }

    public class GeoClass
    {
        public string templateImage { get; set; }
        public string buttonImage { get; set; }
        public string templateContent { get; set; }
        public string templateTopic { get; set; }
        public double ImageHeight { get; set; }
    }

    public class GeoClassCollection : INotifyPropertyChanged
    {
        public ObservableCollection<GeoClass> geoClasses;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TemplateButonClicked;

        public double DP;

        public double height { get; set; }

        public GeoClassCollection(double dp)
        {
            DP = dp;
            if (DP <= 1.75)
            {
                height = 150;
            }
            else if (DP > 1.75)
            {
                height = 250;
            }
            GeoClasses = new ObservableCollection<GeoClass>()
            {
                new GeoClass(){
                    ImageHeight = height * DP,
                    templateTopic = "GEO-LOCATOR",
                    templateImage="locator2.jpg",
                    buttonImage="locatorbutton.png",
                    templateContent="Geolocation makes it possible, from any device connected to the Internet, to obtain all types of information in real time and locate the user with pinpoint accuracy at a given point in time. Geolocation technology is the foundation for location-positioning services and location-aware applications (apps)."
                },
                new GeoClass(){
                    ImageHeight = height * DP,
                    templateTopic = "GEO-FENCING",
                    templateImage="globe.jpg",
                    buttonImage="fencubutton5.jpg",
                    templateContent="Geofencing creates a virtual geographical boundary that triggers a marketing action to a mobile device when a user enters or exits that boundary.\n geofencing is focused on the virtual perimeter you build around a specific geographic location to deliver targeted messaging."
                }
            };
        }

        public ObservableCollection<GeoClass> GeoClasses
        {
            get
            {
                return geoClasses;
            }
            set
            {
                if (geoClasses != value)
                {
                    geoClasses = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("GeoClasses"));
                }
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }

    public interface IServiceDp
    {
        double GetDpScale();
    }
}