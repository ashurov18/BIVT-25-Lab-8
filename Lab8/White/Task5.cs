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

            public ManTeam(string name, ManTeam derby = null) : base(name)
            {
                _derby = derby;
            }

            public ManTeam Derby => _derby;

            public void PlayMatch(int goals, int misses, ManTeam team = null)
            {
                if (team == _derby)
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

        public static void Main(string[] args)
        {
            ManTeam team1 = new ManTeam("Спартак");
            ManTeam team2 = new ManTeam("ЦСКА", team1);

            team1.PlayMatch(1, 1, team2);
            team2.PlayMatch(1, 2, team1);

            WomanTeam wTeam1 = new WomanTeam("Зенит");
            wTeam1.PlayMatch(1, 3);
            wTeam1.PlayMatch(2, 1);

            Console.WriteLine($"Штрафы Зенита: {string.Join(", ", wTeam1.Penalties)}");
            Console.WriteLine($"Всего штрафов: {wTeam1.TotalPenalties}");
        }
    }
}
