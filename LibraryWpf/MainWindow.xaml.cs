using System;
using System.Collections.Generic;
using System.Linq;
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
using SetProject;
namespace LibraryWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, MySet<int>> _sets = new Dictionary<string, MySet<int>>();
        public MainWindow()
        {
            InitializeComponent();
            _sets["A"] = new MySet<int> { };
            _sets["A"].AddRange(new[] { 1, 2, 3 });

            _sets["B"] = new MySet<int>();
            _sets["B"].AddRange(new[] { 3, 4, 5 });

            _sets["C"] = new MySet<int>();
            _sets["C"].AddRange(new[] { 5, 6, 7 });

            leftSet.ItemsSource = _sets.Keys;
            rightSet.ItemsSource = _sets.Keys;

            operation.ItemsSource = new List<string>
            {
            "Union",
            "Intersection",
            "Difference",
            "SymmetricDifference"
            };
        }

        private void leftSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (leftSet.SelectedItem == null) return;

            string key = leftSet.SelectedItem.ToString();
            leftMembers.ItemsSource = _sets[key];
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (leftSet.SelectedItem == null || rightSet.SelectedItem == null || operation.SelectedItem == null)
                return;

            var left = _sets[leftSet.SelectedItem.ToString()];
            var right = _sets[rightSet.SelectedItem.ToString()];
            var op = operation.SelectedItem.ToString();

            MySet<int> result = null;

            switch (op)
            {
                case "Union":
                    result = left.Union(right);
                    break;

                case "Intersection":
                    result = left.Intersection(right);
                    break;

                case "Difference":
                    result = left.Difference(right);
                    break;

                case "SymmetricDifference":
                    result = left.SymmetricDifference(right);
                    break;
            }

            resultSet.ItemsSource = result;
        }

        private void rightSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rightSet.SelectedItem == null) return;

            string key = rightSet.SelectedItem.ToString();
            rightMembers.ItemsSource = _sets[key];
        }
    }
}
