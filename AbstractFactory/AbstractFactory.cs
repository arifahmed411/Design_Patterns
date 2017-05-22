using System;

namespace DesignPatterns.GoF.Creational.AbstractFactory
{
    //    Use the Abstract Factory pattern when
    //· a system should be independent of how its products are created, composed,
    //and represented.
    //· a system should be configured with one of multiple families of products.
    //· a family of related product objects is designed to be used together, and
    //you need to enforce this constraint.
    //· you want to provide a class library of products, and you want to reveal
    //just their interfaces, not their implementations.

//    Benefits
//Use of this pattern makes it possible to interchange concrete classes without
//changing the code that uses them, even at runtime.

    //As with similar design patterns, one of the main drawbacks is the possibility
    //of unnecessary complexity and extra work in the initial writing of the code.

    enum CostType { Cheap, Expensive}

    class Program
    {
        static void Main()
        {
            InsuranceFactory factory;
            CarInsurance c1;
            HomeInsurance h1;
            PersonalInsurance p1;

            foreach (CostType c in Enum.GetValues(typeof(CostType)))
            {

                factory = InsuranceFactory.getFactory(c);

                c1 = factory.CreateCarInsurance();
                h1 = factory.CreateHomeInsurance();
                p1 = factory.CreatePersonalInsurance();

                Console.WriteLine($"Cost type : {c}");
                Console.WriteLine($"Car Insurance type : {c1.GetType().Name}");
                Console.WriteLine($"Home Insurance type : {h1.GetType().Name}");
                Console.WriteLine($"Personal Insurance type : {p1.GetType().Name}");

                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    //using tag interface is not necessary
    interface ICost { }
    interface ICheap : ICost { }
    interface IExpensive : ICost { }

    abstract class Insurance { }
    abstract class CarInsurance : Insurance, ICost { }
    abstract class PersonalInsurance : Insurance, ICost { }
    abstract class HomeInsurance : Insurance, ICost { }

    class CheapCarInsurance : CarInsurance, ICheap { }
    class ExpensiveCarInsurance : CarInsurance, IExpensive { }
    class CheapPersonalInsurance : PersonalInsurance, ICheap { }
    class ExpensivePersonalInsurance : PersonalInsurance, IExpensive { }
    class CheapHomeInsurance : HomeInsurance, ICheap { }
    class ExpensiveHomeInsurance : HomeInsurance, IExpensive { }

    abstract class InsuranceFactory
    {
        abstract public CarInsurance CreateCarInsurance();
        abstract public HomeInsurance CreateHomeInsurance();
        abstract public PersonalInsurance CreatePersonalInsurance();

        public static InsuranceFactory getFactory(CostType costType)
        {
            switch (costType)
            {
                case CostType.Cheap:
                    return new CheapInsuranceFactory();
                case CostType.Expensive:
                    return new ExpensiveInsuranceFactory();
                default:
                    throw new System.NotImplementedException("Failed to create Insurance Factory");
            }
        }
    }

    class CheapInsuranceFactory : InsuranceFactory
    {
        public override CarInsurance CreateCarInsurance() => new CheapCarInsurance();
        public override HomeInsurance CreateHomeInsurance() => new CheapHomeInsurance();
        public override PersonalInsurance CreatePersonalInsurance() => new CheapPersonalInsurance();
    }

    class ExpensiveInsuranceFactory : InsuranceFactory
    {
        public override CarInsurance CreateCarInsurance() => new ExpensiveCarInsurance();
        public override HomeInsurance CreateHomeInsurance() => new ExpensiveHomeInsurance();
        public override PersonalInsurance CreatePersonalInsurance() => new ExpensivePersonalInsurance();
    }

}