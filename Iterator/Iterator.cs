using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Behavioural.Iterator
{
//    Intent
//Provide a way to access the elements of an aggregate objectsequentially without
//exposing its underlying representation.

//        Use the Iterator pattern
//· to access an aggregate object's contents without exposing its
//internalrepresentation.
//· to support multiple traversals of aggregate objects.
//· to provide a uniform interface for traversing different
//aggregatestructures(that is, to support polymorphic iteration).


//Consequences
//The Iterator pattern has three important consequences:
//1. It supports variations in the traversal of an aggregate.Complex aggregates
//may be traversed in many ways.For example, codegeneration and semantic
//checking involve traversing parse trees. Codegeneration may traverse the
//parse tree inorder or preorder.Iterators make it easy to change the
//traversal algorithm: Just replacethe iterator instance with a different
//one. You can also defineIterator subclasses to support new traversals.
//2. Iterators simplify the Aggregate interface.Iterator's traversal interface
//obviates the need for a similarinterface in Aggregate, thereby simplifying
//the aggregate's interface.
//3. More than one traversal can be pending on an aggregate.An iterator keeps
//track of its own traversal state. Therefore you canhave more than one
//traversal in progress at once.

//Participants

//    The classes and objects participating in this pattern are:

//Iterator  (AbstractIterator)
//defines an interface for accessing and traversing elements.
//ConcreteIterator(Iterator)
//implements the Iterator interface.
//keeps track of the current position in the traversal of the aggregate.
//Aggregate(AbstractCollection)
//defines an interface for creating an Iterator object
//ConcreteAggregate(Collection)
//implements the Iterator creation interface to return an instance of the proper ConcreteIterator

    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate
            Iterator i = a.GetIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    abstract class Aggregate
    {
        public abstract Iterator GetIterator();
    }

    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    class ConcreteAggregate : Aggregate
    {
        private List<object> _items = new List<object>();

        public override Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}