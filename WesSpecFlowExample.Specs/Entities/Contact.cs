using System;
using System.Collections.Generic;
using System.Text;

namespace WesSpecFlowExample.Entities
{
    public struct Contact
    {
        public string ContactType { get; set; }
        public string Segment {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string MobileNumber { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
