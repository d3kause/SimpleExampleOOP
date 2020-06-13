using System;
using System.Collections.Generic;
using Zachet.MyClasses;

namespace Zachet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //    Создание списка типа AbstractMonster для записи в него объектов-наследников
            List<AbstractMonster> monsters = new List<AbstractMonster>
            {
                // Демонстраци работы конструкторов и деструкторов, а также свойств и методов
                new Rabbit(), // Добавление нового монстра-кролика в список с помощью конструктора без параметров
                new Rabbit("Jerry", 1, 3, 2), // Добавление нового монстра-кролика в список с помощью конструктора с параметрами
                new Wolf(),
                new Wolf("Herrald", 7, 7, 12)
            };
            foreach (AbstractMonster a in monsters)
            {
                Console.WriteLine($"\nПроверка монстра {a.Name} с типом {a.Type}");
                a.Appear(); // Вызов метода "появления монстра"
                Console.WriteLine("Монстра видно?: " + a.IsVisible);
                a.Hide(); // Вызов метода "Спрятаться" у монстра
                Console.WriteLine("Монстра видно?: " + a.IsVisible);
                Console.WriteLine("Общая информация о монстре:");
                a.ShowInfo(); // Вывод информации о монстре
            }


            // Проверка реализации интерфейса IComparable для класса AbstractMonster
            Console.WriteLine("\nПорядок монстров до сортировки");
            foreach (AbstractMonster a in monsters)
            {
                Console.WriteLine($"Монстр {a.Name} с типом {a.Type}");
            }

            monsters.Sort(); // Вызываем метод сортировки
            Console.WriteLine("\nПорядок монстров после сортировки");
            foreach (AbstractMonster a in monsters)
            {
                Console.WriteLine($"Монстр {a.Name} с типом {a.Type}");
            }


            // Проверка перегрузки операций --, ++, +, - для класса Person
            Console.WriteLine("\nПроверка перегрузки операций");
            Person p = new Person("Ваня", 5, 5, 0, 2, 1, 1, 7, 3, 4, 2, 4, 6);
            Console.WriteLine("Здоровье персонажа p: " + p.Health);
            p++;
            Console.WriteLine("Здоровье персонажа p (++): " + p.Health);
            p += 5;
            Console.WriteLine("Здоровье персонажа p (+=10): " + p.Health);
            p += 10;
            Console.WriteLine("Здоровье персонажа p (+=10): " + p.Health);
            p -= 16;
            Console.WriteLine("Здоровье персонажа p (-=16): " + p.Health);
            p -= 22;
            Console.WriteLine("Здоровье персонажа p (-=20):\n " + p?.Health);

            // Демонстрация методов взаимодействия классов для организации битвы персонажа с монстрами
            p = new Person("Ваня", 5, 5, 0, 2, 1, 1, 7, 3, 4, 2, 4, 6);
            p.StartFight(monsters[1]);
            p.StartFight(monsters[2]);

            // Демонстрация использования делегата, служащего для изменения стиля вывода на консоль
            Console.WriteLine("\nДемонстрация использования делегатов:");
            AbstractMonster r = monsters[1];
            Console.WriteLine("\nДобавляем красный вывод");
            r.Notify += AbstractMonster.ColoredOutput;
            r.Hide();
            Console.WriteLine("\nОтключаем стандартный вывод:");
            r.Notify -= AbstractMonster.DefaultOutput;
            r.Hide();
            Console.WriteLine("\nОтключаем красный вывод");
            r.Notify -= AbstractMonster.ColoredOutput;
            r.Hide();
            Console.ReadKey();
        }
    }
}
