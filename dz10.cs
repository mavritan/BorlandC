using System;
using System.ComponentModel;

namespace Lesson_10
{
    enum Color
    {
        Red,
        Green,
        Blue
    }

    interface IShape
    {
        double GetSquare();
    }

    abstract class Figure
    {
        private Color _color;
        private bool _visible;

        public abstract void ShiftX(int difference);
        public abstract void ShiftY(int difference);

        public virtual void Display()
        {
            Console.WriteLine($"color: {_color}; visible: {_visible}");
        }

        public void SetColor(Color color)
        {
            if (!Enum.IsDefined(typeof(Color), color))
                throw new InvalidEnumArgumentException(nameof(color), (int) color, typeof(Color));
            _color = color;
        }

        public void SetVisible(bool visible)
        {
            _visible = visible;
        }

        public Color GetColor()
        {
            return _color;
        }

        public bool GetVisible()
        {
            return _visible;
        }
    }

    class Point : Figure
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override void ShiftX(int difference)
        {
            _x = _x + difference;
        }

        public override void ShiftY(int difference)
        {
            _y = _y + difference;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"(x,y)=({_x},{_y})");
        }

        public void SetXy(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetX(int x)
        {
            _x = x;
        }

        public void SetY(int y)
        {
            _y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }
    }

    class Circle : Point, IShape
    {
        private readonly int _radius;

        public Circle(int x, int y, int radius) : base(x, y)
        {
            _radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"radius:{_radius}");
        }
    }

    class Rectangle : Point, IShape
    {
        private readonly int _length;
        private readonly int _width;

        public Rectangle(int x, int y, int length, int width) : base(x, y)
        {
            _length = length;
            _width = width;
        }

        public double GetSquare()
        {
            return _length * _width;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"length:{_length}; width:{_width}");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Circle c = new Circle(5, 5, 3);
            c.SetColor(Color.Blue);
            c.SetVisible(true);

            Console.WriteLine("Окружность");
            c.Display();

            c.ShiftX(3);
            c.ShiftY(-7);
            c.Display();

            Rectangle r = new Rectangle(2, 7, 4, 10);
            r.SetColor(Color.Red);
            r.SetVisible(true);
            Console.WriteLine("\nПрямоугольник");
            r.Display();

            r.ShiftX(3);
            r.ShiftY(-7);
            r.Display();
            Console.WriteLine("\nПлощадь");
            Console.WriteLine(r.GetSquare());
            Console.ReadKey();
        }
    }
}
