using System;

namespace DesignPatterns.GoF.Behavioural.Strategy
{
//    Intent
//Define a family of algorithms, encapsulate each one, and make theminterchangeable.
//Strategy lets the algorithm vary independently fromclients that use it.

//    Applicability
//Use the Strategy pattern when
//· many related classes differ only in their behavior. Strategiesprovide a
//way to configure a class with one of many behaviors.
//· you need different variants of an algorithm.For example, you might
//definealgorithms reflecting different space/time trade-offs.Strategies
//can be used when these variants are implemented as a classhierarchy of
//algorithms [HO87].
//· an algorithm uses data that clients shouldn't know about. Use theStrategy
//pattern to avoid exposing complex, algorithm-specific datastructures.
//· a class defines many behaviors, and these appear as multipleconditional
//statements in its operations.Instead of manyconditionals, move related
//conditional branches into their ownStrategy class.

//    Consequences
//The Strategy pattern has the following benefits and drawbacks:
//1. Families of related algorithms.Hierarchies of Strategy classes define a
//family of algorithms orbehaviors for contexts to reuse.Inheritance canhelp
//factor out common functionality of the algorithms.
//2. An alternative to subclassing.Inheritance offers another way to support
//a variety of algorithms orbehaviors.You can subclass a Context class
//directly to give itdifferent behaviors.But this hard-wires the behavior
//into Context.It mixes the algorithm implementation with Context's, making
//Contextharder to understand, maintain, and extend. And you can't vary
//thealgorithm dynamically. You wind up with many related classes whoseonly
//difference is the algorithm or behavior they employ.Encapsulating the
//algorithm in separate Strategy classes lets you varythe algorithm
//independently of its context, making it easier toswitch, understand, and
//extend.
//3. Strategies eliminate conditional statements.The Strategy pattern offers
//an alternative to conditional statements forselecting desired behavior.
//When different behaviors are lumped into oneclass, it's hard to avoid using
//conditional statements to select theright behavior. Encapsulating the
//behavior in separate Strategy classeseliminates these conditional
//statements.

//   Participants
//· Strategy(Compositor)
//o declares an interface common to all supported algorithms.Context
//uses this interface to call the algorithm defined by a
//ConcreteStrategy.
//· ConcreteStrategy(SimpleCompositor, TeXCompositor, ArrayCompositor)
//o implements the algorithm using the Strategy interface.
//· Context(Composition)
//o is configured with a ConcreteStrategy object.
//o maintains a reference to a Strategy object.
//o may define an interface that lets Strategy access its data.

    public class Program
    {
        public static void Main()
        {
            CalculateClient client = new CalculateClient(new Minus());

            Console.WriteLine("Minus: " + client.Calculate(5, 2));

            //Change the strategy
            client.Strategy = new Plus();

            Console.WriteLine("Plus: " + client.Calculate(3, 1));

            Console.Read();
        }
    }

    //The interface for the strategies
    public interface ICalculate
    {
        int Calculate(int value1, int value2);
    }

    //strategies
    //Strategy : Minus
    public class Minus : ICalculate
    {
        public int Calculate(int value1, int value2)
        {
            return value1 - value2;
        }
    }

    //Strategy : Plus
    public class Plus : ICalculate
    {
        public int Calculate(int value1, int value2)
        {
            return value1 + value2;
        }
    }

    //The client
    public class CalculateClient
    {
        public ICalculate Strategy { get; set; }

        public CalculateClient(ICalculate strategy)
        {
            Strategy = strategy;
        }

        //Executes the strategy
        public int Calculate(int value1, int value2)
        {
            return Strategy.Calculate(value1, value2);
        }
    }
}