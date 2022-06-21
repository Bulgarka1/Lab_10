using Cafe;
using System.Text;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.IO;

Console.WriteLine("Добрый день! Добро пожаловать в кофейню.");
Console.WriteLine();
Menu menu = new Menu(); 
Person person = new Person();
List<string> ts = new List<string>();
menu.Ord("Вывести", ts,person);
//Console.WriteLine("Сделать заказ(1)--Выйти(2)");
//int str=Convert.ToInt32(Console.ReadLine());

Random r = new Random();
List<string> ord = new List<string>(); 

Console.WriteLine("У Вас уже есть Карта Лояльности?");
string str = Console.ReadLine().ToUpper(); 

if (str == "ДА")
{ 
    Console.WriteLine("Введите номер карты");
    person.LoyaltyCardNumber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите название позиции,которую желаете заказать...");
    var food = Console.ReadLine();
    ord.Add(food);


    Console.WriteLine("Хотите заказать еще?");
    string answ = Console.ReadLine().ToUpper();
    while (answ == "ДА")
    {
        Console.WriteLine("Введите название позиции,которую желаете заказать...");
        food = Console.ReadLine();
        ord.Add(food);

        Console.WriteLine("Хотите заказать еще?");
        answ = Console.ReadLine().ToUpper();
    }

    menu.Ord("Заказ сущ акк",ord,person);
 
}
else
{
    Console.WriteLine("Введите ФИО");
    person.Name = Console.ReadLine();

    Console.WriteLine("Введите номер телефона");
    person.Number = Console.ReadLine();

    Console.WriteLine("Номер Вашей карты:");
    person.LoyaltyCardNumber = r.Next(10000,99999);
    Console.WriteLine(person.LoyaltyCardNumber);

    Console.WriteLine("Введите название позиции,которую желаете заказать...");
    var food = Console.ReadLine();
    ord.Add(food);


    Console.WriteLine("Хотите заказать еще?");
    string answ = Console.ReadLine().ToUpper();
    while (answ == "ДА")
    {
        Console.WriteLine("Введите название позиции,которую желаете заказать...");
        food = Console.ReadLine();
        ord.Add(food);

        Console.WriteLine("Хотите заказать еще?");
        answ = Console.ReadLine().ToUpper();

    }
    menu.Ord("Заказ нового акк", ord,person);

}





//if (str == 2)
//{

    
//        Console.WriteLine("До свидания!");
//        Environment.Exit(0);
   
//}

