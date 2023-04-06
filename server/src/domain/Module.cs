namespace Domain
{
    public class Module
    {
        public Module(string name, string description, string img, string author)
        {
            this.name = name;
            this.description = description;
            this.img = img;
            this.author = author;
            id = moduleCount++;
        }
        public string Name{get => name; set => name = value;}
        public string Description{get => description; set => description = value;}
        public string Img{get => img; set => description = value;}
        public string Author{get => author; set => author = value;}
        public long Id{get => id;}
        private string name;
        private string description;
        private string img;
        private string author;
        private long id;
        private static long moduleCount = 0;
    }
}