using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance (Mr. Roman Abramovich) is ${0}", ba.Balance);
            Console.ReadLine();

            BankAccount dm = new BankAccount("Ms. Daria Mozgunova", 100.00);

            dm.Credit(50.55);
            dm.Debit(76.55);
            Console.WriteLine("Current balance (Ms. Daria Mozgunova) is ${0}", dm.Balance);
            Console.ReadLine();

            BankAccount oa = new BankAccount("Ms. Olga Andreeva", 25.55);

            oa.Credit(5.55);
            oa.Debit(15.00);
            Console.WriteLine("Current balance (Ms. Olga Andreeva) is ${0}", oa.Balance);
            Console.ReadLine();
        }
    }
}
