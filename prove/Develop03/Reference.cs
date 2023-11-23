namespace Develop03
{
    public class Reference
    {
        private String _BookName;
        private int _NumberVerse;
        private int _EndNumberVerse = 0;
        private int _ChapterNumber;

        public Reference()
        {

        }

        public Reference(string bookName, int chapter, int NumberVerse, int EndNumberVerse)
        {
            _BookName = bookName;
            _ChapterNumber = chapter;
            _NumberVerse = NumberVerse;
            _EndNumberVerse = EndNumberVerse;
        }

        public Reference(string bookName, int chapter, int NumberVerse)
        {
            _BookName = bookName;
            _ChapterNumber = chapter;
            _NumberVerse = NumberVerse;
        }

        public string GetBookName()
        {
            return _BookName;
        }

        public void  SetBookName(String BookName)
        {
            _BookName = BookName;
        }

        public int GetNumberVerse()
        {
            return _NumberVerse;
        }

        public int GetEndNumberVerse()
        {
            return _EndNumberVerse;
        }
        public string DisplayNumberVerses()
        {
            if (_EndNumberVerse == 0)
            {
               return $"{_NumberVerse}";
            }
            else
            {
                return $"{_NumberVerse} - {_EndNumberVerse}";
            }
        }

        public void SetNumberVerse(int NumberVerse)
        {
            _NumberVerse = NumberVerse;
        }

        public void SetEndNumberVerse(int EndNUmberVerse)
        {
            _EndNumberVerse = EndNUmberVerse;
        }

        public int nNumberVerses()
        {
            if (_EndNumberVerse == 0)
            {
                return 1;
            }
            else
            {
                return (_EndNumberVerse - _NumberVerse) +1;
            }
        }
        public int GetChapter()
        {
            return _ChapterNumber;
        }

        public void SetChapters(int ChapterNumber)
        {
            _ChapterNumber = ChapterNumber;
        }
    }
}