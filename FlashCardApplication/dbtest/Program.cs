using FlashCardApplication.Domain.Entities;
using FlashCardApplication.Persistense.Data;

namespace dbtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(AppDbContext db = new AppDbContext())
            {
                SinglePageFlashCard fs = new SinglePageFlashCard() {};
                var page = new Page() { Img = "1", Text = "adfg", FlashCard = fs };
                db.Pages.Add(page);
                db.SaveChanges();
                db.SinglePageFlashCards.Add(fs);
                db.SaveChanges();

                var pages = db.SinglePageFlashCards.ToList();
                Console.WriteLine("Pages:");
                foreach(var p in pages)
                {
                    Console.WriteLine(p);
                }
            }

        }
    }
}