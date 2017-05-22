using System;

namespace DesignPatterns.GoF.Structural.Bridge
{
//    Definition
//Decouple an abstraction or interface from its implementation so that the two
//can vary independently.
//Bridge makes a clear-cut between abstraction and implementation.

//        Where to use
//•When you want to separate the abstract structure and its concrete
//implementation.
//•When you want to share an implementation among multiple objects,
//•When you want to reuse existing resources in an 'easy to extend' fashion.
//•When you want to hide implementation details from clients.Changes in
//implementation should have no impact on clients.
//Benefits
//Implementation can be selected or switched at run-time.The abstraction and
//implementation can be independently extended or composed.


//        Drawbacks/consequences
//Double indirection - In the example, methods are implemented by subclasses
//of DrawingAPI class. Shape class must delegate the message to a DrawingAPI
//subclass which implements the appropriate method.This will have a slight
//impact on performance.

    public class BridgeExample
    {
        public static void Main(String[] args)
        {
            IShape[] shapes = new IShape[2];
            shapes[0] = new CircleShape(1, 2, 3, new DrawingAPI1());
            shapes[1] = new CircleShape(5, 7, 11, new DrawingAPI2());
            foreach (IShape shape in shapes)
            {
                shape.ResizeByPercentage(200);
                shape.Draw();
            }
            Console.ReadLine();
        }
    }
    /** "Abstraction" */
    public interface IShape
    {
        void Draw();
        void ResizeByPercentage(double pct);
    }

    /** "Refined Abstraction" */
    public class CircleShape : IShape
    {
        private double x, y, radius;
        private IDrawingAPI drawingAPI;

        public CircleShape(double x, double y, double radius, IDrawingAPI
        drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.drawingAPI = drawingAPI;
        }
        // Implementation specific
        public void Draw()
        {
            drawingAPI.DrawCircle(x, y, radius);
        }
        // Abstraction specific
        public void ResizeByPercentage(double pct)
        {
            radius *= pct / 100;
        }
    }
    /** "Implementor" */
    public interface IDrawingAPI
    {
        void DrawCircle(double x, double y, double radius);
    }

    /** "ConcreteImplementor" 1/2 */
    public class DrawingAPI1 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API1.circle at {0},{1} radius {2}\n", x, y,
            radius);
        }
    }

    /** "ConcreteImplementor" 2/2 */
    public class DrawingAPI2 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API2.circle at {0},{1} radius {2}\n", x, y,
            radius);
        }
    }
}
