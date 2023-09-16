using Xamarin.Forms.Xaml;
using XamarinTabViewSample.Model;
using XamarinTabViewSample.ViewModel;

namespace XamarinTabViewSample.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedViewPage : CustomTabbedPage
    {
        TabbedPageViewModel viewModel;
        public TabbedViewPage()
        {
            InitializeComponent();
            viewModel=new TabbedPageViewModel();
            BindingContext = viewModel;
        }
    }
}