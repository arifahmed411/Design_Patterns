using System;

namespace DesignPatterns.GoF.Behavioural.Command
{
    //    Intent
    //Encapsulate a request as an object, thereby letting you parameterizeclients with
    //different requests, queue or log requests, and supportundoable operations.

    //    Use the Command pattern when you want to
    //· parameterize objects by an action to perform, as MenuItem objects did above.
    //You can express such parameterization in a procedural language with a
    //callback function, that is, a function that's registered somewhere to be
    //called at a later point.Commands are an object-oriented replacement for
    //callbacks.
    //specify, queue, and execute requests at different times. A Command object
    //can have a lifetime independent of the original request. If the receiver
    //of a request can be represented in an address space-independent way, then
    //you can transfer a command object for the request to a different process
    //and fulfill the request there.
    //· support undo. The Command's Execute operation can store state for reversing
    //its effects in the command itself.The Command interface must have an added
    //Unexecute operation that reverses the effects of a previous call to Execute.
    //Executed commands are stored in a history list.Unlimited-level undo and
    //redo is achieved by traversing this list backwards and forwards calling
    //Unexecute and Execute, respectively.
    //· support logging changes so that they can be reapplied in case of a system
    //crash. By augmenting the Command interface with load and store operations,
    //you can keep a persistent log of changes.Recovering from a crash involves
    //reloading logged commands from disk and reexecuting them with the Execute
    //operation.
    //· structure a system around high-level operations built on primitives
    //operations.Such a structure is common in information systems that support
    //transactions.A transaction encapsulates a set of changes to data.The
    //Command pattern offers a way to model transactions.Commands have a common
    //interface, letting you invoke all transactions the same way.The pattern
    //also makes it easy to extend the system with new transactions.

    //    Consequences
    //The Command pattern has the following consequences:
    //1. Command decouples the object that invokes the operation from the onethat
    //knows how to perform it.
    //2. Commands are first-class objects. They can be manipulated and extendedlike
    //any other object.
    //3. You can assemble commands into a composite command.An example is
    //theMacroCommand class described earlier.In general, composite commandsare
    //an instance of the Composite(183) pattern.
    //4. It's easy to add new Commands, because you don't have to changeexisting
    //classes.

//    Participants

//The classes and objects participating in this pattern are:


//Command  (Command)
//declares an interface for executing an operation
//ConcreteCommand(CalculatorCommand)
//defines a binding between a Receiver object and an action
//implements Execute by invoking the corresponding operation(s) on Receiver
//Client(CommandApp)
//creates a ConcreteCommand object and sets its receiver
//Invoker(User)
//asks the command to carry out the request
//Receiver(Calculator)
//knows how to perform the operations associated with carrying out the request.

    /** Test class */
    public class TestCommand
    {
        public static void Main(String[] args)
        {
            Light l = new Light();
            ICommand switchUp = new TurnOnLightCommand(l);
            ICommand switchDown = new TurnOffLightCommand(l);
            Switch s = new Switch(switchUp, switchDown);
            s.FlipUp();
            s.FlipDown();

            Console.ReadLine();
        }
    }

    /** Command interface */
    public interface ICommand
    {
        void Execute();
    }

    /** The Command for turning on the light */
    public class TurnOnLightCommand : ICommand
    {
        private Light theLight;
        public TurnOnLightCommand(Light light)
        {
            this.theLight = light;
        }
        public void Execute()
        {
            theLight.TurnOn();
        }
    }

    /** The Command for turning off the light */
    public class TurnOffLightCommand : ICommand
    {
        private Light theLight;
        public TurnOffLightCommand(Light light)
        {
            this.theLight = light;
        }
        public void Execute()
        {
            theLight.TurnOff();
        }
    }

    /** Receiver class */
    public class Light
    {
        public Light() { }
        public void TurnOn()
        {
            Console.WriteLine("The light is on");
        }
        public void TurnOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    /** Invoker class*/
    public class Switch
    {
        private ICommand flipUpCommand;
        private ICommand flipDownCommand;
        public Switch(ICommand flipUpCmd, ICommand flipDownCmd)
        {
            this.flipUpCommand = flipUpCmd;
            this.flipDownCommand = flipDownCmd;
        }
        public void FlipUp()
        {
            flipUpCommand.Execute();
        }
        public void FlipDown()
        {
            flipDownCommand.Execute();
        }
    }
}
