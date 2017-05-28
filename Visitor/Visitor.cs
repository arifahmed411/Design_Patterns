using System;
using System.Text;

namespace DesignPatterns.GoF.Behavioural.Visitor
{
    //    Intent
    //    Represent an operation to be performed on the elements of an objectstructure.
    //    Visitor lets you define a new operation without changing theclasses of the elements
    //    on which it operates.

    //Applicability
    //Use the Visitor pattern when
    //· an object structure contains many classes of objects with differing
    //interfaces, and you want to perform operations on these objects that depend
    //on their concrete classes.
    //· many distinct and unrelated operations need to be performed on objects in
    //an object structure, and you want to avoid "polluting" theirclasses with
    //these operations. Visitor lets you keep related operationstogether by
    //defining them in one class. When the object structure is shared by many
    //applications, use Visitor to put operations in just those applications that
    //need them.
    //· the classes defining the object structure rarely change, but you oftenwant
    //to define new operations over the structure.Changing the objectstructure
    //classes requires redefining the interface to all visitors, which is
    //potentially costly.If the object structure classes changeoften, then it's
    //probably better to define the operations in those classes.

    //Consequences
    //Some of the benefits and liabilities of the Visitor pattern are as follows:
    //1. Visitor makes adding new operations easy.Visitors make it easy to add
    //operations that depend on the components ofcomplex objects.You can define
    //a new operation over an object structuresimply by adding a new visitor.
    //In contrast, if you spread functionalityover many classes, then you must
    //change each class to define a newoperation.
    //2. A visitor gathers related operations and separates unrelated ones.Related
    //behavior isn't spread over the classes defining the objectstructure; it's
    //localized in a visitor.Unrelated sets of behavior arepartitioned in their
    //own visitor subclasses. That simplifies both theclasses defining the
    //elements and the algorithms defined in thevisitors.Any algorithm-specific
    //data structures can be hidden in thevisitor.
    //3. Adding new ConcreteElement classes is hard.The Visitor pattern makes it
    //hard to add new subclasses of Element.Eachnew ConcreteElement gives rise
    //to a new abstract operation on Visitor anda corresponding implementation
    //in every ConcreteVisitor class. Sometimes adefault implementation can be
    //provided in Visitor that can be inheritedby most of the ConcreteVisitors,
    //but this is the exception rather thanthe rule.
    //So the key consideration in applying the Visitor pattern is whether youare
    //mostly likely to change the algorithm applied over an objectstructure or
    //the classes of objects that make up the structure. TheVisitor class
    //hierarchy can be difficult to maintain when newConcreteElement classes are
    //added frequently.In such cases, it'sprobably easier just to define
    //operations on the classes that make upthe structure.If the Element class
    //hierarchy is stable, but you arecontinually adding operations or changing
    //algorithms, then the Visitorpattern will help you manage the changes.
    //4. Visiting across class hierarchies.An iterator(see Iterator (289)) can
    //visit the objects in astructure as it traverses them by calling their
    //operations.But an iteratorcan't work across object structures with
    //different types of elements.

    //Participants
    //· Visitor (NodeVisitor)
    //o declares a Visit operation for each class of ConcreteElement in the
    //object structure.The operation's name and signature identifies the
    //class that sends the Visit request to the visitor.That lets the
    //visitor determine the concrete class of the element being visited.
    //Then the visitor can access the element directly through its
    //particular interface.
    //· ConcreteVisitor(TypeCheckingVisitor)
    //o implements each operation declared by Visitor.Each operation
    //implements a fragment of the algorithm defined for the corresponding
    //class of object in the structure.ConcreteVisitor provides the
    //context for the algorithm and stores its local state.This state
    //often accumulates results during the traversal of the structure.
    //· Element (Node)
    //o defines an Accept operation that takes a visitor as an argument.
    //· ConcreteElement (AssignmentNode, VariableRefNode)
    //o implements an Accept operation that takes a visitor as an argument.
    //· ObjectStructure (Program)
    //o can enumerate its elements.
    //o may provide a high-level interface to allow the visitor to visit
    //its elements.
    //o may either be a composite(see Composite (183)) or a collection such
    //as a list or a set.

    public class Program
    {
        public static void Main(string[] args)
        {
            // emulate 1+2+3
            var e = new Addition(
              new Addition(
                new Literal(1),
                new Literal(2)
              ),
              new Literal(3)
            );
            var sb = new StringBuilder();
            var expressionPrinter = new ExpressionPrinter(sb);
            e.Accept(expressionPrinter);
            Console.WriteLine(sb);

            Console.Read();
        }
    }


    interface IExpressionVisitor
    {
        void Visit(Literal literal);
        void Visit(Addition addition);
    }

    interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }

    class Literal : IExpression
    {
        internal double Value { get; set; }

        public Literal(double value)
        {
            this.Value = value;
        }
        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Addition : IExpression
    {
        internal IExpression Left { get; set; }
        internal IExpression Right { get; set; }

        public Addition(IExpression left, IExpression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb;

        public ExpressionPrinter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Visit(Literal literal)
        {
            sb.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            sb.Append("(");
            addition.Left.Accept(this);
            sb.Append("+");
            addition.Right.Accept(this);
            sb.Append(")");
        }
    }
}