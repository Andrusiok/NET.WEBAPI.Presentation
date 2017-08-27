using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Customer: IEquatable<Customer>, IComparable<Customer>, ICloneable
    {
        private struct ComparisionAdapter : IComparer<Customer>
        {
            private Comparison<Customer> compare;

            public ComparisionAdapter(Comparison<Customer> compare)
            {
                this.compare = compare;
            }

            public int Compare(Customer x, Customer y)
            {
                return compare(x, y);
            }
        }

        private struct EqualityComparisionAdapter : IEqualityComparer<Customer>
        {
            private Func<Customer, Customer, bool> compare;

            public EqualityComparisionAdapter(Func<Customer, Customer, bool> compare)
            {
                this.compare = compare;
            }

            public bool Equals(Customer x, Customer y)
            {
                return compare(x, y);
            }

            public int GetHashCode(Customer obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        private int id;

        public int Id => id;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";

        public Customer(int id, string name, string lastName)
        {
            this.id = id;
            Name = name;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return this.Equals((Customer)obj);
            }
            else
                return false;
        }

        public bool Equals(Customer other)
        {
            if (this == other) return true;
            if (other == null) return false;

            return this.Id == other.Id;
        }

        public bool Equals(Customer other, IEqualityComparer<Customer> comparer)
        {
            if (this == other) return true;
            if (other == null) return false;

            return comparer.Equals(this, other);
        }

        public bool Equals(Customer other, Func<Customer, Customer, bool> compare)
        {
            var comparer = new EqualityComparisionAdapter(compare);

            return Equals(other, comparer);
        }

        public int CompareTo(Customer other)
        {
            if (this == other) return 0;
            if (other == null) return -1;

            return Id.CompareTo(other.Id);
        }

        public int CompareTo(Customer other, IComparer<Customer> comparer)
        {
            if (this == other) return 0;
            if (other == null) return -1;

            return comparer.Compare(this, other);
        }

        public int CompareTo(Customer other, Comparison<Customer> compare)
        {
            var comparer = new ComparisionAdapter(compare);
            return CompareTo(other, compare);
        }

        public static bool operator > (Customer left, Customer right)
        {
            if (left == null) return false;

            return left.CompareTo(right) > 0;
        }

        public static bool operator <(Customer left, Customer right)
        {
            if (left == null) return false;

            return left.CompareTo(right) < 0;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            return $"{Id}: {FullName}";
        }

        public Customer Clone()
        {
            return new Customer(this.Id, this.Name, this.LastName);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    public struct CustomerStruct: IEquatable<CustomerStruct>, IComparable<CustomerStruct>
    {
        private struct ComparisionAdapter : IComparer<CustomerStruct>
        {
            private Comparison<CustomerStruct> compare;

            public ComparisionAdapter(Comparison<CustomerStruct> compare)
            {
                this.compare = compare;
            }

            public int Compare(CustomerStruct x, CustomerStruct y)
            {
                return compare(x, y);
            }
        }

        private struct EqualityComparisionAdapter : IEqualityComparer<CustomerStruct>
        {
            private Func<CustomerStruct, CustomerStruct, bool> compare;

            public EqualityComparisionAdapter(Func<CustomerStruct, CustomerStruct, bool> compare)
            {
                this.compare = compare;
            }

            public bool Equals(CustomerStruct x, CustomerStruct y)
            {
                return compare(x, y);
            }

            public int GetHashCode(CustomerStruct obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        private int id;

        public int Id => id;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";

        public CustomerStruct(int id, string name, string lastName)
        {
            this.id = id;
            Name = name;
            LastName = lastName;
        }

        public bool Equals(CustomerStruct other)
        {
            return this.Id == other.Id;
        }

        public bool Equals(CustomerStruct other, IEqualityComparer<CustomerStruct> comparer)
        {
            return comparer.Equals(this, other);
        }

        public bool Equals(CustomerStruct other, Func<CustomerStruct, CustomerStruct, bool> compare)
        {
            var comparer = new EqualityComparisionAdapter(compare);

            return Equals(other, comparer);
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomerStruct)
            {
                return this.Equals((CustomerStruct)obj);
            }
            else
                return false;
        }

        public int CompareTo(CustomerStruct other)
        {
            return Id.CompareTo(other.Id);
        }

        public int CompareTo(CustomerStruct other, IComparer<CustomerStruct> comparer)
        {
            return comparer.Compare(this, other);
        }

        public int CompareTo(CustomerStruct other, Comparison<CustomerStruct> compare)
        {
            var comparer = new ComparisionAdapter(compare);
            return CompareTo(other, compare);
        }

        public static bool operator >(CustomerStruct left, CustomerStruct right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(CustomerStruct left, CustomerStruct right)
        {
            return left.CompareTo(right) < 0;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            return $"{Id}: {FullName}";
        }
    }
}
