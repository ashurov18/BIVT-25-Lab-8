using System;

namespace Lab8.White
{
    public class Task4
    {
        protected string _name;
        protected string _surname;

        public Human(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Человек: {_name} {_surname}");
        }
    }

    public class Participant : Human
    {
        private static int _count;
        private int[] _jumps;

        // Статическое свойство только для чтения
        public static int Count => _count;

        // Статический конструктор
        static Participant()
        {
            _count = 0;
        }

        // Конструктор
        public Participant(string name, string surname, int[] jumps) : base(name, surname)
        {
            _jumps = jumps;
            _count++;
        }

        // Переопределенный метод Print
        public override void Print()
        {
            Console.Write($"Участник: {_name} {_surname}, ");
            Console.Write("Прыжки: ");
            foreach (var jump in _jumps) Console.Write($"{jump} ");
            Console.WriteLine();
        }
    }

    public class Task4
    {
        public static void Main(string[] args)
        {
            Participant p1 = new Participant("Иван", "Иванов", new int[] { 4, 5 });
            Participant p2 = new Participant("Петр", "Петров", new int[] { 3, 3 });

            p1.Print();
            p2.Print();

            Console.WriteLine($"Всего участников: {Participant.Count}");
        }
    }
}
