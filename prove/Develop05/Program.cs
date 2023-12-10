using System;
using Develop05;

class Program
{
    public static void SaveToFile(string fileName,int totalPoints, List<SimpleGoal> SimpleGoals, List<EternalGoal> EternalGoals, List<CheckListGoal> CheckListGoals)
    {
        Console.WriteLine("Saving to File...");

        using (StreamWriter outputfile = new StreamWriter(fileName))
        {
            outputfile.WriteLine(totalPoints);
            foreach (SimpleGoal simpleGoal in SimpleGoals)
            {
                outputfile.WriteLine($"1~~{simpleGoal.GetDescription()}~~{simpleGoal.GetPoints()}~~{simpleGoal.GetGoalIsDone()}");
            }

            foreach (EternalGoal eternalGoals in EternalGoals)
            {
                outputfile.WriteLine($"2~~{eternalGoals.GetDescription()}~~{eternalGoals.GetPoints()}");
            }
            
            foreach (CheckListGoal checkListGoals in CheckListGoals)
            {
                outputfile.WriteLine($"3~~{checkListGoals.GetDescription()}~~{checkListGoals.GetPoints()}~~{checkListGoals.GetExtraPoints()}~~{checkListGoals.GetCountCheckList()}~~{checkListGoals.GetCheckListDone()}");
            }
        }         
    }
    public static int SetTotalPointsFromFile(string file)
    {
        int firstLine = int.Parse(File.ReadLines(file).FirstOrDefault());
        return firstLine;
    }
    public static void AnimationDots()
    {
        int _SECDOTSANIMATION = 3;
        List<string> _ANIMATIONDOTS = new List<string>(){".",".", "."};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_SECDOTSANIMATION);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = _ANIMATIONDOTS[i];
            Console.Write(s);
            Thread.Sleep(1000);
            i++;

