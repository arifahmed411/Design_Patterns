using System;

namespace DesignPatterns.GoF.Structural.Adapter
{
//    Use the Adapter (also known as Wrapper) pattern when
//· you want to use an existing class, and its interface does not match the
//one you need.
//        you want to create a reusable class that cooperates with unrelated or
//unforeseen classes, that is, classes that don't necessarily have compatible
//interfaces.
//· (object adapter only) you need to use several existing subclasses, but it's
//impractical to adapt their interface by subclassing every one.An object
//adapter can adapt the interface of its parent class.


    class MainApp
    {
        static void Main()
        {
            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();

            // Wait for user
            Console.ReadKey();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    //This is an example of object adapter
    //The other form of adapter pattern is the class adapter
    //object adapter uses composition
    //class adapter uses inheritance
    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}