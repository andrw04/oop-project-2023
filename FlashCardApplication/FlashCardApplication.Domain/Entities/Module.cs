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
        public int UserId { get; init; }
    }
}
