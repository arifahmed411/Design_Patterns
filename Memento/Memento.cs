using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Behavioural.Memento
{
    //    Intent
    //    Without violating encapsulation, capture and externalize an object'sinternal
    //state so that the object can be restored to this state later.

    //    Use the Memento pattern when
    //· a snapshot of(some portion of) an object's state must be saved sothat it
    //can be restored to that state later, and
    //· a direct interface to obtaining the state would expose implementation
    //details and break the object's encapsulation.

    //    Consequences
    //The Memento pattern has several consequences:
    //1. Preserving encapsulation boundaries.Memento avoids exposing information
    //that only an originator shouldmanage but that must be stored nevertheless
    //outside the originator.The pattern shields other objects from potentially
    //complex Originatorinternals, thereby preserving encapsulation boundaries.
    //2. It simplifies Originator.In other encapsulation-preserving designs,
    //Originator keeps theversions of internal state that clients have requested.
    //That puts allthe storage management burden on Originator.Having
    //clientsmanage the state they ask for simplifies Originator and keepsclients
    //from having to notify originators when they're done.
    //3. Using mementos might be expensive.Mementos might incur considerable
    //overhead if Originator must copylarge amounts of information to store in
    //the memento or if clientscreate and return mementos to the originator often
    //enough. Unless encapsulating and restoring Originator state is cheap, the
    //patternmight not be appropriate.See the discussion of incrementality in
    //theImplementation section.
    //4. Defining narrow and wide interfaces.It may be difficult in some languages
    //to ensure that only theoriginator can access the memento's state.
    //5. Hidden costs in caring for mementos.A caretaker is responsible for deleting
    //the mementos it cares for.However, the caretaker has no idea how much state
    //is in the memento.Hence an otherwise lightweight caretaker might incur large
    //storagecosts when it stores mementos.

    //Participants
    //· Memento(SolverState)
    //o stores internal state of the Originator object. The memento may store
    //as much or as little of the originator's internal state as necessary
    //at its originator's discretion.
    //o protects against access by objects other than the originator.
    //Mementos have effectively two interfaces. Caretaker sees a narrow
    //interface to the Memento—it can only pass the memento to other objects.
    //Originator, in contrast, sees a wide interface, one that lets it
    //access all the data necessary to restore itself to its previous state.
    //Ideally, only the originator that produced the memento would be
    //permitted to access the memento's internal state.
    //· Originator (ConstraintSolver)
    //o creates a memento containing a snapshot of its current internal
    //state.
    //o uses the memento to restore its internal state.
    //· Caretaker(undo mechanism)
    //o is responsible for the memento's safekeeping.
    //o never operates on or examines the contents of a memento.

    public class MementoExample
    {
        public static void Main(String[] args)
        {
            Caretaker caretaker = new Caretaker();
            Originator originator = new Originator();
            originator.Set("State1");
            originator.Set("State2");
            caretaker.AddMemento(originator.SaveToMemento());
            originator.Set("State3");
            caretaker.AddMemento(originator.SaveToMemento());
            originator.Set("State4");
            originator.RestoreFromMemento(caretaker.GetMemento(1));

            Console.ReadLine();
        }

        public class Originator
        {
            private String state;

            public void Set(String state)
            {
               Console.WriteLine("Originator: Setting state to " + state);
                this.state = state;
            }
            public Object SaveToMemento()
            {
                Console.WriteLine("Originator: Saving to Memento.");
                return new Memento(state);
            }
            public void RestoreFromMemento(Object m)
            {
                if (m is Memento) {
                    Memento memento = (Memento)m;
                    state = memento.GetSavedState();
                    Console.WriteLine("Originator: State after restoring from Memento: " + state);
                }
            }
        }

        public class Memento
        {
            private String state;
            public Memento(String stateToSave)
            {
                state = stateToSave;
            }
            public String GetSavedState()
            {
                return state;
            }
        }

        public class Caretaker
        {
            private List<Object> savedStates = new List<Object>();
            public void AddMemento(Object m)
            {
                savedStates.Add(m);
            }
            public Object GetMemento(int index)
            {
                return savedStates[index];
            }
        }

    }
}