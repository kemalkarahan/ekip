using ekip.Core.Entities.Concrete;
using System;

namespace ekip.Entities.Concrete
{
    public class Guest : User
    {
        public DateTime PermanentlyDelete { get; set; }
        public EnumCollection.Roles Role { get; set; }
    }
}
