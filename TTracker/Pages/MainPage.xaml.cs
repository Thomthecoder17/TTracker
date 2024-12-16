using TTracker.Models.ViewModels;

namespace TTracker;

public partial class MainPage : ContentPage
{

public MainPage()
{
    InitializeComponent();

    BindingContext = new TransitInfoViewModel();
}
}
