using System;

namespace DesignPatterns.GoF.Behavioural.State
{
    //    Intent
    //Allow an object to alter its behavior when its internal state changes.The object
    //will appear to change its class.

    //    Applicability
    //Use the State pattern in either of the following cases:
    //· An object's behavior depends on its state, and it must change itsbehavior
    //at run-time depending on that state.
    //· Operations have large, multipart conditional statements that depend onthe
    //object's state. This state is usually represented by one or moreenumerated
    //constants.Often, several operations will contain this same conditional
    //structure.The State pattern puts each branch of theconditional in a
    //separate class. This lets you treat the object'sstate as an object in its
    //own right that can vary independently fromother objects.


    //    Consequences
    //The State pattern has the following consequences:
    //1. It localizes state-specific behavior and partitionsbehavior for different
    //states.The State pattern puts all behavior associated with a particular
    //stateinto one object. Because all state-specific code lives in a
    //Statesubclass, new states and transitions can be added easily by definingnew
    //subclasses.
    //An alternative is to use data values to define internal states andhave
    //Context operations check the data explicitly.But then we'dhave look-alike
    //conditional or case statements scattered throughoutContext's
    //implementation.Adding a new state could requirechanging several
    //operations, which complicates maintenance.
    //The State pattern avoids this problem but might introduce another, because
    //the pattern distributes behavior for different states acrossseveral State
    //subclasses.This increases the number of classes and isless compact than
    //a single class. But such distribution is actuallygood if there are many
    //states, which would otherwise necessitate largeconditional statements.
    //Like long procedures, large conditional statements are undesirable.They're
    //monolithic and tend to make the code less explicit, whichin turn makes them
    //difficult to modify and extend.The State patternoffers a better way to
    //structure state-specific code. The logic thatdetermines the state
    //transitions doesn't reside in monolithicif or switch statements but instead
    //is partitionedbetween the State subclasses. Encapsulating each state
    //transition andaction in a class elevates the idea of an execution state
    //to fullobject status.That imposes structure on the code and makes itsintent
    //clearer.
    //2. It makes state transitions explicit.When an object defines its current state
    //solely in terms of internaldata values, its state transitions have no
    //explicit representation; they only show up as assignments to some variables.
    //Introducingseparate objects for different states makes the transitions
    //moreexplicit. Also, State objects can protect the Context frominconsistent
    //internal states, because state transitions are atomicfrom the Context's
    //perspective—they happen by rebinding onevariable(the Context's State
    //object variable), notseveral[dCLF93].
    //3. State objects can be shared.If State objects have no instance variables—that
    //is, the state theyrepresent is encoded entirely in their type—then contexts
    //can sharea State object. When states are shared in this way, they
    //areessentially flyweights (see Flyweight (218)) with nointrinsic state,
    //only behavior.


    //        Participants
    //· Context(TCPConnection)
    //o defines the interface of interest to clients.
    //o maintains an instance of a ConcreteState subclass that defines
    //thecurrent state.
    //· State (TCPState)
    //o defines an interface for encapsulating the behavior associated with
    //aparticular state of the Context.
    //· ConcreteState subclasses (TCPEstablished, TCPListen, TCPClosed)
    //o each subclass implements a behavior associated with a state ofthe
    //Context.

    public class DemoOfClientState
    {
        public static void Main(String[] args)
        {
            Context sc = new Context();

            sc.writeName("Monday");
            sc.writeName("Tuesday");
            sc.writeName("Wednesday");
            sc.writeName("Thursday");
            sc.writeName("Friday");
            sc.writeName("Saturday");
            sc.writeName("Sunday");

            Console.ReadLine();
        }
    }


    public interface State
    {
        void writeName(Context context, String name);
    }

    public class StateLowerCase : State
    {
    public void writeName(Context context, String name)
    {
        Console.WriteLine(name.ToLower());
        context.setState(new StateMultipleUpperCase());
    }
}

    public class StateMultipleUpperCase : State
    {
        /** Counter local to this state */
        private int count = 0;

        public void writeName(Context context, String name)
        {
            Console.WriteLine(name.ToUpper());
            /* Change state after StateMultipleUpperCase's writeName() gets invoked twice */
            if (++count > 1)
            {
                context.setState(new StateLowerCase());
            }
        }
    }

    public class Context
    {
        private State myState;
        public Context()
        {
            setState(new StateLowerCase());
        }

        /**
         * Setter method for the state.
         * Normally only called by classes implementing the State interface.
         * @param newState the new state of this context
         */
        public void setState(State newState)
        {
            myState = newState;
        }

        public void writeName(String name)
        {
            myState.writeName(this, name);
        }
    }


}