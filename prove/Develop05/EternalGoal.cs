
namespace Develop05
{
    public class EternalGoal : Goal
    {
        int _points = 0;
        public EternalGoal(){}
        public EternalGoal(string description, int points) : base(description)
        {
            _points = points;
            _description = description;
        }

        public int GetPoints()
        {
            return _points;
        }

        public override int ReturnPoints()
        {
            return _points;
        }
        public List<EternalGoal> LoadGoalsEternalFile(string fileName)
        {
            var Goals = System.IO.File.ReadLines(fileName).Skip(1);
            
            List<EternalGoal> enternalGoals = new List<EternalGoal>();

            foreach(var line in Goals)
            {
                string[] items = line.Split("~~");
                if(items[0] == "2")
                {
                    EternalGoal enternalGoal = new EternalGoal(items[1], int.Parse(items[2]));
                    enternalGoals.Add(enternalGoal);
                }
                
            }
            return enternalGoals;
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"{"[Eternal]"} {_description} - points: {_points}");
        }

    }
}