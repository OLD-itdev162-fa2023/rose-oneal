using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistenc {

    public class Seed {

        public static void SeedData(DataContext context){

            if (!context.Posts.Any()){
                var Posts = new List<Post>{

                    new Post {
                        Title = "First Post",
                        Body = "Vivamus aliquam rutrum ante ut elementum. Duis sit amet luctus massa. Etiam sem augue, placerat non vestibulum ac, suscipit sed.",
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new Post {
                        Title = "Second Post",
                        Body = "Maecenas id enim leo. In aliquet justo vel risus facilisis, eu aliquet sapien semper. Aenean viverra porttitor augue sed congue.",
                        Date = DateTime.Now.AddDays(-7)
                    },
                    new Post {
                        Title = "Third Post",
                        Body = "Vivamus ullamcorper odio sed ante tempus viverra. Phasellus at nisi ligula. Nam dui tellus, rhoncus a malesuada at, aliquam vel.",
                        Date = DateTime.Now.AddDays(-4)
                    }
                };

                context.Posts.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}