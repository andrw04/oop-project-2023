using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class DoublePageFlashCard : FlashCard
    {
        public Page FrontSide { get; set; }
        public Page BackSide { get; set; }
    }
}
