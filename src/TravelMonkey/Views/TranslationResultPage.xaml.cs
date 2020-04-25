using System;
using TravelMonkey.ViewModels;
using Xamarin.Forms;

namespace TravelMonkey.Views
{
    [QueryProperty("InputText", "inputText")]
    public partial class TranslationResultPage : ContentPage
    {
        private readonly TranslateResultPageViewModel _translateResultPageViewModel =
            new TranslateResultPageViewModel();

        public string InputText
        {
            set
            {
                _translateResultPageViewModel.InputText = value;
                BindingContext = _translateResultPageViewModel;
            }
        }

        public TranslationResultPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<TranslateResultPageViewModel>(this,
                Constants.TranslationFailedMessage,
                async (s) =>
                {
                    await DisplayAlert("Whoops!", "We lost our dictionary, something went wrong while translating", "OK");
                });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            await Shell.Current.GoToAsync("//main");
        }
    }
}