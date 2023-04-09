namespace Domain
{
    public class Page
    {
        public Page(string text = "", string img = "")
        {
            this.text = text;
            this.img = img;
        }

        public string Text{get => text; set => text = value;}
        public string Img{get => img; set => img = value;}
        private string text;
        private string img;
    }
}