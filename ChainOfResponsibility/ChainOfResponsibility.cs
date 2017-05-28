using System;

namespace DesignPatterns.GoF.Behavioural.ChainOfResponsibility
{
//    Intent
//Avoid coupling the sender of a request to its receiver by giving morethan one
//object a chance to handle the request.Chain the receiving objects and pass the
//request along the chain until an objecthandles it.

    //    Use Chain of Responsibility when
    //· more than one object may handle a request, and the handler isn't knowna
    //priori.The handler should be ascertained automatically.
    //· you want to issue a request to one of several objects withoutspecifying
    //the receiver explicitly.
    //· the set of objects that can handle a request should be specified dynamically.

    //    Chain of Responsibility has the following benefits and liabilities:
    //1. Reduced coupling.The pattern frees an object from knowing which other object
    //handles a request.An object only has to know that a request will be
    //handled"appropriately." Both the receiver and the sender have no
    //explicitknowledge of each other, and an object in the chain doesn't have
    //toknow about the chain's structure.
    //As a result, Chain of Responsibility can simplify objectinterconnections.
    //Instead of objects maintaining references to allcandidate receivers, they
    //keep a single reference to their successor.
    //2. Added flexibility in assigning responsibilities to objects.Chain of
    //Responsibility gives you added flexibility in
    //distributingresponsibilities among objects.You can add or
    //changeresponsibilities for handling a request by adding to or
    //otherwisechanging the chain at run-time.You can combine this with
    //subclassingto specialize handlers statically.
    //3. Receipt isn't guaranteed.Since a request has no explicit receiver, there's
    //no guaranteeit'll be handled—the request can fall off the end of the
    //chainwithout ever being handled. A request can also go unhandled when
    //thechain is not configured properly.


    //    Participants

    //The classes and objects participating in this pattern are:


    //Handler
    //defines an interface for handling the requests
    //(optional) implements the successor link
    //ConcreteHandler
    //handles requests it is responsible for
    //can access its successor
    //if the ConcreteHandler can handle the request, it does so; otherwise it forwards the request to its successor
    //Client
    //initiates the request to a ConcreteHandler object on the chain


    public class ChainDemo
    {
        public static void Main(String[] args)
        {
            Handler chain_root = new SingleDigitHandler();
            chain_root.Add(new DoubleDigitHandler());
            chain_root.Add(new LargeDigitHandler());

            //wrap around root node - depends how you want to implement your chain
            //chain_root.Add(chain_root);

            Random randGenarator = new Random();
            for (int i = 1; i <= 10; i++)
                chain_root.Handle(randGenarator.Next(1000));

            Console.ReadLine();
        }
    }

    public abstract class Handler
    {
        protected static Random s_rn = new Random();
        protected static int s_next = 1;
        protected int m_id = s_next++;
        protected Handler m_next;

        public void Add(Handler next)
        {
            if (m_next == null)
                m_next = next;
            else
                m_next.Add(next);
        }

        public int getNumberOfDigits(int num)
        {
            return (int)Math.Floor(Math.Log10(num) + 1);
        }
        public abstract void Handle(int num);
    }

    public class SingleDigitHandler : Handler
    {
        public override void Handle(int num)
        {
            if (getNumberOfDigits(num) == 1)
                Console.WriteLine(m_id + "-handled-" + num);
            else
            {
                Console.WriteLine(m_id + "-busy ");
                m_next.Handle(num);
            }
                
        }
    }

    public class DoubleDigitHandler : Handler
    {
        public override void Handle(int num)
        {
            if (getNumberOfDigits(num) == 2)
                Console.WriteLine(m_id + "-handled-" + num);
            else 
            {
                Console.WriteLine(m_id + "-busy ");
                m_next.Handle(num);
            }
        }
    }

    public class LargeDigitHandler : Handler
    {
        public override void Handle(int num)
        {
            if (getNumberOfDigits(num) >= 3)
                Console.WriteLine(m_id + "-handled-" + num);
            else
            {
                Console.WriteLine(m_id + "-busy ");
                m_next.Handle(num);
            }
                
        }
    }

}