using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class LoyalProg
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler? Notify;

        public event AccountHandler? TakeNotify;
        public event AccountHandler? PutNotify;


        AccountHandler? notify;
        public event AccountHandler? NotifyWithManage
        {
            add
            {
                notify += value;
                //Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                notify -= value;
                //Console.WriteLine($"{value.Method.Name} удален");
            }
        }

        public void PutPoints(Person person)
        {
        
            PutNotify += DisplayGreenMessage;
          

            //Console.WriteLine($"Количесвто бонусов после операций:{person.CalculatePoints(person)}");

            //Console.WriteLine($"Сумма к оплате:{person.Check}");
            Notify?.Invoke($"Количесвто бонусов после операций:{person.CalculatePoints(person)}");
            PutNotify?.Invoke($"Количесвто бонусов после операций:{person.CalculatePoints(person)}");

            notify?.Invoke($"Количесвто бонусов после операций:{person.CalculatePoints(person)}");
         

        }

        public void TakePoints(Person person)
        {
            var list0 = new List<string>();
            TakeNotify += DisplayRedMessage;
         
           
            Notify?.Invoke($"Количесвто бонусов после снятия и начисления новых:{person.CalculatePoints(person)}");
            TakeNotify?.Invoke($"Количесвто бонусов после снятия и начисления новых:{person.CalculatePoints(person)}");

            notify?.Invoke($"Количесвто бонусов после снятия и начисления новых:{person.CalculatePoints(person)}");


        }



        public static void Account_Notify(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

}

