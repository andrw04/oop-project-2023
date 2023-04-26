using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class DoublePageFlashCard : FlashCard
    {
        public Page Page1 { get; set; }
        public Page Page2 { get; set; }
        public bool Flipped { get; set; }
    }
}
