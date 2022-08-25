using System;
using System.Collections.Generic;

namespace KatuhairiotLive.Models
{
    public partial class Username
    {
        public int UserId { get; set; }
        public string Username1 { get; set; } = null!;
        public int? Routeid { get; set; }
        public string? FavRoute { get; set; }

        public virtual URoute? Route { get; set; }
    }
}
