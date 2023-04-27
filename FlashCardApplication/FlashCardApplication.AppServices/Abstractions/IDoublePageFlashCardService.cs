﻿using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.AppServices.Abstractions
{
    public interface IDoublePageFlashCardService : IBaseService<DoublePageFlashCard>
    {
        void Flip(DoublePageFlashCard flashCard);
    }
}
