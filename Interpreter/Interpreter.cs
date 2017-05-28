using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Behavioural.Interpreter
{
//    Intent
//Given a language, define a represention for its grammar along with aninterpreter
//that uses the representation to interpret sentences in thelanguage.

//        Consequences
//The Interpreter pattern has the following benefits and liabilities:
//1. It's easy to change and extend the grammar.Because the pattern uses classes
//to represent grammar rules, you canuse inheritance to change or extend the
//grammar.Existing expressionscan be modified incrementally, and new
//expressions can be defined asvariations on old ones.
//2. Implementing the grammar is easy, too.Classes defining nodes in the abstract
//syntax tree have similarimplementations.These classes are easy to write,
//and often theirgeneration can be automated with a compiler or parser
//generator.
//3. Complex grammars are hard to maintain.The Interpreter pattern defines at
//least one class for every rulein the grammar(grammar rules defined using
//BNF may require multipleclasses). Hence grammars containing many rules can
//be hard tomanage and maintain.Other design patterns can be applied
//tomitigate the problem(see Implementation).But when the grammar is very
//complex, other techniques such asparser or compiler generators are more
//appropriate.
//4. Adding new ways to interpret expressions.The Interpreter pattern makes it
//easier to evaluate an expression in anew way. For example, you can support
//pretty printing ortype-checking an expression by defining a new operation
//on theexpression classes.If you keep creating new ways of interpreting
//anexpression, then consider using the Visitor(366) pattern to avoid
//changing the grammar classes.


//    Participants

    //    The classes and objects participating in this pattern are:

    //AbstractExpression  (Expression)
    //declares an interface for executing an operation
    //TerminalExpression(ThousandExpression, HundredExpression, TenExpression, OneExpression )
    //implements an Interpret operation associated with terminal symbols in the grammar.
    //an instance is required for every terminal symbol in the sentence.
    //NonterminalExpression  (not used )
    //one such class is required for every rule R::= R1R2...Rn in the grammar
    //maintains instance variables of type AbstractExpression for each of the symbols R1 through Rn.
    //implements an Interpret operation for nonterminal symbols in the grammar.Interpret typically calls itself recursively on the variables representing R1 through Rn.
    //Context  (Context)
    //contains information that is global to the interpreter
    //Client  (InterpreterApp)
    //builds (or is given) an abstract syntax tree representing a particular sentence in the language that the grammar defines.The abstract syntax tree is assembled from instances of the NonterminalExpression and TerminalExpression classes
    //invokes the Interpret operation

    class MainApp
    {
        static void Main()
        {
            var context = new Context();

            // Usually a tree
            var list = new List<AbstractExpression>();

            // Populate 'abstract syntax tree'
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            Console.ReadLine();
        }
    }

    // "Context"
    class Context
    {
    }

    // "AbstractExpression"
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // "TerminalExpression"
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    // "NonterminalExpression"
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }

}