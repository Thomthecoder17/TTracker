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

        //When you figure out what is going on here, add a comment
        private ObservableCollection<System.TimeSpan> _statuses;
        public ObservableCollection<System.TimeSpan> Statuses
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
            var transitPredictions = await _transitApiService.GetTransitInfo(Line, Station, "predictions");
            Statuses = new ObservableCollection<System.TimeSpan>();
            Directions = new ObservableCollection<string>();

            //Gets the current UTC and converts it to EST
            DateTime currentUTC = DateTime.UtcNow;
            //EST is used here since Boston (and therefore the MBTA) is in the EST time zone (honestly doesn't matter since it gives the time UNTIL arrival in the end)
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime currentEST = TimeZoneInfo.ConvertTimeFromUtc(currentUTC, estZone);

            if (transitPredictions != null)
            {
                for (int i = 0; i < transitPredictions.Data.Length; i++)
                {
                    int directionId = transitPredictions.Data[i].Attributes.Direction_id;
                    if (directionId == 1)
                    {
                        Directions.Add("Northbound");

                    }
                    else if (directionId == 0)
                    {
                        Directions.Add("Southbound");
                    }

                    //Converts the predicted time (Which happpens to be in the local time zone of the device, not sure why) to EST for the later operations
                    DateTime predictedTime = transitPredictions.Data[i].Attributes.Arrival_time;
                    DateTime predictedEst = TimeZoneInfo.ConvertTime(predictedTime, estZone);

                    //Subtracts the current time from the predicted time to give the time until arrival
                    System.TimeSpan status = predictedEst.Subtract(currentEST);

                    if (status < System.TimeSpan.Zero)
                    {
                        Directions.RemoveAt(0);
                    }
                    else
                    {
                        Statuses.Add(status);
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
