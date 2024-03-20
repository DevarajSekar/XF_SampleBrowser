using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF_SB
{
    internal class ListItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public MainPage ParentMainPage { get; set; }
        public ICommand TapCommand { get; set; }
        public ListItem()
        {
            TapCommand = new Command(ItemTapped);
        }

        private void ItemTapped(object obj)
        {
            if (ParentMainPage != null)
            {
                ParentMainPage.DoNavigation(obj);
            }
        }
    }
}
