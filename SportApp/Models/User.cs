using System;
using System.Collections.Generic;

namespace SportApp.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
