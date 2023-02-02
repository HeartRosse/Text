using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Test
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<FontWeight> fontWeights { get; } = new ObservableCollection<FontWeight>() {
            FontWeights.Black,
            FontWeights.Normal
        };

        public ObservableCollection<FontStyle> fontStyles { get; } = new ObservableCollection<FontStyle>
        {
            FontStyles.Normal, 
            FontStyles.Italic
        };

        public ObservableCollection<TextAlignment> textAlignments { get; } = new ObservableCollection<TextAlignment>
        {
            TextAlignment.Center,
            TextAlignment.Left,
            TextAlignment.Right, 
            TextAlignment.Justify
        };

        public ObservableCollection<TextDecorationCollection> textDecorations { get;} = new ObservableCollection<TextDecorationCollection>()
        {
            
            TextDecorations.Underline,
            TextDecorations.OverLine,
            TextDecorations.Strikethrough,
            TextDecorations.Baseline,
            
        };
        public MainWindow()
        {
            InitializeComponent();
            cmbTextDecoration.ItemsSource = textDecorations;
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
            txtText.Background = new SolidColorBrush(selectedColor);
        }
    }
}
