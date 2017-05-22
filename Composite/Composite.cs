using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Structural.Composite
{

//    Definition
//The Composite pattern helps you to create tree structures of objects without
//the need to force clients to differentiate between branches and leaves
//regarding usage.The Composite pattern lets clients treat individual objects
//and compositions of objects uniformly.

//    Use the Composite pattern when
//· you want to represent part-whole hierarchies of objects.
//· you want clients to be able to ignore the difference between compositions
//of objects and individual objects.Clients will treat all objects in the
//composite structure uniformly.

//        Benefits
//•Define class hierarchies consisting of primitive objects and composite
//objects.
//•Makes it easier to add new kind of components.

//        Drawbacks/consequences
//The Composite pattern makes it easy for you to add new kinds of components
//to your collection as long as they support a similar programming interface. On
//the other hand, this has the disadvantage of making your system overly
//general.You might find it harder to restrict certain classes where this would
//normally be desirable.


    //    Participants

    //    The classes and objects participating in this pattern are:

    //Component   (DrawingElement)
    //declares the interface for objects in the composition.
    //implements default behavior for the interface common to all classes, as appropriate.
    //declares an interface for accessing and managing its child components.
    //(optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate.
    //Leaf(PrimitiveElement)
    //represents leaf objects in the composition.A leaf has no children.
    //defines behavior for primitive objects in the composition.
    //Composite   (CompositeElement)
    //defines behavior for components having children.
    //stores child components.
    //implements child-related operations in the Component interface.
    //Client(CompositeApp)
    //manipulates objects in the composition through the Component interface.


    /// <summary>
    /// MainApp startup class for Structural 
    /// Composite Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create a tree structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class Component
    {
        protected string name;

        // Constructor
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        // Constructor
        public Composite(string name)
          : base(name)
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
          : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}