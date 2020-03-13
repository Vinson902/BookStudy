using System.Linq;
using BookStudy.Models;

namespace BookStudy.DBConnect
{
    public class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
                context.GuestResponses.AddRange(
                    new GuestResponse
                    {
                        name = "Timofey",
                        email = "timofey@gmail.com",
                        phone = "89763456734"
                    },
                new GuestResponse
                    {
                        name = "Danila",
                        email = "danila@gmail.com",
                        phone = "79021906946"
                    },
                new GuestResponse
                    {
                        name = "Anybody",
                        email = "timofey@gmail.com",
                        phone = "0123456789"
                    }
                    );
                context.SaveChanges();
        }
    }
}