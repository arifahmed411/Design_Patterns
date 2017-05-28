using System;

namespace DesignPatterns.GoF.Behavioural.Template
{
//    Intent
//Define the skeleton of an algorithm in an operation, deferring somesteps to
//subclasses.Template Method lets subclasses redefinecertain steps of an algorithm
//without changing the algorithm'sstructure.

//Applicability
//The Template Method pattern should be used
//· to implement the invariant parts of an algorithm once and leave it upto
//subclasses to implement the behavior that can vary.
//· when common behavior among subclasses should be factored and localizedin
//a common class to avoid code duplication.This is a good example
//of"refactoring to generalize" as described by Opdyke andJohnson[OJ93].
//You first identify thedifferences in the existing code and then separate
//the differencesinto new operations.Finally, you replace the differing code
//with atemplate method that calls one of these new operations.
//· to control subclasses extensions.You can define a template methodthat calls
//"hook" operations (see Consequences) at specific points, thereby permitting
//extensions only at those points.

//Template methods call the following kinds of operations:
//· concrete operations (either on the ConcreteClass or onclient classes);
//· concrete AbstractClass operations(i.e., operations that aregenerally
//useful to subclasses);
//· primitive operations(i.e., abstract operations);
//· factory methods(see Factory Method (121)); and
//· hook operations, which provide default behavior thatsubclasses can extend
//if necessary.A hook operation often doesnothing by default.

//Consequences
//Template methods are a fundamental technique for code reuse. They areparticularly
//important in class libraries, because they are the meansfor factoring out common
//behavior in library classes.
//Template methods lead to an inverted control structure that'ssometimes referred
//to as "the Hollywood principle," that is, "Don'tcall us, we'll call you" [Swe85].
//This refers tohow a parent class calls the operations of a subclass and not theother
//way around.

//Participants
//· AbstractClass (Application)
//o defines abstract primitive operations that concretesubclasses
//define to implement steps of an algorithm.
//o implements a template method defining the skeleton of an
//algorithm.The template method calls primitive operations as well
//as operationsdefined in AbstractClass or those of other objects.
//· ConcreteClass (MyApplication)
//o implements the primitive operations to carry out
//subclass-specificsteps of the algorithm.

    class Program
    {
        static void Main()
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        // The "Template method"
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.Read();
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}
