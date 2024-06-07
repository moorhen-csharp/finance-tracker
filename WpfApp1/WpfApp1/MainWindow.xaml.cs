using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
        public MainWindow()
        {
            InitializeComponent();
            lvTransactions.ItemsSource = transactions;
        }
        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text) || !decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Введите корректные данные.");
                return;
            }

            transactions.Add(new Transaction { Description = txtDescription.Text, Amount = amount });
            txtDescription.Clear();
            txtAmount.Clear();
        }
    }

    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
    

