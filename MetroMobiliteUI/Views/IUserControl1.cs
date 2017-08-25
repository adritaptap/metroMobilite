using System.ComponentModel;
using System.Windows;

namespace MetroMobiliteUI.Views
{
    public interface IUserControl1
    {
        string Dist { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void DisplayData(object sender, RoutedEventArgs e);
        void InitializeComponent();
    }
}