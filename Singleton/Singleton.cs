using System;

namespace DesignPatterns.GoF.Creational.SingleTon
{
//    Use the Singleton pattern when
//· there must be exactly one instance of a class, and it must be accessible
//to clients from a well-known access point.
//· when the sole instance should be extensible by subclassing, and clients
//should be able to use an extended instance without modifying their code.

//        Benefits
//•Controlled access to unique instance.
//•Reduced name space.
//•Allows refinement of operations and representations.

//Drawbacks
//Singleton pattern is also considered an anti-pattern by some people, who feel
//that it is overused, introducing unnecessary limitations in situations where a
//sole instance of a class is not actually required.

    class MainApp
    {
        static void Main()
        {
            // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user
            Console.ReadKey();
        }
    }


    class Singleton
    {
        private static Singleton _instance;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}