using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReactiveUI;

namespace twentytwentytwenty.src.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private int _hours, _minutes, _seconds;
        public int Hours
        {
            get => _hours;

            set
            {
                // value variable is provided by default on set
                _hours = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimerDisplay)); // update display
            }
        }
        public int Minutes
        {
            get => _minutes;

            set
            {
                // value variable is provided by default on set
                _minutes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimerDisplay)); // update display
            }
        }
        public int Seconds
        {
            get => _seconds;

            set
            {
                // value variable is provided by default on set
                _seconds = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimerDisplay)); // update display
            }
        }

        public string TimerDisplay => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        public ICommand IncrementHoursCommand { get; }

        public TimerViewModel()
        {
            IncrementHoursCommand = ReactiveCommand.Create(() => Hours++);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null!)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}