            if (i >= _ANIMATIONDOTS.Count)
            {
                    i = 0;
            }
        }
    }
    public static int DisplayMenu()
    {
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");

        return int.Parse(Console.ReadLine());
    }
    private static void BeginProgram()
    {   
        int _totalPoints = 0;
        int opt = 0;

        List<SimpleGoal> simpleGoals = new List<SimpleGoal>();
        List<EternalGoal> eternalGoals = new List<EternalGoal>();
        List<CheckListGoal> checkListGoals = new List<CheckListGoal>();

        do
        {
            Console.WriteLine($"Current score: {_totalPoints}\n");
            opt = DisplayMenu();
            
            switch (opt)
            {
                case 1:
                    Console.WriteLine("The types of goals are: ");
                    Console.WriteLine("     1. Simple Goal");
                    Console.WriteLine("     2. Eternal Goal");
                    Console.WriteLine("     3. CheckList Goal");
                    Console.Write("Select a choice from the menu: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch(choice)
                    {
                        case 1:
                            Console.Write("What is the description of your goal? ");
                            string description = Console.ReadLine();

                            Console.Write("What is the amount points associated with this goal? ");
                            int points = int.Parse(Console.ReadLine());

                            SimpleGoal simpleGoaladd = new SimpleGoal(description, points);
                            simpleGoals.Add(simpleGoaladd);
                            break;

                        case 2:
                            Console.Write("What is the description of your goal? ");
                            string description2 = Console.ReadLine();

                            Console.Write("What is the amount points associated with this goal? ");
                            int points2 = int.Parse(Console.ReadLine());

                            EternalGoal eternalGoaladd = new EternalGoal(description2, points2);
                            eternalGoals.Add(eternalGoaladd);
                            break;

                        case 3:
                            Console.Write("What is the description of your goal? ");
                            string description3 = Console.ReadLine();

                            Console.Write("What is the amount points associated with this goal? ");
                            int points3 = int.Parse(Console.ReadLine());

                            Console.Write("What is the extra points associated with this goal? ");
                            int extrapoints = int.Parse(Console.ReadLine());

                            Console.Write("How much times to complete this goal? ");
                            int listCheckList = int.Parse(Console.ReadLine());

                            List<bool> checkList = new List<bool>();
                            for (int i = 0; i <= listCheckList; i++)
                            {
                                checkList.Add(false);
                            }
                            CheckListGoal checkListGoaladd = new CheckListGoal(description3, points3, extrapoints, checkList);
                            checkListGoals.Add(checkListGoaladd);
                            break;
                    }
                    break;

                case 2:
                    foreach (var item in simpleGoals)
                    {
                        item.DisplayGoal();
                    }

                    foreach (var item in eternalGoals)
                    {
                        item.DisplayGoal();
                    }

                    foreach (var item in checkListGoals)
                    {
                        item.DisplayGoal();
                    }
                    break;

                case 3:
                    Console.Write("Type the name of the file: ");
                    string fileName = Console.ReadLine();
                    SaveToFile(fileName, _totalPoints, simpleGoals, eternalGoals, checkListGoals);
                    break;

                case 4:
                    Console.Write("Type the name of the file: ");
                    string fileName2 = Console.ReadLine();
                    _totalPoints = SetTotalPointsFromFile(fileName2);

                    SimpleGoal simpleGoal = new SimpleGoal();
                    simpleGoals = simpleGoal.LoadPointsFromFile(fileName2);

                    EternalGoal eternalGoal = new EternalGoal();
                    eternalGoals = eternalGoal.LoadGoalsEternalFile(fileName2);

                    CheckListGoal checkListGoal = new CheckListGoal();
                    checkListGoals = checkListGoal.LoadGoalsCheckListFile(fileName2);
                    break;

                case 5:
                    Console.WriteLine("The types of goals are: ");
                    Console.WriteLine("     1. Simple Goal");
                    Console.WriteLine("     2. Eternal Goal");
                    Console.WriteLine("     3. CheckList Goal");
                    Console.Write("What kind of goal do you want to update?: ");
                    int choiceUpdate = int.Parse(Console.ReadLine());

                    switch(choiceUpdate)
                    {
                        case 1:
                            Console.WriteLine("Chose one of the items bleow: ");
                            for (int i = 0; i < simpleGoals.Count(); i++)
                            {
                                Console.Write($"{i+1}. ");
                                simpleGoals[i].DisplayGoal();
                            }
                            int choiceSimpleGoalUpdate = int.Parse(Console.ReadLine()) -1;
                            simpleGoals[choiceSimpleGoalUpdate].UpDateGoal();
                            _totalPoints += simpleGoals[choiceSimpleGoalUpdate].ReturnPoints();
                            break;

                        case 2:
                            Console.WriteLine("Chose one of the items bleow: ");
                            for (int i = 0; i < eternalGoals.Count(); i++)
                            {
                                Console.Write($"{i+1}. ");
                                eternalGoals[i].DisplayGoal();
                            }
                            int choiceEternalGoalUpdate = int.Parse(Console.ReadLine()) -1;
                            eternalGoals[choiceEternalGoalUpdate].UpDateGoal();
                            _totalPoints += eternalGoals[choiceEternalGoalUpdate].ReturnPoints();
                            break;

                        case 3:
                            Console.WriteLine("Chose one of the items bleow: ");
                            for (int i = 0; i < checkListGoals.Count(); i++)
                            {
                                Console.Write($"{i+1}. ");
                                checkListGoals[i].DisplayGoal();
                            }
                            int choiceCheclistGoalUpdate = int.Parse(Console.ReadLine()) -1;
                            checkListGoals[choiceCheclistGoalUpdate].UpDateGoal();
                            Console.WriteLine($"Congratulations! You earned {checkListGoals[choiceCheclistGoalUpdate].GetExtraPoints()} extra points!");
                            _totalPoints += checkListGoals[choiceCheclistGoalUpdate].ReturnPoints();
                            break;
                    }

                    break;

                case 6:
                    Console.WriteLine("Thanks for using our program!");
                    break;

                default:
                    Console.Write("Type valid option");
                    AnimationDots();
                    break;
            }
        }while(opt != 6);
    }
    static void Main(string[] args)
    {
        BeginProgram();
    }
}