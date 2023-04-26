using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class Page : Entity
    {
        public int FlashCardId { get; set; }
        public FlashCard FlashCard { get; set; }
    }
}
