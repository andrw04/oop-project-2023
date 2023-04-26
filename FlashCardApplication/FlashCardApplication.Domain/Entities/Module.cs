using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        // Foreighn key (author Id)
        public long UserId { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
