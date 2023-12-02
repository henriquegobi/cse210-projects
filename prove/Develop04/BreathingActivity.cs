namespace Develop04
{
    public class BreathingActivity : Mindfulness
    {
        private const string _BREATHINGACTIVITYNAME = "Breathing Activity";
        private const int _STARTBRETHINGSECONDS = 3;
        public void ExecuteBrethingActivity()
        {
            Console.WriteLine($"Welcome to the {_BREATHINGACTIVITYNAME}.");
            Console.WriteLine("");
            Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            Thread.Sleep(3000);

            SetSeconds();
            DisplayGetReadyPrompt();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_secondsActivity);

            int i = _STARTBRETHINGSECONDS;

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                CountDown(i);
                Console.WriteLine("");

                Console.Write("Now breathe out...");
                CountDown(i);

                Console.WriteLine("");
                Console.WriteLine("");
                i++;

                if (i == 10)
                {
                    i = _STARTBRETHINGSECONDS;
                }
            }

            DisplayCompletitionActivityMessage(_secondsActivity, _BREATHINGACTIVITYNAME);
        }
    }
}