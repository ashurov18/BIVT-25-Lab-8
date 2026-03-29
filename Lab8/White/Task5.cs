using System;

namespace Lab8.White
{
    public class Task5
    {
        public abstract class Team
        {
            protected string _name;

            public Team(string name)
            {
                _name = name;
            }

            public virtual void PlayMatch(int goals, int misses)
            {
                Console.WriteLine($"Команда {_name} сыграла матч: {goals}:{misses}");
            }
        }

        public class ManTeam : Team
        {
            private ManTeam _derby;

            // Используем default вместо null для nullable-типов
            public ManTeam(string name, ManTeam derby = default) : base(name)
            {
                _derby = derby;
            }

            public ManTeam Derby => _derby;

            public void PlayMatch(int goals, int misses, ManTeam team = default)
            {
                if (_derby != null && team == _derby)
                {
                    goals++;
                }
                base.PlayMatch(goals, misses);
            }
        }

        public class WomanTeam : Team
        {
            private int[] _penalties;

            public WomanTeam(string name) : base(name)
            {
                _penalties = new int[0];
            }

            public int[] Penalties => _penalties;
            public int TotalPenalties => _penalties.Length;

            public override void PlayMatch(int goals, int misses)
            {
                if (misses > goals)
                {
                    int difference = misses - goals;
                    Array.Resize(ref _penalties, _penalties.Length + 1);
                    _penalties[_penalties.Length - 1] = difference;
                }
                base.PlayMatch(goals, misses);
            }
        }
    }
}
