using System;

namespace DesignPatterns.GoF.Structural.Proxy
{
    //    Proxy is applicable whenever there is a need for a more versatile or sophisticated
    //reference to an object than a simple pointer.Here are several common situations
    //in which the Proxy pattern is applicable:
    //1. A remote proxy provides a local representative for an object in a different
    //address space.NEXTSTEP [Add94] uses the class NXProxy for this purpose.
    //Coplien[Cop92] calls this kind of proxy an "Ambassador."
    //2. A virtual proxy creates expensive objects on demand. The ImageProxy
    //described in the Motivation is an example of such a proxy.
    //3. A protection proxy controls access to the original object. Protection
    //proxies are useful when objects should have different access rights.For
    //example, KernelProxies in the Choices operating system [CIRM93] provide
    //protected access to operating system objects.
    //4. A smart reference is a replacement for a bare pointer that performs
    //additional actions when an object is accessed.Typical uses include
    //o counting the number of references to the real object so that it can
    //be freed automatically when there are no more references(also called
    //smart pointers [Ede92]).
    //o loading a persistent object into memory when it's first referenced.
    //o checking that the real object is locked before it's accessed to ensure
    //that no other object can change it.

    //    Benefits
    //Gives the ability to control access to an object, whether it's because of a
    //costly creation process of that object or security issues.

    //    Consequences
    //The Proxy pattern introduces a level of indirection when accessing an object.
    //The additional indirection has many uses, depending on the kind of proxy:
    //1. A remote proxy can hide the fact that an object resides in a different address
    //space.
    //2. A virtual proxy can perform optimizations such as creating an object on
    //demand.
    //3. Both protection proxies and smart references allow additional housekeeping
    //tasks when an object is accessed.


//    Participants

//The classes and objects participating in this pattern are:


//Proxy 
//maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject if the RealSubject and Subject interfaces are the same.
//provides an interface identical to Subject's so that a proxy can be substituted for for the real subject.
//controls access to the real subject and may be responsible for creating and deleting it.
//other responsibilites depend on the kind of proxy:
//remote proxies are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space.
//virtual proxies may cache additional information about the real subject so that they can postpone accessing it. For example, the ImageProxy from the Motivation caches the real images's extent.
//protection proxies check that the caller has the access permissions required to perform a request.
//Subject
//defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected.
//RealSubject
//defines the real object that the proxy represents.

    class MainApp
    {
        static void Main()
        {
            // Create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        public abstract void Request();
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    /// <summary>
    /// The 'Proxy' class
    /// </summary>
    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}