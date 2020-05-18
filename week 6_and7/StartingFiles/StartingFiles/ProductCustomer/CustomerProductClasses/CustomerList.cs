using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class CustomerList
    {
        #region CustomerListClass Fields
        //declare private list of customers for in class usage
        private List<Customer> customers;
        #endregion

        #region CustomerListClass Properties (and overrides)

        //enable getting count 
        public int Count
        {
            get
            {
                return customers.Count;
            }
        }

        // enable usage like a list for [] int
        public Customer this[int i]
        {
            get
            {
                return customers[i];
            }
            set
            {
                customers[i] = value;
            }
        }
        // enable usage lookup by email
        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in customers)
                {
                    if (c.Email == email)
                        return c;
                }
                return null;
            }
        }

        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator +(Customer c, CustomerList cl)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            cl.Remove(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                cl.customers.RemoveAt(0);
            }
            return cl;
        }

        //overriding tostring to allow easy descriptive output
        public override string ToString()
        {
            string output = "";
            foreach (Customer c in customers)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

        #endregion

        #region CustomerListClass Methods
        // create constructor
        public CustomerList()
        {
            customers = new List<Customer>();
        }

        #region CustomerListClass helpers

        //grabs customers from db
        public void Fill()
        {
            customers = CustomerDB.GetCustomers();
        }

        //Call to save in dbclass
        public void Save()
        {
            CustomerDB.SaveCustomers(customers);
        }

        //add blank customer?
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        //add customer
        public void Add(int id, string email, string firstName, string lastName, string phone)
        {
            Customer c = new Customer(id, email, firstName, lastName, phone);
            customers.Add(c);
        }

        //remove customer
        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }
        #endregion
        #endregion


    }
}
