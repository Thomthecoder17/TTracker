using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TTracker.Models.ViewModels
{
    internal partial class TransitInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string line = "";

        [ObservableProperty]
        private string station = "";

        [ObservableProperty]
        private string status = "";

        [ObservableProperty]
        private string alerts = "";

        [RelayCommand]
        private async Task FetchTransitInfo()
        {

        }
    }
}
