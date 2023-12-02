namespace Develop04
{
    public class ListeningActivity : Mindfulness
    {
        private List<string> _enteredResponses = new List<string>();
        private const string _REFLECTINGACTIVITYNAME = "Listening Activity";

        public void ExecuteListeningctivity()
        {
            Console.WriteLine($"Welcome to the {_REFLECTINGACTIVITYNAME}.");
            Console.WriteLine("");
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in certain area.");
            Thread.Sleep(3000);

            SetSeconds();
            DisplayGetReadyPrompt();

            Console.WriteLine("List as many responses you can to the following prompt");
            Console.WriteLine("--- When have tou felt the Holy Ghost this mounth? ---");
            DisplayYouMayBegin();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_secondsActivity);

            while (DateTime.Now < endTime)
            {
                Console.Write(">");
                _enteredResponses.Add(Console.ReadLine());
                
            }
            Console.WriteLine($"You listened {_enteredResponses.Count()} items!");

            Console.WriteLine("Well done!!");

            DisplayCompletitionActivityMessage(_secondsActivity, _REFLECTINGACTIVITYNAME);
        }
    }
}