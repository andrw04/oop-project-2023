﻿namespace FlashCardApplication.Domain.Entities
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> FlashCards { get; set; } = new List<Guid>();
        public Guid UserId { get; set; }
    }
}
