using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TTracker.Models.APIModels;

namespace TTracker.Services;

internal class TransitApiService
{
    private readonly HttpClient _httpClient;

    public TransitApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
    }

    public async Task<TransitApiResponse> GetTransitInfo(string line, string station)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }
        //FIGURE OUT HOW TO MAKE THE API ACTUALLY RETURN SOMETHING HERE
    }
}
