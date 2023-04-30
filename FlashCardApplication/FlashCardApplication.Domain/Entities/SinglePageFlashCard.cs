using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class SinglePageFlashCard : FlashCard
    {
        public Page FrontSide { get; set; }
    }
}
