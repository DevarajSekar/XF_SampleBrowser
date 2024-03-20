using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XF_SB
{
    internal class MainPageViewModel
    {
        public ObservableCollection<ListItem> ListItems { get; set; } = new ObservableCollection<ListItem>();
        public MainPageViewModel()
        {
        }
    }
}