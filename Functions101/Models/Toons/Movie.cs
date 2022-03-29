using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }

        public int MovieId { get; set; }
        public string Name { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
