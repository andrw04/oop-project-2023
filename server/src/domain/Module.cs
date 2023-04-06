namespace Domain
{
    public class Module : Entity
    {
        public Module(string name, string description, string img, string author)
        {
            this.name = name;
            this.description = description;
            this.img = img;
            this.author = author;
        }
        public string Name{get => name; set => name = value;}
        public string Description{get => description; set => description = value;}
        public string Img{get => img; set => description = value;}
        public string Author{get => author; set => author = value;}
        private string name;
        private string description;
        private string img;
        private string author;
    }
}