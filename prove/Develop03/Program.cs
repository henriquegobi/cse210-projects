using Develop03;

class Program
{
    public static void Memorizer(Scripture scripture)
    {
        Console.Write("Type the Book of the scripture: ");
        string bookName = Console.ReadLine();

        Console.Write("Type the chpater: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Will you type more than one verse? Type y as 'a' Yes and 'n' as a No: ");
        string decision = Console.ReadLine();

        int startVerse = 0;
        int endVerse = 0;

        if (decision == "y")
        {
 
            Console.Write("Type the start number verse(If the scripture would be 1 Nephy 3: 6-7, then 6 is the start verse): ");
            startVerse = int.Parse(Console.ReadLine());
            
            Console.Write("Type the end mumber verse(If the scripture would be 1 Nephy 3: 6-7, then 7 is the start verse). You don't have a end number verse, then only Enter empty: ");
            endVerse = int.Parse(Console.ReadLine());
        }
        else
        {
            Console.Write("Type the start number verse(If the scripture would be 1 Nephy 3: 6-7, then 6 is the start verse): ");
            startVerse = int.Parse(Console.ReadLine());
        }
        
        List<string> verses = new List<string>();
        if (decision == "y")
        {
            for (int i = startVerse; i <= endVerse; i++)
            {
                Console.Write($"Type the verse {i}: ");
                verses.Add(Console.ReadLine());
            }
            scripture.SetReference(bookName, chapter, startVerse, endVerse);
        }
        else
        {
            Console.Write($"Type the verse {startVerse}: ");
            verses.Add(Console.ReadLine());
            scripture.SetReference(bookName, chapter, startVerse);
        }

        scripture.SetVerses(verses);
        string opt = "";
        Console.Clear();

        do
        {
            ScripureFormater(ref scripture);
            scripture.DisplayScripture();

            Console.Write("Enter empty to continue or 'quit' finish the program: ");
            opt = Console.ReadLine();
            Console.Clear();

        }while (opt != "quit");
    }
    public static void ScripureFormater(ref Scripture scripture)
    {
        Random randomGenerator = new Random();

        foreach (Verse verse in scripture.GetVerses())
        {
            string TextVerse = verse.GetTextVerse();
            List<string> WordsList = new List<string>();
            string[] Words = TextVerse.Split(" ");

            foreach (string word in Words)
            {
                WordsList.Add(word);
            }

            int ramdomNumber = 0;
            bool canContinue = false;

            while (!canContinue)
            {
                ramdomNumber = randomGenerator.Next(0, WordsList.Count);

                if (!verse.GetIndexes().Contains(ramdomNumber))
                {
                    canContinue = true;
                    scripture.GetVerseByNumberVerse(verse.GetNumberVerse()).SetTextIndexes(ramdomNumber);
                    string wordVerse = WordsList[ramdomNumber];

                    int lengthWord = wordVerse.Length;

                    wordVerse = "";
                    for (int i = 0; i <= lengthWord -1; i++)
                    {
                        wordVerse += '_';
                    }

                    WordsList[ramdomNumber] = wordVerse;

                    //Rewrite the formated verse text
                    string formatedText = "";

                    for (int i = 0; i + 1 <= WordsList.Count; i++)
                    {
                        if (i + 1 == WordsList.Count)
                        {
                            formatedText += $"{WordsList[i]}";
                        }
                        else
                        {
                            formatedText += $"{WordsList[i]} ";
                        }
                    }

                    scripture.SetVerseByNumberVerse(formatedText, verse.GetNumberVerse());
                }
                else
                {
                    if (Words.Length == verse.GetIndexes().Count)
                    {
                        canContinue = true;
                        Console.WriteLine($"All words in the verse {verse.GetNumberVerse()} are hidden.");
                    }
                }
            }
        }
    }
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Memorizer(scripture);
    }
}