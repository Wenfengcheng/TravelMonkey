using System;
using TravelMonkey.ViewModels;
using Xamarin.Forms;

namespace TravelMonkey.Views
{
    public partial class AddPicturePage : ContentPage
    {
        public AddPicturePage()
        {
            InitializeComponent();

            BindingContext = new AddPicturePageViewModel();

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureAddedMessage, async (vm) => await Shell.Current.GoToAsync("//main"));

            MessagingCenter.Subscribe<AddPicturePageViewModel>(this, Constants.PictureFailedMessage, async (vm) => await DisplayAlert("Uh-oh!", "Can you hand me my glasses? Something went wrong while analyzing this image", "OK"));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.Navigation.PopModalAsync();
            await Shell.Current.GoToAsync("//main");
        }
    }
}