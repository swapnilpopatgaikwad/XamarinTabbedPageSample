using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinTabViewSample.Model
{
    public class TabbedPageCurrentPageChangedBehavior : Behavior<TabbedPage>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TabbedPageCurrentPageChangedBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(TabbedPage bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.CurrentPageChanged += OnCurrentPageChanged;
        }

        protected override void OnDetachingFrom(TabbedPage bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.CurrentPageChanged -= OnCurrentPageChanged;
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            if (Command != null && Command.CanExecute(sender))
            {
                Command.Execute(sender);
            }
        }
    }
}
