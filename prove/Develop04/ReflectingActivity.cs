namespace Develop04
{
    public class ReflectingActivity : Mindfulness
    {
        private const string _FILEBREATHINGNAME = "ReflectingPrompts.txt";
        private const string _FILEQUESTIONSBREATHINGNAME = "ReflectingQuestions.txt";
        private const string _REFLECTINGACTIVITYNAME = "Reflecting Activity";
        private List<int> _indexesReflectingPromptsUsed = new List<int>();
        private List<int> _indexesQuestionsReflecting = new List<int>();
        public void ExecuteReflectingActivity()
        {
            Console.WriteLine($"Welcome to the {_REFLECTINGACTIVITYNAME}.");
            Console.WriteLine("");
            Console.WriteLine("This activity will help you reflect on times in your life when you show strength and resilience. This will help you recognize the power you have and how you can use it and other aspects of your life.");
            Thread.Sleep(3000);

            SetSeconds();
            DisplayGetReadyPrompt();
            
            string reflectingPrompt = GetReflectingPrompt();

            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {reflectingPrompt} ---");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            DisplayYouMayBegin();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_secondsActivity);

            while (DateTime.Now < endTime)
            {
                DisplayQuestionReflectingPrompt();
                Console.WriteLine();
            }

            DisplayCompletitionActivityMessage(_secondsActivity, _REFLECTINGACTIVITYNAME);
        }

        private string GetReflectingPrompt()
        {
            bool canContinue = false;

            Random randomGenerator = new Random();

            string[] Reflectingprompts = System.IO.File.ReadAllLines(_FILEBREATHINGNAME);
            
            int ramdomNumber = 0;
            while (canContinue == false)
            {
                ramdomNumber = randomGenerator.Next(0, Reflectingprompts.Length);
                if (!_indexesReflectingPromptsUsed.Contains(ramdomNumber))
                {
                    _indexesReflectingPromptsUsed.Add(ramdomNumber);
                    canContinue = true;
                }
            }
            return Reflectingprompts[ramdomNumber];
        }
        private void DisplayQuestionReflectingPrompt()
        {
            bool canContinue = false;

            Random randomGenerator = new Random();

            string[] Reflectingprompts = System.IO.File.ReadAllLines(_FILEQUESTIONSBREATHINGNAME);
            
            int ramdomNumber = 0;
            while (canContinue == false)
            {
                ramdomNumber = randomGenerator.Next(0, Reflectingprompts.Length);
                if (!_indexesQuestionsReflecting.Contains(ramdomNumber))
                {
                    _indexesQuestionsReflecting.Add(ramdomNumber);
                    canContinue = true;
                }
            }
            Console.Write(Reflectingprompts[ramdomNumber]);
            Spinner(15);
        }
    }
}