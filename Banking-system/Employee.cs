using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system
{
    public class Employee : Person
    {
        public Employee(int id, string username, string password) : base(id, username, password)
        {

        }

        public void ViewAccounts()
        {
            string[] lines = File.ReadAllLines("accounts.txt");
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                Console.WriteLine($"Username: {fields[0]}, Balance: {fields[2]} DKK");
            }
        }

        public void AddCustomer()
        {
            Console.Write("Enter the customer's username: ");
            string username = Console.ReadLine();

            Console.Write("Enter the customer's password: ");
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

            Console.WriteLine("Customer account created successfully.");
        }
        public void EmployeeChoice()
        {
            Console.WriteLine("Add new customer(1) \n View Accounts(2)");
            var v = Console.ReadKey(true);
            switch (v.KeyChar)
            {
                case '1':
                    AddCustomer();

                    break;
                case '2':
                    ViewAccounts();

                    break;
                default:
                    break;
            }
        }



    }
}
