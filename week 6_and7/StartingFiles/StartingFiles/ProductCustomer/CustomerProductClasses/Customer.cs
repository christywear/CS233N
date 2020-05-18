using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class Customer
    {
        // our fields
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;

        // our properties or getters and setters for our fields
        public int Id 
        { 
            get 
            { 
                return id; 
            } 
            set 
            { 
                id = value; 
            } 
        }

        public string FirstName 
        { 
            get 
            { 
                return firstName; 
            } 
            set 
            { 
                firstName = value; 
            } 
        }

        public string LastName 
        {
            get 
            { 
                return lastName; 
            } 
            set 
            { 
                lastName = value; 
            } 
        }

        public string Email 
        {
            get 
            { 
                return email; 
            } 
            set 
            { 
                email = value; 
            } 
        }

        public string Phone 
        { 
            get 
            { 
                return phone; 
            } 
            set 
            { 
                phone = value; 
            } 
        }

        public Customer() { } // default constructor

        public Customer(int customerid, string firstName, string lastName, string email, string phone) // override constructor
        {
            Id = customerid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
        }

        //tostring override.
        public override string ToString()
        {
            return String.Format("Id: {0} firstName: {1} lastName: {2} email: {3} phone: {4}", id, firstName, lastName, email, phone);
        }

        //lets add some overrides

        //override equal operator assignment
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;
                return other.Id == Id &&
                    other.Email == Email &&
                    other.FirstName == FirstName &&
                    other.LastName == LastName &&
                    other.Phone == Phone;
            }
        }

        //obligitory hash override for equal
        public override int GetHashCode()
        {
            var hashCode = 8675301;
            return hashCode * id.GetHashCode() +
                hashCode * email.GetHashCode() +
                hashCode * firstName.GetHashCode() +
                hashCode * lastName.GetHashCode() +
                hashCode * phone.GetHashCode();
        }

        // complimentary == comparitor
        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        //it's buddy the not equal comparitor
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }
    }
}
