namespace Develop05
{
    public class CheckListGoal : Goal
    {   int _points = 0;
        private bool _goalIsDone;
        private int _extraPoints;
        private List<bool> _checkList = new List<bool>();
        public CheckListGoal(){}
        public CheckListGoal(string description, int points, int extraPoints,bool goalIsDone, List<bool> checkList) : base(description)
        {
            _points = points;
            _description = description;
            _goalIsDone = goalIsDone;
            _extraPoints = extraPoints;

            foreach(bool checklist in checkList)
            {
                _checkList.Add(checklist);
            }
        }
        public CheckListGoal(string description, int points, int extraPoints, List<bool> checkList) : base(description)
        {
            _points = points;
            _description = description;
            _goalIsDone = false;
            _extraPoints = extraPoints;

            foreach(bool checklist in checkList)
            {
                _checkList.Add(checklist);
            }
        }
        public int GetExtraPoints()
        {
            return _extraPoints;
        }

        public int GetCheckListDone()
        {
            return _checkList.Count(x => x);
        }
        public int GetCheckListNotDone()
        {
            return _checkList.Count(x => !x);
        }
        public int GetCountCheckList()
        {
            return _checkList.Count();
        }

        public int GetPoints()
        {
            return _points;
        }
        public override int ReturnPoints()
        { 
            int pointsReturn = 0;
            var alltrue = _checkList.All(x => x);

            if(alltrue)
            {
                pointsReturn = _points + _extraPoints;
            }
            else
            {
                pointsReturn = _points;
            }
            return pointsReturn;
        }

        public override void UpDateGoal()
        {
            bool _true = true;

            for (int i = 0; i <= _checkList.Count() -1; i++)
            {
                if(_checkList[i] == false)
                {
                    _checkList[i] = _true;
                    _true = false;
                }
            }

            var alltrue = _checkList.All(x => x);

            if(alltrue == true)
            {
                _goalIsDone = true;
            }
        }

        public List<CheckListGoal> LoadGoalsCheckListFile(string fileName)
        {
            var Goals = System.IO.File.ReadLines(fileName).Skip(1);
            
            List<CheckListGoal> checkListGoals = new List<CheckListGoal>();

            foreach(var line in Goals)
            {
                List<bool> checkList = new List<bool>();
                string[] items = line.Split("~~");

                if(items[0] == "3")
                {
                    for (int i = 0; i <= int.Parse(items[4]) -1; i++)
                    {
                        checkList.Add(false);
                    }

                    for (int i = 0; i <= int.Parse(items[5]) -1; i++)
                    {
                        checkList[i] = true;
                    }
                    var alltrue = checkList.All(x => x);

                    CheckListGoal checkListGoal = new CheckListGoal(items[1], int.Parse(items[2]), int.Parse(items[3]),alltrue, checkList);
                    checkListGoals.Add(checkListGoal);
                }
            }
            return checkListGoals;
        }

        public override void DisplayGoal()
        {
            int totalCheck = 0;
            int totalDone = 0;

            totalCheck += _checkList.Count();

            for (int i = 0; i <= _checkList.Count() -1; i++)
            {
                if (_checkList[i] == true)
                {
                    totalDone += 1;
                }

            }

            Console.WriteLine($"{(_goalIsDone ? "[x]" : "[ ]")} {_description} - points: {_points}  -- Currently completed: {totalCheck}/{totalDone}");
        }

    }
}