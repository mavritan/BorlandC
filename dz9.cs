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