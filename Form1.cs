using System.Drawing.Imaging.Effects;
using System.Reflection.Metadata.Ecma335;

namespace BankAccountsApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(OwnerTxt.Text))
            {
                //MessageBox.Show("Yeu cau nhap ten vao!");
                return;
            }

            if(InterestRateNum.Value > 0) BankAccounts.Add(new SavingAccount(OwnerTxt.Text, AmountNum.Value, InterestRateNum.Value));
            else BankAccounts.Add(new BankAccount(OwnerTxt.Text, AmountNum.Value));

            // MessageBox.Show($"Khach hang vua tao tai khoan co ten la {bankAccount.Owner}, so tai khoan la \"{bankAccount.AccountNumber}\" co so du la {bankAccount.Balances} dong!");
            RefreshGrid();
            OwnerTxt.Text = string.Empty;
            AmountNum.Value = 0;
            InterestRateNum.Value = 0;
        }

        private void RefreshGrid()
        {
            BankAccountsGrid.DataSource = null;
            BankAccountsGrid.DataSource = BankAccounts;
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountsGrid.SelectedRows.Count == 1)
            {
                BankAccount SelectedBankAccount = BankAccountsGrid.SelectedRows[0].DataBoundItem as BankAccount;
                string message = SelectedBankAccount.Deposit(AmountNum.Value);
                // MessageBox.Show($"{SelectedBankAccount.Owner} vua nap vao tai khoan \"{SelectedBankAccount.AccountNumber}\" {AmountNum.Value} dong!");
                RefreshGrid();
                AmountNum.Value = 0;
                MessageBox.Show(message);
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if(BankAccountsGrid.SelectedRows.Count == 1)
            {
                BankAccount SelectedBankAccount = BankAccountsGrid.SelectedRows[0].DataBoundItem as BankAccount;
                string message = SelectedBankAccount.Withdraw(AmountNum.Value);
                // MessageBox.Show($"{SelectedBankAccount.Owner} vua rut khoai tai khoan \"{SelectedBankAccount.AccountNumber}\" {AmountNum.Value} dong!");
                RefreshGrid();
                AmountNum.Value = 0;
                MessageBox.Show(message);
            }
        }
    }
}
