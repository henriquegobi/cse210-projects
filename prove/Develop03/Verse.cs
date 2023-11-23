namespace Develop03
{
    public class Verse
    {
        private string _TextVerse;
        private int _NumberVerse;
        private List<int> _Indexes = new List<int>();
        public Verse()
        {
            
        }
        public Verse(string TextVerse, int Numberverse)
        {
            _TextVerse = TextVerse;
            _NumberVerse = Numberverse;
        }

        public void SetTextIndexes(int index)
        {
            _Indexes.Add(index);
        }

        public List<int> GetIndexes()
        {
            return _Indexes;
        }

        public String GetTextVerse()
        {
            return _TextVerse;
        }

        public void SetTextVerse(string textverse)
        {
            _TextVerse = textverse;
        }

        public int GetNumberVerse()
        {
            return _NumberVerse;
        }

        public void SetNumberVerse(int NumberVerse)
        {
            _NumberVerse = NumberVerse;
        }
    }
}