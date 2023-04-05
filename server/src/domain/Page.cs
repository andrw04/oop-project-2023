namespace Domain
{
    public class Page
    {
        public string Text{get => text; set => text = value;}
        public string Img{get => img; set => img = value;}
        private string text = "";
        private string img = "";
    }
}