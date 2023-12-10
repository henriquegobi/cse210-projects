
using System.Linq;

namespace Develop05
{
    public class SimpleGoal : Goal
    {
        private int _points;
        private bool _goalIsDone;
        public SimpleGoal(){}

        public SimpleGoal(string description, int points) : base(description)
        {
            _points = points;
            _goalIsDone = false;
        }
        public SimpleGoal(string description, int points, bool goalIsDone) : base(description)
        {
            _points = points;
            _goalIsDone = goalIsDone;
        }
        public int GetPoints()
        {
            return _points;
        }
        public bool GetGoalIsDone()
        {
            return _goalIsDone;
        }

        private void SetGoalIsDone()
        {
            _goalIsDone = true;
        }

        public override int ReturnPoints()
        {
            return _points;
        }
 
        public override void UpDateGoal()
        {
            SetGoalIsDone();
        }

        public List<SimpleGoal> LoadPointsFromFile(string fileName)
        {
            var Goals = System.IO.File.ReadLines(fileName).Skip(1);
            
            List<SimpleGoal> simpleGoals = new List<SimpleGoal>();

            foreach(var line in Goals)
            {
                string[] items = line.Split("~~");
                if(items[0] == "1")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(items[1], int.Parse(items[2]), bool.Parse(items[3]));
                    simpleGoals.Add(simpleGoal);
                }
                
            }
            return simpleGoals;
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"{(_goalIsDone ? "[x]" : "[ ]")} {_description} - points: {_points}");
        }

    }
}