using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FRESHTeaTime.ViewModels;

namespace FRESHTeaTime.Views
{
    public partial class NewTimerDialog : Window
    {
        public NewTimerDialogViewModel ViewModel => DataContext as NewTimerDialogViewModel;

        public NewTimerDialog()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public NewTimerDialog Initialize()
        {
            ViewModel.Window = this;
            return this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
