using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class FlashCard : Entity
    {
        // Foreighn key
        public int ModuleId { get; set; }

        // Navigation property
        public Module Module { get; set; }

    }
}
