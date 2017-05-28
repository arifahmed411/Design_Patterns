using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Behavioural.Observer
{
    //    Intent
    //Define a one-to-many dependency between objects so that when oneobject changes
    //state, all its dependents are notified and updatedautomatically.

    //    Applicability
    //Use the Observer pattern in any of the following situations:
    //· When an abstraction has two aspects, one dependent on the
    //other.Encapsulating these aspects in separate objects lets you vary
    //andreuse them independently.
    //· When a change to one object requires changing others, and youdon't know
    //how many objects need to be changed.
    //· When an object should be able to notify other objects without
    //makingassumptions about who these objects are.In other words, you don'twant
    //these objects tightly coupled.

    //    Consequences
    //The Observer pattern lets you vary subjects and observersindependently.You can
    //reuse subjects without reusing theirobservers, and vice versa.It lets you add
    //observers withoutmodifying the subject or other observers.
    //Further benefits and liabilities of the Observer pattern include thefollowing:
    //1. Abstract coupling between Subject and Observer.All a subject knows is that
    //it has a list of observers, eachconforming to the simple interface of the
    //abstract Observer class.The subject doesn't know the concrete class of any
    //observer.Thus thecoupling between subjects and observers is abstract and
    //minimal.
    //Because Subject and Observer aren't tightly coupled, they can belong
    //todifferent layers of abstraction in a system. A lower-level subjectcan
    //communicate and inform a higher-level observer, thereby keeping
    //thesystem's layering intact. If Subject and Observer are lumpedtogether,
    //then the resulting object must either span two layers (andviolate the
    //layering), or it must be forced to live in one layer orthe other(which
    //might compromise the layering abstraction).
    //2. Support for broadcast communication.Unlike an ordinary request, the
    //notification that a subject sendsneedn't specify its receiver. The
    //notification is broadcastautomatically to all interested objects that
    //subscribed to it.Thesubject doesn't care how many interested objects exist;
    //its onlyresponsibility is to notify its observers. This gives you the
    //freedomto add and remove observers at any time. It's up to the observer
    //tohandle or ignore a notification.
    //3. Unexpected updates.Because observers have no knowledge of each other's
    //presence, they canbe blind to the ultimate cost of changing the subject.
    //A seeminglyinnocuous operation on the subject may cause a cascade of updates
    //toobservers and their dependent objects.Moreover, dependency criteriathat
    //aren't well-defined or maintained usually lead to spuriousupdates, which
    //can be hard to track down.
    //This problem is aggravated by the fact that the simple update
    //protocolprovides no details on what changed in the subject.
    //Withoutadditional protocol to help observers discover what changed, they
    //maybe forced to work hard to deduce the changes.

    //        Participants
    //· Subject
    //o knows its observers.Any number of Observer objects may observe a
    //subject.
    //o provides an interface for attaching and detaching Observer objects.
    //· Observer
    //o defines an updating interface for objects that should be notified
    //of changes in a subject.
    //· ConcreteSubject
    //o stores state of interest to ConcreteObserver objects.
    //o sends a notification to its observers when its state changes.
    //· ConcreteObserver
    //o maintains a reference to a ConcreteSubject object.
    //o stores state that should stay consistent with the subject's.
    //o implements the Observer updating interface to keep its state
    //consistent with the subject's.

        class MainApp
        {
            /// <summary>
            /// Entry point into console application.
            /// </summary>
            static void Main()
            {
                // Configure Observer pattern
                ConcreteSubject s = new ConcreteSubject();

                s.Attach(new ConcreteObserver(s, "X"));
                s.Attach(new ConcreteObserver(s, "Y"));
                s.Attach(new ConcreteObserver(s, "Z"));

                // Change subject and notify observers
                s.SubjectState = "ABC";
                s.Notify();

                // Wait for user
                Console.ReadKey();
            }
        }

        /// <summary>
        /// The 'Subject' abstract class
        /// </summary>
        abstract class Subject
        {
            private List<IObserver> _observers = new List<IObserver>();

            public void Attach(IObserver observer) => _observers.Add(observer);

            public void Detach(IObserver observer) => _observers.Remove(observer);

            public void Notify() => _observers.ForEach(o => o.Update());

        }

        /// <summary>
        /// The 'ConcreteSubject' class
        /// </summary>
        class ConcreteSubject : Subject
        {
            private string _subjectState;

            // Gets or sets subject state
            public string SubjectState
            {
                get { return _subjectState; }
                set { _subjectState = value; }
            }
        }

        /// <summary>
        /// The 'Observer' interface
        /// </summary>
        public interface IObserver
        {
            void Update();
        }

        /// <summary>
        /// The 'ConcreteObserver' class
        /// </summary>
        class ConcreteObserver : IObserver
        {
            private string _name;
            private string _observerState;
            private ConcreteSubject _subject;

            // Constructor
            public ConcreteObserver(
              ConcreteSubject subject, string name)
            {
                this._subject = subject;
                this._name = name;
            }

            public void Update()
            {
                _observerState = _subject.SubjectState;
                Console.WriteLine("Observer {0}'s new state is {1}",
                  _name, _observerState);
            }

            // Gets or sets subject
            public ConcreteSubject Subject
            {
                get { return _subject; }
                set { _subject = value; }
            }
        }
    }