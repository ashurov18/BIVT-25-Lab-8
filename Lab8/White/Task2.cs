using System;
using System.Linq;

namespace Lab8.White
{
    public class Task2
    {
        public class Participant
        {
            private string _name;
            private string _surname;
            private double _jump1;
            private double _jump2;

            private const int _standard = 3;

            public static int Standard => _standard;

            public bool IsPassed => _jump1 >= _standard || _jump2 >= _standard;

            static Participant()
            {
            }

            public Participant(string name, string surname, double jump1, double jump2)
            {
                _name = name;
                _surname = surname;
                _jump1 = jump1;
                _jump2 = jump2;
            }

            public string Name => _name;
            public string Surname => _surname;
            public double Jump1 => _jump1;
            public double Jump2 => _jump2;

            public static Participant[] GetPassed(Participant[] participants)
            {
                if (participants == null) return new Participant[0];
                return participants.Where(p => p.IsPassed).ToArray();
            }
        }
    }
}
