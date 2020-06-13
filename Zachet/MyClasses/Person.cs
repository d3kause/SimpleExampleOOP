using System;

namespace Zachet.MyClasses
{
	/// <summary>
	/// Класс Perosn, частично реализующий поведениеп персонажа в игре "Ужас Аркхэма". Реализует интерфейс IClonable для возможности клонирования объектов
	/// </summary>
	/// <seealso cref="System.ICloneable" />
	internal class Person : ICloneable
	{
		public readonly string name; // Поле для записи имени персонажа
		private bool isAlive = true; // Флаг того, "жив" ли персонаж
		private int health; // Здоровье
		private int brain; // Количество мозгов
		private int countMoney; // Количество денег
		private int countEvidence; // Количество улик

		private int speed; // Скорость
		private int stealth; // Скрытность
		private int power; // Сила
		private int will; // Воля
		private int knowledge; // Знания
		private int luck; // Удача
		public string Position { get { return $"({posX};{posY})"; } } // Свойство для получение позиции персонажа на карте
		private double posX = 0; // Позиция персонажа по х 
		private double posY = 0; // позиция персонажа по y

		public bool IsAlive { get { return isAlive; } } // Свойство для получения того, жив ли персонаж
		public int Health { get { return health; } } // Свойство возвращающее количество здоровья у персонажа
		public int Brain { get { return brain; } } // Свойство, возвращающее количество "Мозгов" у персонажа
		public int CountMoney { get { return countMoney; } } // Свойство, возвращающее количество денег у персонажа
		public int CountEvidence { get { return countEvidence; } } // Свойство, возвращающее количество улик у персонажа
		public int Speed { get { return speed; } } // Свойство, возвращающее скорость персонажа
		public int Stealth { get { return stealth; } } // Свойство, возвращающее скрытность персонажа
		public int Power { get { return power; } } // Свойство, возвращающее силу персонажа
		public int Will { get { return will; } }  // Свойство, возвращающее волю персонажа
		public int Knowledge { get { return knowledge; } } // Свойство, возвращающее "знания" персонажа
		public int Luck { get { return luck; } } // Свойство, возвращающее "удачу" персонажа

		// Конструктор персонажа с параметрами. Без параметрами конструктора быть не может, т. к. каждый перонаж - уникален.
		public Person(string name, int health, int brain, int countMoney, int countEvidence, int x, int y, int speed, int stealth, int power, int will, int knowledge, int luck)
		{
			this.name = name;
			this.health = health;
			this.brain = brain;
			this.countMoney = countMoney;
			this.countEvidence = countEvidence;
			posX = x;
			posY = y;
			this.speed = speed;
			this.stealth = stealth;
			this.power = power;
			this.will = will;
			this.knowledge = knowledge;
			this.luck = luck;
			Console.WriteLine($"Персонаж {name} появился на карте!");
		}

		~Person() // Деструктор, сообщающий о удалении персонажа с игрового поля
		{
			Console.WriteLine($"Персонаж {name} полностью удален с игрового поля!");
		}

		// Перегрузка бинарного оператора сложения. Добавляет здоровье персонажу
		public static Person operator +(Person p, int heal)
		{
			Person tmp = (Person)p.Clone(); // Клонируем объект Person
			tmp.GetDamage(-heal); // Отрицательный урон = лечение (добавляем клону здоровье)
			return tmp; // Возвращаем ссылку на новый объект Person
		}

		// Перегрузка бинарного оператора вычитания. Отнимает здоровье у персонажа
		public static Person operator -(Person p, int dmg)
		{
			Person tmp = (Person)p.Clone(); // Клонируем объект Person
			if (dmg > tmp.health) // Проверяем, есть ли у пермонажа достаточное количество здоровья
			{
				Console.WriteLine($"Игрок {tmp.name} потерял слишком много здоровья и умер!");
				return null; // Если игрок умер - возвращаем пустую ссылку
			}
			else
			{
				tmp.GetDamage(dmg); // Отнимаем здоровье у игрока
				return tmp; // Возвращаем ссылку на новый объект Person
			}
		}

		// Перегрузка унарного оператора ++. Прибаляет персонажу 1 ед. здоровья
		public static Person operator ++(Person p)
		{
			p.GetDamage(-1);
			return p;
		}

		// Перегрузка унарного оператоа --. Отнимает у персонажа  здоровья
		public static Person operator --(Person p)
		{
			p.GetDamage(1);
			return p;
		}

		// Метод, реализующий получение урона персонажем
		public bool GetDamage(int dmg)
		{
			health -= dmg; // Отнимаем урон от текущего здоровья персонажа
			if (health <= 0) // Если итоговое значение здоровья отрицательное 
			{
				Console.WriteLine($"Герой {name} был убит монстром!"); // Сообщаем о смерти персонажа
				return false; // Возвращаем false
			}
			else
			{
				return true; // Если игрок выжил после получения урона - возвращаем true
			}
		}

		// Метод, аналогичный методу GetDamage, с тем отличием, что ущерб наностится "мозгам" персонажа
		public bool GetBrainDamage(int dmg)
		{
			brain -= dmg;
			if (health <= 0)
			{
				Console.WriteLine($"Герой {name} был до смерти напуган монстром!");
				return false;
			}
			else
			{
				return true;
			}
		}

		// Метод, реализующий перемещение персонажа по карте. Изменяет его координаты х и у 
		public void Walk(int x, int y)
		{
			posX += x;
			posY += y;
		}

		// Метод, реализующий возможность персонажа напасть на кого-либо
		public void StartFight(object obj)
		{
			AbstractMonster m = obj as AbstractMonster;  // Создаем новую переменую типа AbstractMonster и записываем в неё ссылку на приведенный к классу AM объект obj
			if (m != null) // Если приведение успешно (m ссылается на объект)
			{
				Console.WriteLine($"Игрок {name} атаковал монстра {m.Name}!"); // Сообщаем о начале драки
				int dmg = m.StartFight(this); // Вызываем метод сражения персонажа с монстром
				if (dmg == 0) // Если итоговый урон равен нулю - персонаж победил в схватке
				{
					Console.WriteLine($"Монстр {m.Name} был повержен игроком {name}!");
				}
				else if (dmg < health) // Если урон не 0, но меньше текущего здоровья персонажа - персонаж выжил, но позорно убежал
				{
					Console.WriteLine($"Игрок {name} не смог победить монстра {m.Name} и сбежал!");
					health -= dmg;
					return;
				}
				else // Иначе - игрок умирает
				{
					Console.WriteLine($"Игрок {name} был убит монстром {m.Name}!");
					isAlive = false;
				}
			}
		}

		public object Clone() // Реализация интерфейса IClonable
		{
			return MemberwiseClone();
		}
	}
}
