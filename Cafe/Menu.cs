using System.Text;

namespace Cafe
{
    public class Menu 
    {
        public string Position { get; set; }
        public string Characteristic { get; set; }
        public string Volume { get; set; }
        public int Calories { get; set; }
        public int InStock { get; set; }
        public int Price { get; set; }

        public void Ord(string operation, List <string> position, Person person)
        {
            var file = "Menu.csv";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

           
            var lines = File.ReadAllLines(file, encoding);
            var menus = new Menu[lines.Length - 1];
            for (int z = 1; z < lines.Length; z++)
            {
                var splits = lines[z].Split(';');

                var menu = new Menu();
                menu.Position = splits[0];
                menu.Characteristic = splits[1];
                menu.Volume = splits[2];
                menu.Calories = Convert.ToInt32(splits[3]);
                menu.Price = Convert.ToInt32(splits[4]);
                menus[z - 1] = menu;
            }
            if  (operation=="Вывести")
            {
                for (int i = 0;  i  <  menus.Length;  i++)
                {
                    Console.WriteLine(menus[i].ToString());
                }

            }
            if (operation == "Заказ сущ акк")
            {
                var selectfood1 = new List<string>();
                Console.WriteLine("Ваш заказ:");
                var selectfood = from p in menus
                                 from x in position
                                 where p.Position == x
                                 select p;
               
                foreach (var x in selectfood)
                {
                    Console.WriteLine(x.Position);
                    selectfood1.Add(x.Position);
                    person.Check += x.Price;
                }
                //var selectfood2 = selectfood1.ToString();
                Console.WriteLine();

                person.Change("Найти", person, selectfood1);
                
            }
            if (operation == "Заказ нового акк")
            {var selectfood1 = new List<string>();
                Console.WriteLine("Ваш заказ:");
                var selectfood = from p in menus
                                 from x in position
                                 where p.Position == x
                                 select p;
                
                foreach (var x in selectfood)
                {
                    Console.WriteLine(x.Position);
                    selectfood1.Add(x.Position);
                    person.Check += x.Price;

                }
               
                

                Console.WriteLine();
                //Console.WriteLine("Сумма заказа:");
                //Console.WriteLine(person.Check);
                person.Change("Создать",person,position);

            }
        }
            public override string ToString()
        {
            return $"Позиция: {Position}\n Характеристика: {Characteristic}\n  Объём: {Volume}\n Каллории: {Calories}\n В наличии: {InStock}\n Цена: {Price}\n";
        }
       
    }
  }
