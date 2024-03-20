using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_SB.ViewModel;

namespace XF_SB
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeScanner : ContentPage
	{
        public BarcodeScanner()
        {
            InitializeComponent();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                resultLabel.Text = "Info : " + result.Text + "\nBarcode Type : " +
                    result.BarcodeFormat.ToString();
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            scanner.IsScanning = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new CodeviewPage("Barcode scanner", "Implemented using ZXing bar code scanner and reading DLL", ""));
        }
    }
}