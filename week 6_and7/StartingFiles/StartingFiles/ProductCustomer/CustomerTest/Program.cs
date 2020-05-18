using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProductClasses;

//Original provided for class, copypasta and changed variable, and method names

namespace CustomerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //test all the things!
            //TestCustomerConstructors();
            //TestCustomerToString();
            //TestCustomerPropertyGetters();
            //TestCustomerPropertySetters();
            TestCustomerEquals();
            TestCustomerGetHashCode();
            TestCustomerListIndexer();
            TestCustomerEqualityOperator();
            TestCustomerInequalityOperator();
            Console.ReadLine();
        }

        // test constructors
        static void TestCustomerConstructors()
        {
            Customer c1 = new Customer(); // default constructor
            Customer c2 = new Customer(1, "Jenny", "Smith", "example@email.com", "541-867-5309"); // id, firstName, lastName, email, phone   Override Cosntructor 

            // interactive testing
            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. \n" + c1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 1, Jenny, Smith, example@email.com , 541-867-5309 \n" + c2.ToString());
            Console.WriteLine();
        }

        // test tostring
        static void TestCustomerToString()
        {
            Customer c1 = new Customer(1, "Jenny", "Smith", "example@email.com", "541-867-5309"); // override constructor

            // interactive testing
            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 1, Jenny, Smith, example@email.com , 541-867-5309 \n" + c1.ToString()); // using direct tostring override
            Console.WriteLine("Expecting 1, Jenny, Smith, example@email.com , 541-867-5309 \n" + c1); // using getter to string
            Console.WriteLine();
        }

        // test getters
        static void TestCustomerPropertyGetters()
        {
            Customer c1 = new Customer(1, "Jenny", "Smith", "example@email.com", "541-867-5309"); // override constructor

            // interactive testing
            Console.WriteLine("Testing getters"); 
            Console.WriteLine("Id.  Expecting 1. " + c1.Id); // test getter for c1 obj
            Console.WriteLine("FirstName.  Expecting Jenny. " + c1.FirstName); // test getter for FirstName
            Console.WriteLine("LastName.  Expecting Smith " + c1.LastName); // test getter for LastName
            Console.WriteLine("Email.  Expecting email@example.com. " + c1.Email); // test getter for Email
            Console.WriteLine("Phone.  Expecting 541-867-5309. " + c1.Phone); // test getter for Phone
            Console.WriteLine();
        }

        // test setters
        static void TestCustomerPropertySetters()
        {
            Customer c1 = new Customer(1, "Jenny", "Smith", "example@email.com", "541-867-5309"); // override constructor
            
            // interactive testing
            Console.WriteLine("Testing setters");
            c1.Id = 2; // changing c1 ID to 2
            c1.FirstName = "The"; // changing first name to
            c1.LastName = "Doctor"; // changing last name to doctor
            c1.Email = "doctor@who.com"; // changing email to doctor@who.com
            c1.Phone = "07700 900461"; // changing phone
            Console.WriteLine("Expecting 2, The, Doctor, doctor@who.com, 07700 900461 \n" + c1); // outting what it did
            Console.WriteLine();
        }

        #region CustomerClassTestingadded
        static void TestCustomerEquals()
        {
            // these 2 objects should be equal.  They reference the same object.
            Customer c1 = new Customer(1, "herp@derp.com", "Karen", "Complains", "541-867-5309");
            Customer c1Reference = c1;
            // these 2 objects should be equal after overridding Equals.  The attribute values are all equal.
            Customer c2 = new Customer(1, "herp@derp.com", "Karen", "Complains", "541-867-5309");

            Console.WriteLine("Testing customer equals.");
            Console.WriteLine("2 references to the same object.  Expecting true. " + c1.Equals(c1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. " + c1.Equals(c2));
            Console.WriteLine();

        }

        static void TestCustomerGetHashCode()
        {
            Customer c1 = new Customer(1, "test@email.com", "firstname","lastname", "000-000-0000");
            // these 2 objects should have the same hashcode.  The attribute values are all equal.
            Customer c2 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");
            // this one should have a unique hashcode
            Customer c3 = new Customer(3, "admin@email.com", "firstnone", "lastnone", "555-555-5555");

            Console.WriteLine("Testing customer GetHashCode");
            Console.WriteLine("2 object that have the same properties should have the same hashcode.  Expecting true. " + (c1.GetHashCode() == c2.GetHashCode()));
            Console.WriteLine("2 object that have different properties should have different hashcodes.  Expecting false. " + (c1.GetHashCode() == c3.GetHashCode()));

            // this will fail before overriding GetHashCode
            HashSet<Customer> set = new HashSet<Customer>();
            set.Add(c1);
            set.Add(c3);
            Console.WriteLine("Testing customer GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find an object with the same attributes.  Expecting true. " + set.Contains(c2));

            Console.WriteLine();
        }

        static void TestCustomerListIndexer()
        {
            // test fails before I add equals to customer
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");    
            Customer c2 = new Customer(3, "admin@email.com", "firstnone", "lastnone", "555-555-5555");
            // add each to list
            list += c1;
            list += c2;
            //save something first
            list.Save();
            // pull it back
            list.Fill();

            Console.WriteLine("Testing customer list indexer");
            Console.WriteLine("Index 0.  Expecting first customer in list to be test@email.com \n" + list[0]);
            Console.WriteLine("Index 'admin@email.com'.  Expecting product with email of 'admin@email.com' \n" + list["admin@email.com"]);
            Console.WriteLine();
        }

        static void TestCustomerEqualityOperator()
        {
            // these 2 objects should be equal.  They reference the same object.
            Customer c1 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");
            Customer c1Reference = c1;
            // these 2 objects should be equal after overridding Equals.  The attribute values are all equal.
            Customer c2 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");

            Console.WriteLine("Testing Customer ==");
            Console.WriteLine("2 references to the same object.  Expecting true. \n" + (c1 == c1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. \n" + (c1 == c2));
            Console.WriteLine();
        }

        static void TestCustomerInequalityOperator()
        {
            // these 2 objects should be equal after overridding Equals.  The attribute values are all equal.
            Customer c1 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");
            Customer c2 = new Customer(1, "test@email.com", "firstname", "lastname", "000-000-0000");
            // this one should not be equal
            Customer c3 = new Customer(3, "admin@email.com", "firstnone", "lastnone", "555-555-5555");

            Console.WriteLine("Testing customer !=");
            Console.WriteLine("2 objects that have the same properties should be equal.  Expecting false. " + (c1 != c2));
            Console.WriteLine("2 objecst that have different properties should not be equal.  Expecting true. " + (c1 != c3));
            Console.WriteLine();
        }
        #endregion
    }
}
