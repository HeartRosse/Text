using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    public partial class MainWindow : Window
    {
        public List<FontWeight> fontWeights { get; } = new List<FontWeight>() {
            FontWeights.Black,FontWeights.Normal,
        };

        public ObservableCollection<FontStyle> fontStyles { get; } = new ObservableCollection<FontStyle>
        {
            FontStyles.Normal, FontStyles.Italic
        };
        public MainWindow()
        {
            InitializeComponent();
            cmbColor.ItemsSource = typeof(Colors).GetProperties();
            cmbBackground.ItemsSource = typeof(Colors).GetProperties();
            DataContext = this;
        }

        private void cmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbColor.SelectedItem as PropertyInfo).GetValue(null, null);
            txtText.Foreground = new SolidColorBrush(selectedColor);
        }

        private void cmbBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbBackground.SelectedItem as PropertyInfo).GetValue(null, null);
            this.Background = new SolidColorBrush(selectedColor);
        }
    }
}
