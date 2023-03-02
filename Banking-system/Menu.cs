using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system
{
    internal class Menu
    {
        public Menu()
        {
            while (true)
            {
                MainMenu();
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n\n(1) Are you (c)ustomer or are you (e)mployee?");

            var v = Console.ReadKey(true);
            switch (v.KeyChar)
            {
                case 'c':
                    Customer customer = new Customer(1, "momo", "momo");
                   
                    break;
                case 'e':
                    Employee employee = new Employee(1, "momo" , "momo" );
                    employee.EmployeeChoice();
                    break;
                default:
                    break;
            }
        }
    }
}
