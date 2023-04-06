namespace Domain
{
    public class User
    {
        public User(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.id = userCount;
            this.userName = $"User#{userCount++}";
            this.photo = "None";
        }
        public string Name{get => userName; set => userName = value;}
        public string Photo{get => photo; set => photo = value;}
        public string Email{get => email; set => email = value;}
        public string Password{get => password;}
        public string Login{get => login;}
        public long Id{get => id;}
        private string login;
        private string password;
        private string email;
        private string userName;
        private string photo;
        private long id;
        private static long userCount = 0;
    }
}