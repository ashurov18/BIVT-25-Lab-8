using System;
using System.Collections.Generic;

namespace Lab8.White
{
    public class Task1
    {
        public class Participant
        {
            // Внутренние поля (private), доступные только через свойства
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            private int _jumpCount; // Счетчик прыжков для метода Jump

            // Статические поля
            private static int _standard = 5;
            private static int _jumpers = 0;
            private static int _disqualified = 0;

            // Свойства для чтения (только Get, CanWrite = false)
            public string Surname => _surname;
            public string Club => _club;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => _firstJump + _secondJump;

            // Статические свойства для чтения
            public static int Standard => _standard;
            public static int Jumpers => _jumpers;
            public static int Disqualified => _disqualified;

            // Статический конструктор (TypeInitializer)
            static Participant()
            {
                _standard = 5;
                _jumpers = 0;
                _disqualified = 0;
            }

            // Конструктор (принимает фамилию и клуб)
            public Participant(string surname, string club)
            {
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
                _jumpCount = 0;
                _jumpers++;
            }

            // Метод Jump (принимает double, добавляет прыжок)
            public void Jump(double result)
            {
                if (_jumpCount == 0)
                {
                    _firstJump = result;
                }
                else if (_jumpCount == 1)
                {
                    _secondJump = result;
                }
                _jumpCount++;
            }

            // Метод Sort (сортирует массив по убыванию суммы прыжков)
            public static void Sort(Participant[] participants)
            {
                if (participants == null) return;

                for (int i = 0; i < participants.Length - 1; i++)
                {
                    for (int j = 0; j < participants.Length - 1 - i; j++)
                    {
                        if (participants[j].JumpSum < participants[j + 1].JumpSum)
                        {
                            Participant temp = participants[j];
                            participants[j] = participants[j + 1];
                            participants[j + 1] = temp;
                        }
                    }
                }
            }

            // Метод Disqualify (удаляет тех, у кого оба прыжка < 5)
            public static void Disqualify(ref Participant[] participants)
            {
                if (participants == null) return;

                int validCount = 0;
                // Подсчет валидных
                foreach (var p in participants)
                {
                    if (p._firstJump >= _standard && p._secondJump >= _standard)
                    {
                        validCount++;
                    }
                }

                // Создание нового массива
                Participant[] newArray = new Participant[validCount];
                int index = 0;
                foreach (var p in participants)
                {
                    if (p._firstJump >= _standard && p._secondJump >= _standard)
                    {
                        newArray[index++] = p;
                    }
                }

                // Обновление статических полей
                _disqualified = participants.Length - validCount;
                _jumpers = validCount;

                // Возврат нового массива через ref
                participants = newArray;
            }

            // Метод Print (вывод информации)
            public void Print()
            {
                Console.WriteLine($"{_surname} {_club} | Прыжки: {_firstJump}, {_secondJump} | Сумма: {JumpSum}");
            }
        }
    }
}
