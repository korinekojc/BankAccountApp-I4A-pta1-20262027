using BankAccountApp.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankAccountApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankAccount account1;
        BankAccount account2;


        public MainWindow()
        {
            InitializeComponent();

            account1 =
                new StudentAccount(
                    "Adam Novák",
                    "001",
                    5000,
                    2000);

            account2 =
                new SavingsAccount(
                    "Eva Malá",
                    "002",
                    12000,
                    3.5);

            ShowAccounts();
        }


        private string GetSelectedAccountType(
            ComboBox comboBox)
        {
            ComboBoxItem item =
                (ComboBoxItem)comboBox.SelectedItem;

            return item.Content.ToString();
        }


        private void ShowAccounts()
        {
            ShowAccount1();
            ShowAccount2();
        }


        private void ShowAccount1()
        {
            TbTypeInfo1.Text =
                "Typ: " + account1.GetAccountType();

            TbOwnerInfo1.Text =
                "Majitel: " + account1.Owner;

            TbNumberInfo1.Text =
                "Číslo účtu: " + account1.AccountNumber;

            TbBalanceInfo1.Text =
                "Zůstatek: " + account1.Balance + " Kč";

            TbFeeInfo1.Text =
                "Měsíční poplatek: "
                + account1.GetMonthlyFee()
                + " Kč";

            TbInterestInfo1.Text =
                "Úrok za rok: "
                + account1.CalculateInterest()
                + " Kč";

            TbAvailableFunds1.Text =
                "Disponibilní prostředky: "
                + account1.GetAvailableFunds()
                + " Kč";
        }


        private void ShowAccount2()
        {
            TbTypeInfo2.Text =
                "Typ: " + account2.GetAccountType();

            TbOwnerInfo2.Text =
                "Majitel: " + account2.Owner;

            TbNumberInfo2.Text =
                "Číslo účtu: " + account2.AccountNumber;

            TbBalanceInfo2.Text =
                "Zůstatek: " + account2.Balance + " Kč";

            TbFeeInfo2.Text =
                "Měsíční poplatek: "
                + account2.GetMonthlyFee()
                + " Kč";

            TbInterestInfo2.Text =
                "Úrok za rok: "
                + account2.CalculateInterest()
                + " Kč";

            TbAvailableFunds2.Text =
                "Disponibilní prostředky: "
                + account2.GetAvailableFunds()
                + " Kč";
        }


        private void BtCreate1_Click(
            object sender,
            RoutedEventArgs e)
        {
            string type =
                GetSelectedAccountType(
                    CbAccountType1);

            string owner =
                TbOwner1.Text;

            string accountNumber =
                TbAccountNumber1.Text;

            double balance =
                double.Parse(
                    TbStartBalance1.Text);


            if (type == "Spořicí účet")
            {
                double interestRate =
                    double.Parse(
                        TbInterestRate1.Text);

                account1 =
                    new SavingsAccount(
                        owner,
                        accountNumber,
                        balance,
                        interestRate);
            }
            else if (type == "Studentský účet")
            {
                double overdraftLimit =
                    double.Parse(
                        TbOverdraftLimit1.Text);

                account1 =
                    new StudentAccount(
                        owner,
                        accountNumber,
                        balance,
                        overdraftLimit);
            }
            else
            {
                account1 =
                    new StandardAccount(
                        owner,
                        accountNumber,
                        balance);
            }

            TbOperationInfo1.Text =
                "Účet byl vytvořen.";

            ShowAccounts();
        }


        private void BtCreate2_Click(
            object sender,
            RoutedEventArgs e)
        {
            string type =
                GetSelectedAccountType(
                    CbAccountType2);

            string owner =
                TbOwner2.Text;

            string accountNumber =
                TbAccountNumber2.Text;

            double balance =
                double.Parse(
                    TbStartBalance2.Text);


            if (type == "Spořicí účet")
            {
                double interestRate =
                    double.Parse(
                        TbInterestRate2.Text);

                account2 =
                    new SavingsAccount(
                        owner,
                        accountNumber,
                        balance,
                        interestRate);
            }
            else if (type == "Studentský účet")
            {
                double overdraftLimit =
                    double.Parse(
                        TbOverdraftLimit2.Text);

                account2 =
                    new StudentAccount(
                        owner,
                        accountNumber,
                        balance,
                        overdraftLimit);
            }
            else
            {
                account2 =
                    new StandardAccount(
                        owner,
                        accountNumber,
                        balance);
            }

            TbOperationInfo2.Text =
                "Účet byl vytvořen.";

            ShowAccounts();
        }


        private void BtDeposit1_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(TbAmount1.Text);

            bool result =
                account1.Deposit(amount);

            TbOperationInfo1.Text =
                result
                ? "Vklad byl proveden."
                : "Vklad nelze provést.";

            ShowAccounts();
        }


        private void BtWithdraw1_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(TbAmount1.Text);

            bool result =
                account1.Withdraw(amount);

            TbOperationInfo1.Text =
                result
                ? "Výběr byl proveden."
                : "Výběr nelze provést.";

            ShowAccounts();
        }


        private void BtDeposit2_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(TbAmount2.Text);

            bool result =
                account2.Deposit(amount);

            TbOperationInfo2.Text =
                result
                ? "Vklad byl proveden."
                : "Vklad nelze provést.";

            ShowAccounts();
        }


        private void BtWithdraw2_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(TbAmount2.Text);

            bool result =
                account2.Withdraw(amount);

            TbOperationInfo2.Text =
                result
                ? "Výběr byl proveden."
                : "Výběr nelze provést.";

            ShowAccounts();
        }


        private void BtTransfer1To2_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(
                    TbTransferAmount.Text);

            bool result =
                account1.TransferTo(
                    account2,
                    amount);

            TbTransferInfo.Text =
                result
                ? "Převod byl proveden."
                : "Převod nelze provést.";

            ShowAccounts();
        }


        private void BtTransfer2To1_Click(
            object sender,
            RoutedEventArgs e)
        {
            double amount =
                double.Parse(
                    TbTransferAmount.Text);

            bool result =
                account2.TransferTo(
                    account1,
                    amount);

            TbTransferInfo.Text =
                result
                ? "Převod byl proveden."
                : "Převod nelze provést.";

            ShowAccounts();
        }
    }
}