using System;
using System.Collections.Generic;
using System.Text;

namespace RIB.XamarinExamples.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string LicenseId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Customer c)
            {
                return Name.Equals(c.Name) &&
                       Id.Equals(c.Id) &&
                       LicenseId.Equals(c.LicenseId) &&
                       DateCreated.Equals(c.DateCreated);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ DateCreated.GetHashCode();
                hashCode = (hashCode * 397) ^ (LicenseId != null ? LicenseId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
