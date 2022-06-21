using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Person:LoyalProg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int LoyaltyCardNumber { get; set; }
        public double Points { get; set; }
        public string Order { get; set; }
        public double Check { get; set; }
        public string Operation { get; set; }
         public double CalculatePoints(Person person)
        {
            return person.Check/10.0;


        }
        List <string> list0 = new List<string>();   
        public void Change(string operation,Person person1, List<string> order)
        {
            var file = "Person.csv";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

            var lines = File.ReadAllLines(file, encoding);
            var persons = new Person[lines.Length - 1];
            var listI = new List<int>();
            for (int z = 1; z < lines.Length; z++)
            {
                var splits = lines[z].Split(';');

                var person = new Person();
                person.Id = Convert.ToInt32(splits[0]);
                person.Name = splits[1];
                person.Number = splits[2];
                person.LoyaltyCardNumber = Convert.ToInt32(splits[3]);
                person.Points = Convert.ToDouble(splits[4]);
                person.Order = splits[5].ToString();
                person.Check = Convert.ToDouble(splits[6]);
                person.Operation = splits[7];
                persons[z - 1] = person;
                listI.Add(Convert.ToInt32(splits[0]));

            }
            bool BOOL1 = true;
       
            if (operation == "Создать")
            {
                
                using (StreamWriter writer = new StreamWriter(file, true, encoding))
                {
                    
                        var newrecord = new List<Person>()
                        {
                        new Person {Id=listI.Count+1,Name=person1.Name, Number=person1.Number, LoyaltyCardNumber=person1.LoyaltyCardNumber, Points=CalculatePoints(person1), Order=order.ToString(), Check=person1.Check, Operation = "Пополнение"}
                       };
                        foreach (var y in newrecord)
                        {
                            writer.WriteLine(y.ToExcel());
                        }

                    Console.WriteLine($"Сумма к оплате:{person1.Check}");
                    
                }
                PutPoints(person1);
               
            }
            if (operation == "Найти")
            {
                Console.WriteLine("Желаете оплатить покупку баллами?");
                string otv = Console.ReadLine().ToUpper();
                if (otv == "ДА")
                {
                    Change("Снять баллы", person1, list0);

                }
                else
                {
                    var SS1 = from n in persons
                             where n.LoyaltyCardNumber == person1.LoyaltyCardNumber
                             select n;
                    var SS = SS1.TakeLast(1);
                    using (StreamWriter writer = new StreamWriter(file, true, encoding))
                    {
                        foreach (var x in SS)
                        {
                            var newrecord = new List<Person>()
                        {
                        new Person {Id=listI.Count+1,Name=x.Name, Number=x.Number, LoyaltyCardNumber=x.LoyaltyCardNumber, Points=x.Points+CalculatePoints(person1), Order=order.ToString(), Check=person1.Check,Operation =Operation = "Пополнение"}
                        };
                            foreach (var y in newrecord)
                            {
                                writer.WriteLine(y.ToExcel());
                            }
                          
                        }

                    }
                    Console.WriteLine($"Сумма к оплате:{person1.Check}") ;
                    PutPoints(person1);
                    

                }

            }
            if (operation == "Снять баллы")
            {
                double p = 0;
                var SS1 = from n in persons
                         where n.LoyaltyCardNumber == person1.LoyaltyCardNumber
                         select n;
                var SS = SS1.TakeLast(1);
                foreach (var x in SS)
                {
                    if (ICheck.Check1(x) == false)
                    {
                        BOOL1 = false ;
                    }
                   
                }
            
         
        
                if (BOOL1 = false)
                {

                    Console.WriteLine("Не все условия программы лояльности соблюдены. Оплата баллами недоступна.");
                    Change("Найти", person1, list0);


                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(file, true, encoding))
                    {
                        foreach (var x in SS)
                        {
                            var newrecord = new List<Person>()
                        {
                        new Person {Id=listI.Count+1,Name=x.Name, Number=x.Number, LoyaltyCardNumber=x.LoyaltyCardNumber, Points=CalculatePoints(person1), Order=order.ToString(), Check=person1.Check-x.Points,Operation =Operation = "Снятие"}
                        };
                            foreach (var y in newrecord)
                            {
                                writer.WriteLine(y.ToExcel());
                            }
                            p = x.Points;
                        }
                    }
                    Console.WriteLine($"Сумма заказа без скидки:{person1.Check}");
                    Console.WriteLine($"Сумма заказа со скидкой:{person1.Check - p}");
                   
                    TakePoints(person1);
                }

}           }


            
        
        public string ToExcel()
        {
            return $"{Id};{Name};{Number};{LoyaltyCardNumber};{Points};{Order};{Check};{Operation}";
        }

    }
}

    


