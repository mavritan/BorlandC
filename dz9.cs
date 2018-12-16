 using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // 8.2 and 9.1
            Song mySong = new Song();
            // l.Add(new Song("Moon", "Mike",null));
            // l.Add(new Song("Sun", "Peter",l.Last()));
            // l.Add(new Song("Moon", "Mike",l.Last()));
            // l.Add(new Song("Sun", "Peter", l.Last()));
            // l.Add(new Song());
            // for (int i = 0; i < l.Count; i++)
            //     l[i].PrintTitle();
            // for (int i = 0; i < l.Count; i++)
            //     for (int j = 0; j < l.Count; j++)
            //         if (l[i].Equals(l[j]))
            //             Console.WriteLine("Песни " + (i+1).ToString() + " и " + (j+1).ToString() + " одинаковые");
             
            Console.ReadKey();
        }
 class Song
    {
        public Song()
        {
            name = "";
            author = "";
            prev = null;
        }
        public Song(string n,string a,Song p)
        {
            name = n;
            author = a;
            prev = p;
        }
        string name;
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        string author;
        public string Author
        {
            set
            {
                author = value;
            }
            get
            {
                return author;
            }
        }
        Song prev;
        public Song Prev
        {
            set
            {
                prev = value;
            }
            get
            {
                return prev;
            }
        }
        public string Title()
        {
            return name + " " + author;
        }
        public void PrintTitle()
        {
            Console.WriteLine(Title());
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Song s = obj as Song;
            if (s == null)
                return false;
            if (name == s.name && author == s.author)
                return true;
            return false;
        }

    }