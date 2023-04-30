using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; init; }
        public string Password { get; set; }

    }
}
