using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTabViewSample.View;

namespace XamarinTabViewSample.ViewModel
{
    public class TabbedPageViewModel: BaseViewModel
    {
        private ObservableCollection<ContentPage> contentPages;
        public ObservableCollection<ContentPage> ContentPages
        {
            get { return contentPages; }
            set
            {
                if (contentPages != value)
                {
                    contentPages = value;
                    OnPropertyChanged(nameof(ContentPages));
                }
            }
        }
        public ICommand TabChangedCommand { get; set; }

        public TabbedPageViewModel()
        {
            TabChangedCommand = new Command<object>(TabChangedMethod);

            ContentPages = new ObservableCollection<ContentPage>()
            {
                new TabPage1(),
                new TabPage2(),
                new TabPage3(),
                new TabPage4(),
            };
        }

        private void TabChangedMethod(object obj)
        {
            ///Here load your tab data
            if (obj != null)
            {
                switch (obj as ContentPage)
                {
                    case TabPage1 _:
                        Console.WriteLine("Tab 1");
                        break;
                    case TabPage2 _:
                        Console.WriteLine("Tab 2");
                        break;
                    case TabPage3 _:
                        Console.WriteLine("Tab 3");
                        break;
                    case TabPage4 _:
                        Console.WriteLine("Tab 4");
                        break;
                    default: break;
                }
            }
        }
    }
}
