using Domain;
using Services;
using Events;
using Repository;

class Program
{
    static void Main()
    {
        var em = new EventManager();
        em.Subscribe(new ActivityListener());
        var us = new UserService(em);
        us.Register(new User("login","password","email"));
        var user = us.Login("login", "password");
        var ms = new ModuleService(em);
        if (user != null)
        {
            user.Name = "User1";
            user.Email = "user@mail.ru";
            var module = new Module("module", "description", "img", user.Name);
            ms.CreateModule(module);
            var p1 = new Page("page1", "image1.jpg");
            var p2 = new Page("page2", "image2.jpg");
            ms.AddFlashCard(new DoublePageFlashCard(p1,p2), module);
            var fs = ms.GetAllFlashCards();
            foreach (var f in fs)
            {
                Console.WriteLine(f.Show().Text);
            }
            
        }
    }
}