using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system
{
    public class Customer : Person
    {
        private double balance;

        public Customer(int id, string username, string password, double balance = 0) : base(id, username, password)
        {
            this.balance = balance;
        }

        public double Balance { get => balance; }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > balance)
            {
                return false;
            }
            else
            {
                balance -= amount;
                return true;
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your balance is {balance:F2} DKK.");
        }

        public void CreateAccount()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            string[] lines = File.ReadAllLines("accounts.txt");
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields[0] == username)
                {
                    Console.WriteLine("Account already exists with this username.");
                    return;
                }
            }

            Random random = new Random();
            int id = random.Next(1000, 10000);

            Customer customer = new Customer(id, username, password);
            using (StreamWriter writer = File.AppendText("accounts.txt"))
            {
                writer.WriteLine($"{username},{password},{customer.Balance}");
            }

            Console.WriteLine("Account created successfully.");
        }
    }
}
