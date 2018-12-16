using System;

namespace program8_2
{
    class SongBook
    {
        private Song head;
        private Song tail;
        public void AddSong(Song song)
        {
            if (head == null)
            {
                head = song;
            }
            else
            {
                tail.SetNext(song);
                song.SetPrev(tail);
            }
            tail = song;
        }
        public Song GetHead()
        {
            return head;
        }
        public Song GetTail()
        {
            return tail;
        }
    }
    class Song
    {
        string name;
        string author;
        private Song next;
        Song prev;

        public Song()
        {
            this.author = "Автор";
            this.name = "Песня";
        }
        public Song(string author, string name)
        {
            this.author = author;
            this.name = name;
        }
        public Song(string author, string name, Song prev)
        {
            this.author = author;
            this.name = name;
            this.prev = prev;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetaAuthor(String author)
        {
            this.author = author;
        }
        public void SetNext(Song next)
        {
            this.next = next;
        }
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }
        public Song GetNext()
        {
            return next;
        }
        public void PrintTextAndPerformer()
        {
            Console.Write("Автор: " + author + "; Название: " + name + "\n");
        }
        public string Title()
        {
            return (author + "; " + name);
        }
        public override bool Equals(object d)
        {
            Song two = d as Song;
            return name.Equals(two.name) && author.Equals(two.author);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            SongBook book = new SongBook();
            Song first = new Song("Ramones", "Pet Semetary");
            book.AddSong(first);
            Song second = new Song("Владимир Высоцкий", "Поезд в небеса");
            book.AddSong(second);
            Song third = new Song("Ramones", "Pet Semetary");
            book.AddSong(third);
            Song fourth = new Song("Garou", "Sous le vent");
            book.AddSong(fourth);
            Song current = book.GetHead();
            do
            {
                current.PrintTextAndPerformer();
                current = current.GetNext();
            }
            while (current != null);
            Console.WriteLine("\nПервая и вторая песня схожи: " + book.GetHead().Equals(book.GetHead().GetNext()));
            Console.ReadLine();
        }
    }
}