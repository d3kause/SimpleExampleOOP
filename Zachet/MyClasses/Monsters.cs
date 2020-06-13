using System;

namespace Zachet.MyClasses
{
	internal class Rabbit : AbstractMonster // Создание монстра "Кролик", наследника класса "AbstartMonster"
	{
		public Rabbit() // Конструктор без параметров
		{
			name = "Notname";
			power = 2;
			fear = 2;
			health = 3;
			type = 1;
			Console.WriteLine($"На карте появился монстр {GetType()}!");
			Appear();
		}
		public Rabbit(string name, int power, int fear, int health) // Конструктор с параметрами
		{
			this.name = name;
			this.power = power;
			this.fear = fear;
			this.health = health;
			type = 1;
			Console.WriteLine($"На карте появился монстр {GetType()}!");
			Appear();
		}

		~Rabbit() // Деструктор, сообщающий о уходе монстра
		{
			Console.WriteLine($"{GetType()} {name} полностью ушел с игрового поля!");
		}

		public override void ShowInfo() // Переопределенный метод выводящий общую информацию о монстре на экран
		{
			Console.WriteLine("Кролик это практически безобидный монстр. Он не обладает иммунитетом к какому-либо урону и имеет скудные характеристики.\n" +
				"Тем не менее, на начальном этапе все равно нужно быть осторожным в борьбе с ним!");
		}
	}

	internal class Wolf : AbstractMonster // Создание класса Wolf (волк), наследника класса AbstractMonster
	{
		public Wolf() // Конструктор без параметров
		{
			name = "Notname";
			power = 5;
			fear = 3;
			health = 7;
			type = 2;
			Console.WriteLine($"На карте появился монстр {GetType()}!");
			Appear();
		}

		public Wolf(string name, int power, int fear, int health) // Конструктор с параметрами
		{
			this.name = name;
			this.power = power;
			this.fear = fear;
			this.health = health;
			type = 2;
			Console.WriteLine($"На карте появился монстр {GetType()}!");
			Appear();
		}
		~Wolf() // Деструктор, сообщающий о уходе монстра 
		{
			Console.WriteLine($"{GetType()} {name} полностью ушел с игрового поля!");
		}

		public override void ShowInfo() // Переопределенный метод выводящий общую информацию о монстре на экран
		{
			Console.WriteLine("Волк это сильный монстр из леса. Чтобы сразиться с ним нужно иметь достаточное количество артефактов. " +
				$"Если игрок потерпит поражение в борьбе с волком, он, скорее всего, будет повержен, ведь у волка {power} урона!");
		}
	}
}
