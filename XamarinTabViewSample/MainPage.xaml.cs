using System;
using Xamarin.Forms;
using XamarinTabViewSample.View;

namespace XamarinTabViewSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedViewPage());
        }
    }
}
