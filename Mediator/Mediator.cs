using System;

namespace DesignPatterns.GoF.Behavioural.Mediator
{
//    Intent
//Define an object that encapsulates how a set of objects interact.Mediator promotes
//loose coupling by keeping objects from referring toeach other explicitly, and
//it lets you vary their interactionindependently.

    //    Use the Mediator pattern when
    //· a set of objects communicate in well-defined but complex ways.Theresulting
    //interdependencies are unstructured and difficult tounderstand.
    //· reusing an object is difficult because it refers to and communicateswith
    //many other objects.
    //· a behavior that's distributed between several classes should
    //becustomizable without a lot of subclassing.

    //    Consequences
    //The Mediator pattern has the following benefits and drawbacks:
    //1. It limits subclassing.A mediator localizes behavior that otherwise would
    //be distributed amongseveral objects.Changing this behavior requires
    //subclassing Mediatoronly; Colleague classes can be reused as is.
    //2. It decouples colleagues.A mediator promotes loose coupling between
    //colleagues.You can varyand reuse Colleague and Mediator classes
    //independently.
    //3. It simplifies object protocols.A mediator replaces many-to-many
    //interactions with one-to-manyinteractions between the mediator and its
    //colleagues.One-to-manyrelationships are easier to understand, maintain,
    //and extend.
    //4. It abstracts how objects cooperate.Making mediation an independent concept
    //and encapsulating it in anobject lets you focus on how objects interact
    //apart from theirindividual behavior. That can help clarify how objects
    //interact in asystem.
    //5. It centralizes control.The Mediator pattern trades complexity of
    //interaction for complexity inthe mediator.Because a mediator encapsulates
    //protocols, it can becomemore complex than any individual colleague. This
    //can make the mediatoritself a monolith that's hard to maintain.

    //        Participants
    //· Mediator(DialogDirector)
    //o defines an interface for communicating with Colleague objects.
    //· ConcreteMediator (FontDialogDirector)
    //o implements cooperative behavior by coordinating Colleague objects.
    //o knows and maintains its colleagues.
    //· Colleague classes (ListBox, EntryField)
    //o each Colleague class knows its Mediator object.
    //o each colleague communicates with its mediator whenever it would have
    //otherwise communicated with another colleague.

    public delegate void MessageReceivedEventHandler(string message, string from);

    class MainApp
    {
        static void Main()
        {
            Mediator m = new Mediator();
            Person p1 = new Person(m, "Arif");
            Person p2 = new Person(m, "Ahmed");

            p1.Send("How are you?");
            p2.Send("Fine, thanks");

            // Wait for user
            Console.ReadKey();
        }
    }

    public class Mediator
    {
        public event MessageReceivedEventHandler MessageReceived;

        public void Send(string message, string from)
        {
            if (MessageReceived != null)
            {
                Console.WriteLine("Sending '{0}' from {1}", message, from);
                MessageReceived(message, from);
            }
        }
    }

    public class Person
    {
        private Mediator _mediator;

        public string Name { get; set; }

        public Person(Mediator mediator, string name)
        {
            Name = name;
            _mediator = mediator;
            _mediator.MessageReceived += new MessageReceivedEventHandler(Receive);
        }

        private void Receive(string message, string from)
        {
            if (from != Name)
                Console.WriteLine("{0} received '{1}' from {2}", Name, message, from);
        }

        public void Send(string message)
        {
            _mediator.Send(message, Name);
        }
    }
}
