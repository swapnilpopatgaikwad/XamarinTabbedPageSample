using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTabViewSample.View;

namespace XamarinTabViewSample.Model
{
    public class CustomTabbedPage: TabbedPage
    {
        public static readonly BindableProperty TabbedPagesProperty =
            BindableProperty.Create(
                nameof(TabbedPages),
                typeof(ObservableCollection<ContentPage>),
                typeof(TabbedViewPage),
                new ObservableCollection<ContentPage>(),
                propertyChanged: OnTabbedPagesPropertyChanged);

        public ObservableCollection<ContentPage> TabbedPages
        {
            get { return (ObservableCollection<ContentPage>)GetValue(TabbedPagesProperty); }
            set { SetValue(TabbedPagesProperty, value); }
        }

        public static readonly BindableProperty CurrentTabChangedCommandProperty =
            BindableProperty.Create(nameof(CurrentTabChangedCommand), typeof(ICommand), typeof(TabbedViewPage), null,BindingMode.TwoWay);

        public ICommand CurrentTabChangedCommand
        {
            get { return (ICommand)GetValue(CurrentTabChangedCommandProperty); }
            set { SetValue(CurrentTabChangedCommandProperty, value); }
        }
        public CustomTabbedPage()
        {
            CurrentPageChanged += OnCurrentPageChanged;
        }

        ~CustomTabbedPage()
        {
            CurrentPageChanged -= OnCurrentPageChanged;
        }

        private static void OnTabbedPagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is TabbedViewPage customTabbedPage)
            {
                customTabbedPage.Children.Clear();

                if (newValue is ObservableCollection<ContentPage> pages)
                {
                    foreach (var page in pages)
                    {
                        customTabbedPage.Children.Add(page);
                    }
                }
            }
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            if (CurrentTabChangedCommand != null && CurrentTabChangedCommand.CanExecute(sender))
            {
                if (sender is TabbedViewPage customTabbedPage)
                    CurrentTabChangedCommand.Execute(customTabbedPage.CurrentPage);
            }
        }
    }
}
