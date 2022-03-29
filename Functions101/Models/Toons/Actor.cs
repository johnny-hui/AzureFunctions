using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
