using System;
using System.Collections.Generic;

namespace DesignPatterns.GoF.Creational.Prototype
{

    //    Use the Prototype pattern when a system should be independent of how its products
    //are created, composed, and represented; and
    //· when the classes to instantiate are specified at run-time, for example,
    //by dynamic loading; or
    //· to avoid building a class hierarchy of factories that parallels the class
    //hierarchy of products; or
    //· when instances of a class can have one of only a few different combinations
    //of state.It may be more convenient to install a corresponding number of
    //prototypes and clone them rather than instantiating the class manually,
    //each time with the appropriate state.

//        Benefits
//•Speeds up instantiation of large, dynamically loaded classes.
//•Reduced subclassing.

    //One of the downsides to this pattern is that the process of copying an object can be complicated. Also, classes that have circular references to other classes are difficult to clone. Overuse of the pattern could affect performance, as the prototype object itself would need to be instantiated if you use a registry of prototypes. 

    enum Name { Tom, Dick, Harry}

    public class PrototypeFactory
    {
        public static void Main(String[] args)
        {
            IPerson p;

            foreach (Name n in Enum.GetValues(typeof(Name)))
            {
                p = Factory.GetPrototype(n);
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            foreach (Name n in Enum.GetValues(typeof(Name)))
            {
                p = Factory.GetPrototype(n);
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();

        }
    }


    interface IPerson
    {
        IPerson getPrototype();
    }

    class Tom : IPerson
    {
        private readonly Name name = Name.Tom;

        public IPerson getPrototype() => new Tom();

        public override String ToString() => name.ToString();
    }

    class Dick : IPerson
    {
        private readonly Name name = Name.Dick;

        public IPerson getPrototype() => new Dick();

        public override String ToString() => name.ToString();
    }

    class Harry : IPerson
    {
        private readonly Name name = Name.Harry;

        public IPerson getPrototype() => new Harry();

        public override String ToString() => name.ToString();
    }

    class Factory
    {
        private static readonly Dictionary<Name, IPerson> prototypes = new Dictionary<Name, IPerson>();

        //static Factory()
        //{
        //    prototypes.Add(Name.Tom, new Tom());
        //    prototypes.Add(Name.Dick, new Dick());
        //    prototypes.Add(Name.Harry, new Harry());
        //}

        public static IPerson GetPrototype(Name type)
        {
            if (prototypes.TryGetValue(type, out IPerson p))
            {
                return p.getPrototype();
            }
            else
            {
                Console.WriteLine("Creating prototype for " + type.ToString());
                switch (type)
                {
                    case Name.Tom:
                        p = new Tom();
                        break;
                    case Name.Dick:
                        p = new Dick();
                        break;
                    case Name.Harry:
                        p = new Harry();
                        break;
                    default:
                        break;
                }
                prototypes.Add(type, p);
                return p.getPrototype();
            }
        }
    }

}