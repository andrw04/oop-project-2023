namespace Domain
{
    public class User : Entity
    {
        public User(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.userName = $"User#{base.Id}";
            this.photo = "None";
        }
        public string Name{get => userName; set => userName = value;}
        public string Photo{get => photo; set => photo = value;}
        public string Email{get => email; set => email = value;}
        public string Password{get => password;}
        public string Login{get => login;}
        private string login;
        private string password;
        private string email;
        private string userName;
        private string photo;
    }
}