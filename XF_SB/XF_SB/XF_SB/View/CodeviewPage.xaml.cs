using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_SB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeviewPage : PopupPage
    {
        public CodeviewPage(string title, string keyDecriptionPoint, string importantCodeSnippets)
        {
            InitializeComponent();
            MainTitle.Text = title;
            keyPoints.Text = keyDecriptionPoint;
        }

        private void closeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync(true);
        }
    }
}