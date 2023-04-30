using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class Page : Entity
    {
        public string Text { get; set; }
        public int FlashCardId { get; init; }
    }
}
