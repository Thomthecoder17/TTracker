using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<DateTime> _statuses;
        public ObservableCollection<DateTime> Statuses
        {
            get => _statuses;
            set => SetProperty(ref _statuses, value);
        }

        private ObservableCollection<string> _directions;
        public ObservableCollection<string> Directions
        {
            get => _directions;
            set => SetProperty(ref _directions, value);
        }

        [RelayCommand]
        private async Task FetchTransitInfo()
        {
            var transitApiResponse = await _transitApiService.GetTransitInfo(Line, Station);
            Statuses = new ObservableCollection<DateTime>();
            Directions = new ObservableCollection<string>();
            if (transitApiResponse != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Statuses.Add(transitApiResponse.Data[i].Attributes.Arrival_time);
                    int directionId = transitApiResponse.Data[i].Attributes.Direction_id;
                    if (directionId == 1)
                    {
                        Directions.Add("Northbound");

                    }
                    else if (directionId == 0)
                    {
                        Directions.Add("Southbound");
                    }
                }
            }
            else
            {
                Directions.Add("N/A");
                Directions.Add("N/A");
            }
        }
    }
}
