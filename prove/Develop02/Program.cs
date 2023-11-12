using System;
using Develop02;

class Program
{
    static int MenuChoice()
    {
        int choice;

        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Close file");
        Console.WriteLine("6. Quit");
        Console.Write("Chose one option from above: ");

        choice = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return choice;
    }

    static void Main(string[] args)
    {

        const string PROMPTS_FILE_NMAE = "Prompts.txt";

        Journal journal = new Journal();

        Prompts lprompts = new Prompts();

        string [] prompts = lprompts.GetPrompts(PROMPTS_FILE_NMAE);


        Console.WriteLine("Welcome! Let's write in your Journal today!");

        int opt = 0;

        Random randomGenerator = new Random();

        List<Record> records = new List<Record>();

        string _loadedFile = "";
        
        do
        {
            opt = MenuChoice();

            switch (opt)
            {   
                case 1: //Writing Records
                    Record response = new Record();
                    int ramdomNumber = randomGenerator.Next(1, prompts.Length);
                    string prompt = prompts[ramdomNumber];

                    Console.WriteLine(prompt);
                    response._response = Console.ReadLine();
                    response._prompt = prompt;
                    Console.Write("Please, type today's date: ");
                    response._date = Console.ReadLine();

                    records.Add(response);
                    break;
                
                case 2: //Displaying Records
                    
                    if (records.Count == 0)
                    {
                        Console.WriteLine("File not loaded,use the 3º function to load a file or create a new one with de 1º function.");
                    }
                    else
                    {
                        journal.DisplayRecords(records);
                    }
                    break;

                case 3: //Loading records

                    Console.Write("Type the file to be loaded: ");
                    string nameFileToLoad = Console.ReadLine();
                    records = journal.ReadFromFile(nameFileToLoad);
                    _loadedFile = nameFileToLoad;
                    break;

                case 4: //Saving Recods
                    string nameFile;
                    string _fileSavingChoice = "";

                    if (_loadedFile != "")
                    {
                        Console.Write($"File loaded with {_loadedFile}, do you want to save here? Type 'Y' as a Yes or 'n' as a No: ");
                        _fileSavingChoice = Console.ReadLine();
                    }
                    
                    if (_fileSavingChoice == "y")
                    {
                        nameFile = _loadedFile;
                        Console.WriteLine("saving...");
                        journal.SaveToFile(records, nameFile);
                        break;
                    }

                    Console.Write("Type the name of the file to save: ");
                    nameFile = Console.ReadLine();
                    Console.WriteLine("saving...");

                    journal.SaveToFile(records, nameFile);
                    _loadedFile = nameFile;
                    break;

                case 5: //Close file

                    records = new List<Record>();;
                    _loadedFile = "";
                    break;
                
                default:
                    if (opt < 1 || opt > 6)
                    {
                        Console.WriteLine("Invalid option");
                        Console.WriteLine();
                    }
                    break;
            }
        }while (opt != 6);
    }
}