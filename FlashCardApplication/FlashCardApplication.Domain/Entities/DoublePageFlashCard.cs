using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class DoublePageFlashCard : FlashCard
    {
        public int FrontPageId { get; set; }
        public int BackPageId { get; set; }
        public Page FrontPage { get; set; }
        public Page BackPage { get; set; }
        public bool Flipped { get; set; }
    }
}
