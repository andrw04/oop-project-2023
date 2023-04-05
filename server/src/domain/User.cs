namespace Domain
{
    public class User
    {
        public User(string login, string password, string email, long id)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.userName = $"User#{id}";
            this.photo = "None";
        }
        public string Name{get => userName; set => userName = value;}
        public string Photo{get => photo; set => photo = value;}
        public string Email{get => email; set => email = value;}
        public string Password{get => password; set => password = value;}
        public string Login{get => password; set => login = value;}
        private string login;
        private string password;
        private string email;
        private string userName;
        private string photo;
    }
}