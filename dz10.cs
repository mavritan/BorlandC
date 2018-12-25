abstract class Figure
    {
        protected int x;
        protected int y;
        protected string Color;
        protected bool Visible;
        public abstract void MoveHorizontal(bool b);
        public abstract void MoveVertical(bool b);
        public abstract void ChangeColor(string s);
        public abstract bool Visibility();
        public abstract void Show();
    }
    class Point:Figure
    {
        public override void MoveHorizontal(bool b)
        {
            if (b)
                x++;
            else
                x--;
        }
        public override void MoveVertical(bool b)
        {
            if (b)
                y++;
            else
                y++;
        }
        public override void ChangeColor(string s)
        {
            Color = s;
        }
        public override bool Visibility()
        {
            return Visible;
        }
        public override void Show()
        {
            Console.WriteLine("Color " + Color + " Visable " + Visible.ToString());
        }
    }
    class Circle:Point
    {
        private double Radius;
        public double GetSpace()
        {
            return 3.14 * Radius * Radius;
        }
    }
    class Rectangle:Point
    {
        double Width;
        double Length;
        public double GetSpace()
        {
            return Width * Length;
        }
    }
}
