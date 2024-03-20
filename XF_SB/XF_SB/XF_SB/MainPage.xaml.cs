using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XF_SB
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.ListItems = new ObservableCollection<ListItem>()
            {
                new ListItem(){ ParentMainPage=this, Name="Barcode Scanner", Description="This sample used to demo bar code scanner features in Xamarin forms", Icon="barcodescanner1.png"},
                new ListItem(){ Name="Camera View",Description="This demo shows Camera view works in Xamarin forms", Icon="photo.png" },
                new ListItem(){ Name="Base64 To Image",Description="This demo shows how to convert base 64 string to Image content", Icon= "convert.png"},
                new ListItem(){ ParentMainPage=this,Name="Drag and Drop",Description="This sample demos drag and drop feature in xamarin forms", Icon = "drag.png" },
                new ListItem(){ Name="Geofence",Description="This demo shows the feature of geo fencing and mapping concept", Icon= "googlemaps.png" },
                new ListItem(){ Name="Base64 To PDF ",Description="This demo shows how to convert base 64 string to PDF content", Icon= "convert.png" },
                new ListItem(){ Name="Behaviors ",Description="This demo shows behavior concepts in Xamarin forms", Icon= "decision.png" },
                new ListItem(){ Name="Buttons",Description="This demo shows how implement button customization in Xamarin forms", Icon= "play.png" },
                new ListItem(){ Name="Image To Bitmap ",Description="This demo shows how to convert Xamarin  to Image content", Icon= "convert.png"},
            };
            BindingContext = mainPageViewModel;
            loginTime.Text = "Current Login: " + System.DateTime.Now.ToString();
        }

        internal void DoNavigation(object obj)
        {
            string pageName = obj.ToString();
            switch (pageName)
            {
                case "Barcode Scanner":
                    Navigation.PushAsync(new BarcodeScanner());
                    break;
                case "Drag and Drop":
                    Navigation.PushAsync(new DragAndDropPage());
                    break;
                default:
                    break;
            }
        }
    }
}