﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Entities
{
    public class SinglePageFlashCard : FlashCard
    {
        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}
