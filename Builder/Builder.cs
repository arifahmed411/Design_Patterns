using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Creational.Builder
{

    //    Use the Builder pattern when
    //· the algorithm for creating a complex object should be independent of the
    //parts that make up the object and how they're assembled.
    //· the construction process must allow different representations for the
    //object that's constructed.

    //        Benefits
    //Allows you to vary a product’s internal representation.
    //Encapsulates code for construction and representation.
    //Provides control over steps of construction process.

    //Drawbacks
//    Requires creating a separate ConcreteBuilder for each different type of Product.
//Requires the builder classes to be mutable.


//    Participants

    //The classes and objects participating in this pattern are:


    //Builder  
    //specifies an abstract interface for creating parts of a Product object
    //ConcreteBuilder
    //constructs and assembles parts of the product by implementing the Builder interface
    //defines and keeps track of the representation it creates
    //provides an interface for retrieving the product
    //Director
    //constructs an object using the Builder interface
    //Product 
    //represents the complex object under construction.ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled
    //includes classes that define the constituent parts, including interfaces for assembling the parts into the final result

    public class PizzaBuilderDemo
    {
        public static void Main(String[] args)
        {
            Director director = new Director();
            Pizza pizza;
            PizzaBuilder customPizzaBuilder = new PizzaBuilder()
                //.CreateNewPizzaProduct()
                .BuildDough("garlic")
                .BuildSauce("medium")
                .BuildTopping("beef+tomato");
            PizzaBuilder[] pizzaBuilders = new PizzaBuilder[] { new HawaiianPizzaBuilder(), new SpicyPizzaBuilder(), customPizzaBuilder };

            foreach (PizzaBuilder pb in pizzaBuilders)
            {
                director.PizzaBuilder = pb;
                pizza = director.BuildPizza();

                Console.WriteLine($"Pizza Order : {pb.GetType().Name.Replace("Builder", "")}");
                Console.WriteLine($"Pizza dough : {pizza.Dough}");
                Console.WriteLine($"Pizza Sauce : {pizza.Sauce}");
                Console.WriteLine($"Pizza Topping : {pizza.Topping}");
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }

    class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Topping { get; set; }
    }

    class PizzaBuilder
    {
        public Pizza Pizza { get; set; } = new Pizza();

        //public PizzaBuilder CreateNewPizzaProduct()
        //{
        //    Pizza = new Pizza();
        //    return this;
        //}

        public PizzaBuilder BuildDough(string dough)
        {
            Pizza.Dough = dough;
            return this;
        }

        public PizzaBuilder BuildSauce(string sauce)
        {
            Pizza.Sauce = sauce;
            return this;
        }

        public PizzaBuilder BuildTopping(string topping)
        {
            Pizza.Topping = topping;
            return this;
        }

        public virtual PizzaBuilder BuildDough() => this;
        public virtual PizzaBuilder BuildSauce() => this;
        public virtual PizzaBuilder BuildTopping() => this;
    }

    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override PizzaBuilder BuildDough() => BuildDough("cross");
        public override PizzaBuilder BuildSauce() => BuildSauce("mild");
        public override PizzaBuilder BuildTopping() => BuildTopping("ham+pineapple");

    }

    class SpicyPizzaBuilder : PizzaBuilder
    {
        public override PizzaBuilder BuildDough() => BuildDough("pan baked");
        public override PizzaBuilder BuildSauce() => BuildSauce("hot");
        public override PizzaBuilder BuildTopping() => BuildTopping("pepperoni+salami");

    }

    class Director
    {
        public PizzaBuilder PizzaBuilder { get; set; }

        public Pizza BuildPizza() =>
            PizzaBuilder.BuildDough().BuildSauce().BuildTopping().Pizza;
    }

}
