using SampleMauiApp.ViewModels;

namespace SampleMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MonkeysViewModel();
        }

    }
}