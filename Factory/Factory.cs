using System;

namespace DesignPatterns.GoF.Creational.Factory
{
    //    Use the Factory Method pattern when
    //· a class can't anticipate the class of objects it must create.
    //· a class wants its subclasses to specify the objects it creates.
    //· You want to localize the knowledge of which class gets created.
    //. you want to insulate the client from the actual type that is being instantiated.

//        Benefits
//•The client does not need to know every subclass of objects it must create.It
//only need one reference to the abstract class/interface and the factory
//object.
//•The factory encapsulate the creation of objects.This can be useful if the
//creation process is very complex.

    //A potential disadvantage of factory methods is that clients might have to subclass
    //the Creator class just to create a particular ConcreteProduct object. Subclassing
    //is fine when the client has to subclass the Creator class anyway, but otherwise
    //the client now must deal with another point of evolution.


    class MainApp
    {
        static void Main()
        {
            // An array of creators
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                IProduct product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user
            Console.ReadLine();
        }
    }

    interface IProduct { }

    class ProductA : IProduct { }

    class ProductB : IProduct { }

    abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod() => new ProductA();
    }

    class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod() => new ProductB();
    }
}

