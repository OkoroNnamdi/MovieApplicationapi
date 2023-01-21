using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public string Description { get; set; }= string.Empty;
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
        public List<Genre> Genres{ get; set; }

    }
}
