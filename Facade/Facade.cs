using System;

namespace DesignPatterns.GoF.Structural.Facade
{
    //    Intent
    //Provide a unified interface to a set of interfaces in a subsystem.Facade defines
    //a higher-level interface that makes the subsystem easier to use.

    //    The facade pattern is typically used when

    //a simple interface is required to access a complex system,
    //a system is very complex or difficult to understand,
    //an entry point is needed to each level of layered software, or
    //the abstractions and implementations of a subsystem are tightly coupled.

//    Benefits
//The main benefit with the Facade pattern is that we can combine very
//complex method calls and code blocks into a single method that performs a
//complex and recurring task.Besides making code easier to use and
//understand, it reduces code dependencies between libraries or packages,
//making programmers more apt to consideration before writing new code that
//exposes the inner workings of a library or a package.Also, since the Facade
//makes a weak coupling between the client code and other packages or
//libraries it allows us vary the internal components since the client does not
//call them directly.

//        Drawbacks/consequences
//One drawback is that we have much less control of what goes on beyond the
//surface.Also, if some classes require small variations to the implementation
//of Facade methods, we might end up with a mess.


//        The classes and objects participating in this pattern are:

    //Facade   
    //knows which subsystem classes are responsible for a request.
    //delegates client requests to appropriate subsystem objects.
    //Subsystem classes   
    //implement subsystem functionality.
    //handle work assigned by the Facade object.
    //have no knowledge of the facade and keep no reference to it.


    /// <summary>
    /// MainApp startup class for Structural
    /// Facade Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    /// <summary>
    /// The 'Subsystem ClassD' class
    /// </summary>
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}