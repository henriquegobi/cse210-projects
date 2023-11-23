namespace Develop03
{
    public class Scripture
    {
        private List<Verse> _Verses = new List<Verse>();
        private Reference _reference = new Reference();

        public Verse GetVerseByNumberVerse(int numberVerse)
        {
            Verse verse = new Verse();

            for (int i = 0; i < _Verses.Count; i++)
            {
                if (_Verses[i].GetNumberVerse() == numberVerse)
                {
                    verse = _Verses[i];
                }
            }
            return verse;
        }

        // Getter method for one Verse
        public Verse GetVerse(int IndexVerse)
        {
            return _Verses[IndexVerse];
        }

        public List<Verse> GetVerses()
        {
            return _Verses;
        }

        public void SetVerseByNumberVerse(string newTextVerse, int numberVerse)
        {
            Verse verseReturn = new Verse();

            for (int i = 0; i < _Verses.Count; i++)
            {
                if (_Verses[i].GetNumberVerse() == numberVerse)
                {
                    _Verses[i].SetTextVerse(newTextVerse);
                }
            }
        }
        public void SetVerses(List<string> Verses)
        {
            int nreferenceVerses = _reference.nNumberVerses();
            if (nreferenceVerses != Verses.Count)
            {
                Console.WriteLine("Number of text verses shoud be same as number verses in the reference");
            }
            else
            {
                if (nreferenceVerses > 1)
                {
                    int nIndexVerses = 0;
                    for (int i = _reference.GetNumberVerse(); i <= _reference.GetEndNumberVerse(); i++)
                    {
                        Verse verse = new Verse(Verses[nIndexVerses], i);
                        _Verses.Add(verse); 
                        nIndexVerses += +1;
                    }
                }
                else
                {
                    Verse verse = new Verse(Verses[0], _reference.GetNumberVerse());
                    _Verses.Add(verse);
                }
            }
        }

        // Getter method for Reference
        public Reference GetReference()
        {
            return _reference;
        }

        public void SetReference(string bookName, int chapter, int numberVerse, int endNumberVerse = 0)
        {
            if (endNumberVerse == 0)
            {
                Reference reference = new Reference(bookName, chapter, numberVerse);
                _reference = reference;
            }
            else
            {
                Reference reference = new Reference(bookName, chapter, numberVerse, endNumberVerse);

                 _reference = reference;
            }
        }

        public void DisplayScripture()
        {
            Console.WriteLine($"{_reference.GetBookName()} {_reference.GetChapter()}: {_reference.DisplayNumberVerses()}");

            foreach (Verse verse in _Verses)
            {
                Console.WriteLine($"{verse.GetNumberVerse()} - {verse.GetTextVerse()}");
            }            
        }
    }
}