using System;
using System.Diagnostics;
using Develop04;

class Program
{

    public static int DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listenig activity");
        Console.WriteLine("4. Quit");
        Console.Write("Select a choice from the menu: ");

        return int.Parse(Console.ReadLine());
    }

    private static void activities()
    {
        Mindfulness mindFulness = new Mindfulness();
        int opt = 0;

        do
        {
            opt = DisplayMenu();
            
            switch (opt)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.ExecuteBrethingActivity();
                    break;

                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.ExecuteReflectingActivity();
                    break;

                case 3:
                    ListeningActivity listeningActivity = new ListeningActivity();
                    listeningActivity.ExecuteListeningctivity();
                    break;

                case 4:
                    Console.WriteLine("Thanks for using our Mindfulness Program");
                    break;
                default:
                    Console.Write("Type valid option");
                    mindFulness.AnimationDots();
                    break;
            }
        }while(opt != 4);
    }

    static void Main(string[] args)
    {
        activities();
    }
}