# Overview:
This is a simple app that I am designing to track MBTA trains (and hopefully buses) in and around Boston. 

This app uses the MBTA's API found at https://api-v3.mbta.com/ 

Currently this app simply uses the user inputted text to find the predictions for trains. This does however mean that the user has to type *EXACTLY* what the API wants to get a result. For example, when searching for Orange line departures from North Station, the user would have to type "Orange" for the line and "place-north" for the station. This hopefully will be fixed in the near future. 

This app was created using Microsoft's .NET MAUI framework.

To use, make sure to add an API key in the Constants.cs file.

# License:
TTracker is licensed under the MIT license. See the LICENSE file for more details.
