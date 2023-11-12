namespace Develop02
{
    public class Journal
    {
        public void DisplayRecords(List<Record> records)
        {
            foreach (Record record in records)
            {
                Console.WriteLine($"Date: {record._date}");
                Console.WriteLine($"Prompt: {record._prompt}");
                Console.WriteLine($"Response: {record._response}");
                Console.WriteLine();
            } 
        }

        public List<Record> ReadFromFile(string File)
        {
            const int POSITION_DATE = 0;
            const int POSITION_RESPONSE = 1;
            const int POSITION_PROMPT = 2;

            List<Record> nFileJournal = new List<Record>();

            Console.WriteLine("Reading File...");

            string [] lines = System.IO.File.ReadAllLines(File);

            foreach (string line in lines)
            {
                Record record = new Record();
                string[] parts = line.Split("~~");

                record._date = parts[POSITION_DATE];
                record._response = parts[POSITION_RESPONSE];
                record._prompt = parts[POSITION_PROMPT];

                nFileJournal.Add(record);
            }

            //foreach (Record record in nFileJournal)
            //{
            //    Console.WriteLine($"{record._date}~~{record._response}~~{record._prompt}");
            //}
            
            return nFileJournal;
        }

        public void SaveToFile(List<Record> Records, string fileName)
        {
            Console.WriteLine("Saving to File...");

            using (StreamWriter outputfile = new StreamWriter(fileName))
            {
                foreach (Record record in Records)
                {
                    outputfile.WriteLine($"{record._date}~~{record._prompt}~~{record._response}");
                }
            }         
        }
    }
}