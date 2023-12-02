namespace Develop04
{
    public class Mindfulness
    {
        // private const int _SECANIMATION = 5;
        private const int _SECDOTSANIMATION = 3;
        private const string _PROMPT = "How long, in seconds, would you like for your session? ";
        protected int _secondsActivity;
        private readonly List<string> _ANIMATIONSTRINGS = new List<string>(){ "|","/","-","\\","|","/","-","\\"};
        private readonly List<string> _ANIMATIONDOTS = new List<string>(){".",".", "."};
        public void SetSeconds()
        {
            Console.Write(_PROMPT);
            int secondsEntered = int.Parse(Console.ReadLine());

            _secondsActivity = secondsEntered;
        }

        public List<string> GetAnimationStrings()
        {
            return _ANIMATIONSTRINGS;
        }

        public void Spinner(int secAnimation = 5)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(secAnimation);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = _ANIMATIONSTRINGS[i];
                Console.Write(s);
                Thread.Sleep(300);
                Console.Write("\b \b");
                i++;

                if (i >= _ANIMATIONSTRINGS.Count)
                {
                    i = 0;
                }
            }
        }
        public void AnimationDots()
        {
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
        public void DisplayGetReadyPrompt()
        {
            Console.Clear();
            Console.WriteLine("Get Ready...");
            Spinner();
            Console.Write("\b \b");
        }
        public void CountDown(int seconds = 3)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            for (int i =seconds;i >= 0; i--)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        public void DisplayYouMayBegin()
        {
            Console.Write("You may bigin in: ");
            CountDown();
            Console.Write("\b \b");
            Console.WriteLine();
        }
        public void DisplayCompletitionActivityMessage(int seconds, string activity)
        {
            Console.WriteLine($"You have completed another {seconds} seconds of the {activity}.");
            Spinner();
        }
    }
}