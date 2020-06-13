using System;

namespace Zachet.MyClasses
{
	/// <summary>
	/// Абстрактный класс AbstractMonster реализующий методы, поля, свойства всех монстров в игре, а также интерфейсы IMonster и IComparable
	/// необходимый для сравнения объектов.
	/// </summary>
	internal abstract class AbstractMonster : IMonster, IComparable<AbstractMonster>
	{
		public delegate void MonsterHandler(string message); // Создаем делегат для методов с сигнатурой (string)
		public event MonsterHandler Notify = DefaultOutput; // Определяем событие для вызова этого делегата

		protected string name; // Поле для записи имени монстра
		public string Name { get { return name; } } // Свойство для получения имени монстра
		protected int health; // Поле, определяющее текущее здоровье монстра
		protected int power; // Поле, определяющее текущую силу монстра
		protected int fear; // Поле, определяющее текущую "страшность" монстра
		protected int type; // Поле, определяющее тип монстра

		public int Type { get { return type; } }  // Свойство для получения типа монстра
		public string Position { get { return $"({posX};{posY})"; } } // Свойство для получения позиции монстра
		protected double posX = 0; // Позиция монстра по x
		protected double posY = 0; // Позиция монстра по y

		public bool IsVisible { get; }  // Свойство для получения того, находится ли монстр на карте
		protected bool isVisible = true; // Поле определяющее видимость монстра на карте
		public abstract void ShowInfo(); // Абстрактный метод вывода общей информации о монстре на экран

		// Метод вывода информации на экран красным цветом
		public static void ColoredOutput(string message)
		{
			// Устанавливаем красный цвет символов
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message); // Выводим сообщение на  экран консоли
										// Сбрасываем настройки цвета
			Console.ResetColor();
		}

		// Метод стандартного вывода на экран
		public static void DefaultOutput(string message)
		{
			Console.WriteLine(message);
		}

		// Метод "появления" монстра. Меняет значение переменной isVisible и выводит соответствующее сообщение
		public void Appear()
		{
			isVisible = true;
			Notify?.Invoke($"Монстр {name} с типом {type} появился в локации ({posX},{posY})!"); // Вызов события Notify с проверкой на null
		}

		// Метод, который "прячет" монстра в пул. Меняет значение переменной isVisible и выводит соответствующее сообщение
		public void Hide()
		{
			isVisible = false;
			Notify?.Invoke($"Монстр ушел из локации ({posX},{posY})!"); // Вызов события Notify с проверкой на null
		}

		// Метод реализующий возможность монстра атаковать персонажей
		public void Attack(Person p)
		{
			p.StartFight(this); // Вызов метода драки
		}

		// Метод, реализующий сражение персонажа и монстра
		public int StartFight(Person p)
		{
			int summDmg = 0; // Переменная для записи общего урона, который получает пермсонаж
			if (CheckLuck(p) == false)
			{
				summDmg += fear; // Если проверка удачи не была пройдена - прибавляем урон, равный "ужасности" монстра
			}

			if (CheckPower(p) == false)
			{
				summDmg += power; // Если проверка силы не была пройдена - прибавляем урон, равный силе монстра
			}

			return summDmg; // Возвращаем суммарный урон вызывающему объекту - персонажу
		}

		// Метод, реализующий перемещение монстра. Меняет его х и у координаты
		public void Walk(int x, int y)
		{
			posX += x;
			posY += y;
		}

		// Метод проверки удачи при битве с монстров
		public bool CheckLuck(Person t)
		{
			return Game.Dice(fear, t.Will); // Вызывает статический метод Dice из класса Game, имитирующий подбрасывание кубиков.
		}

		// Метод проверки силы при битве с монстром
		public bool CheckPower(Person t)
		{
			return Game.Dice(power, t.Power); // Вызывает статический метод Dice из класса Game, имитирующий подбрасывание кубиков.
		}

		public int CompareTo(AbstractMonster obj) // Реализация интерфейса IComparable (сравнение монстров по суммарному количеству ХП и силы)
		{
			if ((health + power) > (obj.health + obj.power))
			{
				return 1;
			}

			if ((health + power) < (obj.health + obj.power))
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}

	}
}
