using Avalonia.Threading;
using System;

namespace twentytwentytwenty.src.Services
{
    public class TimerService
    {
        // readonly = you can only assign it within the constructor, cannot be modified elsewhere
        private readonly DispatcherTimer _timer;
        private int _hours, _minutes, _seconds;

        public int Hours => _hours;
        public int Minutes => _minutes;
        public int Seconds => _seconds;

        public event Action? Tick; // raised every second

        public TimerService(int hours = 0, int minutes = 0, int seconds = 0)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) => OnTick();
        }

        private void OnTick()
        {
            if (_seconds > 0)
                _seconds--;
            else if (_minutes > 0)
            {
                _minutes--;
                _seconds = 59;
            }
            else if (_hours > 0)
            {
                _hours--;
                _minutes = 59;
                _seconds = 59;
            }
            else
            {
                _timer.Stop();
            }

            Tick?.Invoke(); // notify subscribers (like the ViewModel)
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();
        public void Reset(int hours, int minutes, int seconds)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            Tick?.Invoke();
        }
    }
}
