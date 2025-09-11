using Avalonia.Controls;

namespace twentytwentytwenty;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new TimerViewModel(); // binds the ui to the model
    }
}