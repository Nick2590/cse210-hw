using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // ----------------------------
    //       I added the ability to check the scripture
    //       to see the full text again if needed.
    // ----------------------------
    public class Reference
    {
        public string Book { get; private set; }
        public int StartChapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = verse;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
                return $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
            return $"{Book} {StartChapter}:{StartVerse}";
        }
    }

    // ----------------------------
    //            WORD
    // ----------------------------
    public class Word
    {
        private string _original;
        private bool _hidden;

        public bool IsHidden => _hidden;

        public Word(string text)
        {
            _original = text;
            _hidden = false;
        }

        public void Hide() => _hidden = true;

        public void Unhide() => _hidden = false;

        public bool HasLetters() => _original.Any(char.IsLetter);

        public string GetDisplay()
        {
            if (!_hidden) return _original;

            char[] chars = _original.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                    chars[i] = '_';
            }
            return new string(chars);
        }
    }

    // ----------------------------
    //         SCRIPTURE
    // ----------------------------
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private static Random _rand = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(" ").Select(w => new Word(w)).ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplay())));
        }

        public bool AllWordsHidden()
        {
            return _words.Where(w => w.HasLetters()).All(w => w.IsHidden);
        }

        public void RevealAll()
        {
            foreach (var w in _words)
                w.Unhide();
        }

        public void HideRandomVisibleWords(int count)
        {
            var visible = _words.Where(w => !w.IsHidden && w.HasLetters()).ToList();

            if (visible.Count == 0) return;

            int toHide = Math.Min(count, visible.Count);

            for (int i = 0; i < toHide; i++)
            {
                int idx = _rand.Next(visible.Count);
                visible[idx].Hide();
                visible.RemoveAt(idx);
            }
        }
    }

    // ----------------------------
    //           PROGRAM
    // ----------------------------
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, " +
                    "that whosoever believeth in him should not perish but have everlasting life."
                ),

                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the LORD with all thine heart; and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him, and he shall direct thy paths."
                )
            };

            Random rnd = new Random();
            Scripture chosen = scriptures[rnd.Next(scriptures.Count)];

            const int HIDE_PER_STEP = 3;

            while (true)
            {
                Console.Clear();
                chosen.Display();

                Console.WriteLine();
                Console.WriteLine("Press Enter to hide words, type 'check' to reveal, or 'quit' to exit.");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "quit")
                    break;

                if (input == "check")
                {
                    chosen.RevealAll();
                    continue;
                }

                if (!chosen.AllWordsHidden())
                {
                    chosen.HideRandomVisibleWords(HIDE_PER_STEP);
                }
                // If all words are hidden, do nothing and keep looping
            }
        }
    }
}
