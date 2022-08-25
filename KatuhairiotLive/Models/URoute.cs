using System;
using System.Collections.Generic;

namespace KatuhairiotLive.Models
{
    public partial class URoute
    {
        public URoute()
        {
            Usernames = new HashSet<Username>();
        }

        public int RouteId { get; set; }
        public string UserRoute { get; set; } = null!;

        public virtual ICollection<Username> Usernames { get; set; }
    }
}
