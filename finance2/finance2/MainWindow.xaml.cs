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

namespace finance2
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

            var selectedWallet = cbWallets.SelectedItem as ComboBoxItem;
            var walletName = selectedWallet?.Content.ToString() ?? "Неизвестно";

            transactions.Add(new Transaction { Description = txtDescription.Text, Amount = amount, Wallet = walletName });
            txtDescription.Clear();
            txtAmount.Clear();
            UpdateTotalBalance();
        }
        private void UpdateTotalBalance()
        {
            decimal totalBalance = transactions.Sum(t => t.Amount);
            lblTotalBalance.Content = $"Общая сумма: {totalBalance} руб.";
        }
    }

    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Wallet { get; set; }
    }
}