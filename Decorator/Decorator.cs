using System;

namespace DesignPatterns.GoF.Structural.Decorator
{

    //    Definition
    //The Decorator pattern lets you attach additional responsibilities and modify
    //an instance functionality dynamically.Decorators provide a flexible
    //alternative to subclassing for extending functionality, using composition
    //instead of inheritance.

    //    Use Decorator
    //· to add responsibilities to individual objects dynamically and
    //transparently, that is, without affecting other objects.
    //· for responsibilities that can be withdrawn.
    //· when extension by subclassing is impractical.Sometimes a large number of
    //independent extensions are possible and would produce an explosion of
    //subclasses to support every combination. Or a class definition may be hidden
    //or otherwise unavailable for subclassing.

//    The Decorator pattern has at least two key benefits and two liabilities:
//        1. More flexibility than static inheritance.The Decorator pattern provides
//a more flexible way to add responsibilities to objects than can be had with
//static (multiple) inheritance.With decorators, responsibilities can be
//added and removed at run-time simply by attaching and detaching them.In
//contrast, inheritance requires creating a new class for each additional
//responsibility(e.g., BorderedScrollableTextView, BorderedTextView).
//This gives rise to many classes and increases the complexity of a system.
//Furthermore, providing different Decorator classes for a specific
//Component class lets you mix and match responsibilities.
//Decorators also make it easy to add a property twice.For example, to give
//a TextView a double border, simply attach two BorderDecorators. Inheriting
//from a Border class twice is error-prone at best.
//2. Avoids feature-laden classes high up in the hierarchy.Decorator offers
//a pay-as-you-go approach to adding responsibilities.Instead of trying to
//support all foreseeable features in a complex, customizable class, you can
//define a simple class and add functionality incrementally with Decorator
//objects.Functionality can be composed from simple pieces. As a result,
//an application needn't pay for features it doesn't use. It's also easy to
//define new kinds of Decorators independently from the classes of objects
//they extend, even for unforeseen extensions.Extending a complex class tends
//to expose details unrelated to the responsibilities you're adding.
//3. A decorator and its component aren't identical. A decorator acts as a
//transparent enclosure.But from an object identity point of view, a
//decorated component is not identical to the component itself. Hence you
//shouldn't rely on object identity when you use decorators.
//4. Lots of little objects. A design that uses Decorator often results in systems
//composed of lots of little objects that all look alike.The objects differ
//only in the way they are interconnected, not in their class or in the value
//of their variables.Although these systems are easy to customize by those
//who understand them, they can be hard to learn and debug.

//    Participants

    //    The classes and objects participating in this pattern are:

    //Component   (LibraryItem)
    //defines the interface for objects that can have responsibilities added to them dynamically.
    //ConcreteComponent(Book, Video)
    //defines an object to which additional responsibilities can be attached.
    //Decorator(Decorator)
    //maintains a reference to a Component object and defines an interface that conforms to Component's interface.
    //ConcreteDecorator(Borrowable)
    //adds responsibilities to the component.


    /// <summary>
    /// MainApp startup class for Structural 
    /// Decorator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
            Console.WriteLine("Added Behavior");
        }
    }
}
