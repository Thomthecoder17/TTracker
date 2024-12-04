using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TTracker.Services;

namespace TTracker.Models.ViewModels
{
    internal partial class TransitInfoViewModel : ObservableObject
    {
        private readonly TransitApiService _transitApiService;

        public TransitInfoViewModel()
        {
            _transitApiService = new TransitApiService();
        }

        [ObservableProperty]
        private string line;

        [ObservableProperty]
        private string station;

        [ObservableProperty]
        private DateTime[] status = new DateTime[2];

        [ObservableProperty]
        private string[] direction = new string[2];

        [RelayCommand]
        private async Task FetchTransitInfo()
        {
            var transitApiResponse = await _transitApiService.GetTransitInfo(Line, Station);
            if (transitApiResponse != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.Status[i] = transitApiResponse.Data[i].Attributes.Arrival_time;
                    int directionId = transitApiResponse.Data[i].Attributes.Direction_id;
                    if (directionId == 1)
                    {
                        this.Direction[i] = "Northbound";

                    }
                    else if (directionId == 0)
                    {
                        this.Direction[i] = "Southbound";
                    }
                }
            }
            else
            {
                Direction[0] = "N/A";
                Direction[1] = "N/A";
            }
        }
    }
}
