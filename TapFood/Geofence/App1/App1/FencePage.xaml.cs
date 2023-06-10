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
        public FencePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            scroll.ScrollToAsync(0, 0, true);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            scroll.ScrollToAsync(0, 25000, true);
        }
    }
}