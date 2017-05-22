using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Structural.Flyweight
{
    //    Definition
    //Th Flyweight pattern provides a mechanism by which you can avoid creating
    //a large number of 'expensive' objects and instead reuse existing instances to
    //represent new ones.

    //    Where to use
    //•When there is a very large number of objects that may not fit in memory.
    //•When most of an objects state can be stored on disk or calculated at
    //runtime.
    //•When there are groups of objects that share state.
    //•When the remaining state can be factored into a much smaller number of
    //objects with shared state.

    //    Flyweight Benefi ts
    //ß Reduces the number of object instances at runtime,
    //saving memory.
    //ß Centralizes state for many “virtual” objects into a
    //single location.

    //    Flyweight Uses and Drawbacks
    //ß The Flyweight is used when a class has many
    //instances, and they can all be controlled identically.
    //ß A drawback of the Flyweight pattern is that once
    //you’ve implemented it, single, logical instances of the
    //class will not be able to behave independently from
    //the other instances.

//    Participants

//The classes and objects participating in this pattern are:


//Flyweight   
//declares an interface through which flyweights can receive and act on extrinsic state.
//ConcreteFlyweight
//implements the Flyweight interface and adds storage for intrinsic state, if any.A ConcreteFlyweight object must be sharable.Any state it stores must be intrinsic, that is, it must be independent of the ConcreteFlyweight object's context.
//UnsharedConcreteFlyweight   
//not all Flyweight subclasses need to be shared.The Flyweight interface enables sharing, but it doesn't enforce it. It is common for UnsharedConcreteFlyweight objects to have ConcreteFlyweight objects as children at some level in the flyweight object structure (as the Row and Column classes have).
//FlyweightFactory
//creates and manages flyweight objects
//ensures that flyweight are shared properly.When a client requests a flyweight, the FlyweightFactory objects assets an existing instance or creates one, if none exists.
//Client
//maintains a reference to flyweight(s).
//computes or stores the extrinsic state of flyweight(s).

    public class FlyweightPatternDemo
    {
        private static readonly String[] colors = { "Red", "Green", "Blue", "White", "Black" };
        public static void Main(String[] args)
        {

            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetCircle(getRandomColor());
                circle.X = getRandomX();
                circle.Y = getRandomY();
                circle.Radius = 50;
                circle.Draw();
            }
            Console.ReadLine();
        }
        private static String getRandomColor()
        {
            return colors[(int)(new Random().Next(colors.Length))];
        }
        private static int getRandomX()
        {
            return (int)(new Random().Next(100));
        }
        private static int getRandomY()
        {
            return (int)(new Random().Next(100));
        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    public interface IShape
    {
        void Draw();
    }

    /// <summary>
    /// The 'ConcreteFlyweight' class
    /// </summary>
    public class Circle : IShape
    {

        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Circle(String color)
        {
            this.Color = color;
        }

        public void Draw()
        {
            Console.WriteLine("Circle: Draw() [Color : " + Color + ", x : " + X + ", y :" + Y + ", radius :" + Radius);
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    public class ShapeFactory
    {
        private static readonly Dictionary<String, IShape> circleMap = new Dictionary<String, IShape>();

        public static IShape GetCircle(String color)
        {

            circleMap.TryGetValue(color, out IShape circle);

            if (circle == null)
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }
}