using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRESHTeaTime.Models
{
    public class Timer
    {
        public string Name { get; set; } = "Timer";

        public TimeSpan TimeLeft;

        public string TimeString => TimeLeft.ToString(); // for binding purposes
    }
}
