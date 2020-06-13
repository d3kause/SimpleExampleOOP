namespace Zachet.MyClasses
{

	// Интерфейс описывающий общее поведение (методы) всех монстров в игре
	internal interface IMonster
	{
		void Appear(); // Появиться на карте
		void Hide(); // Уйти в пул
		void Walk(int x, int y); // Идти
		int StartFight(Person t); // Начать драку
		void Attack(Person t); // Атаковать
		bool CheckLuck(Person t); // Проверка удачи
		bool CheckPower(Person t); // Проверка силы
	}

}
