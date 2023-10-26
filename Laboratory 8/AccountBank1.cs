using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_8
{
    enum AccountType
    {
        Current,
        Savings
    }
    internal class AccountBank
    {
        private static int accountCounter = 1000;// статическая переменная для генерации уникального номера счета
        private int AccountNumber;
        public double Balance;
        private AccountType AccountType;
        public AccountBank()
        {
            AccountNumber = accountCounter;
            accountCounter++;
            Balance = 0;
            AccountType = AccountType.Current;
        }
        public void SetData(int number, double balance, AccountType type)
        {
            AccountNumber = number;
            Balance = balance;
            AccountType = type;
        }
        public int GetAccountNumber()
        {
            return AccountNumber;
        }
        public double GetBalance()
        {
            return Balance;
        }
        public AccountType GetAccountType()
        {
            return AccountType;
        }
        public void SetBalance(double newBalance)
        {
            Balance = newBalance;
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Депозит на {amount} выполнен.Новый баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Ошибка!Увеличьте сумму для депозита.");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Списание {amount} выполнено.Новый баланс: {Balance}");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Ошибка!Увеличьте сумму для списания.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
        }

        public void PrintAccount()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {AccountType}");
        }
        public void TransferMoney(AccountBank destinationAccount, double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount; // уменьшаем баланс текущего счета
                destinationAccount.Balance += amount; // увеличиваем баланс счета-получателя
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счёте!");
            }
        }
    }
} 
