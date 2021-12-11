using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRESHTeaTime.Views;
using ReactiveUI;

namespace FRESHTeaTime.ViewModels
{
    public class NewTimerDialogViewModel : ViewModelBase
    {
        public NewTimerDialog Window { get; set; }

        private string hours = "00";
        public string Hours
        {
            get => hours;
            set => this.RaiseAndSetIfChanged(ref hours, value);
        }

        private string minutes = "00";
        public string Minutes
        {
            get => minutes;
            set => this.RaiseAndSetIfChanged(ref minutes, value);
        }

        private string seconds = "00";
        public string Seconds
        {
            get => seconds;
            set => this.RaiseAndSetIfChanged(ref seconds, value);
        }

        private string? timerName;
        public string? TimerName
        {
            get => timerName;
            set => this.RaiseAndSetIfChanged(ref timerName, value);
        }

        public bool OK { get; private set; } = false;

        public void OKCommand()
        {
            OK = true;
            Window.Close();
        }

        public void CancelCommand() => Window.Close();
    }
}
