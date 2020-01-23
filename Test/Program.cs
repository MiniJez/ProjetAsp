using ProjectAsp.Db;
using ProjectAsp.Models;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db=new RestaurantContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Restaurants.Add(
                    new Restaurant {
                        nom = "La petite idée",
                        tel = "0688059395",
                        email = "email@email.fr",
                        adresse = new Adresse
                        {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                        },
                        note = new Note
                        {
                            note = 17,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                        }
                    }
                    );
                db.Restaurants.Add(
                     new Restaurant
                     {
                         nom = "L'amélyss",
                         tel = "0688059395",
                         email = "email@email.fr",
                         adresse = new Adresse
                         {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                         },
                         note = new Note
                         {
                            note = 14,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                         }
                     }
                     );
                db.Restaurants.Add(
                     new Restaurant
                     {
                         nom = "La girole",
                         tel = "0688059395",
                         email = "email@email.fr",
                         adresse = new Adresse
                         {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                         },
                         note = new Note
                         {
                            note = 12,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                         }
                     }
                     );
                db.Restaurants.Add(
                     new Restaurant
                     {
                         nom = "L'amélyss",
                         tel = "0688059395",
                         email = "email@email.fr",
                         adresse = new Adresse
                         {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                         },
                         note = new Note
                         {
                            note = 15,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                         }
                     }
                     );
                db.Restaurants.Add(
                     new Restaurant
                     {
                         nom = "Une semaine sur deux",
                         tel = "0688059395",
                         email = "email@email.fr",
                         adresse = new Adresse
                         {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                         },
                         note = new Note
                         {
                            note = 16.5,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                         }
                     }
                     );
                db.Restaurants.Add(
                     new Restaurant
                     {
                         nom = "Le côte",
                         tel = "0688059395",
                         email = "email@email.fr",
                         adresse = new Adresse
                         {
                            rue = "25 rue emile zola",
                            ville = "Grenoble",
                            cp = "38100",
                         },
                         note = new Note
                         {
                            note = 14.5,
                            dateDerniereVisite = new DateTime(2020, 01, 18, 19, 30, 00),
                            commentaire = "C'était pas mal, mais ca vaut pas un 2 * ;)"
                         }
                     }
                     );
                db.SaveChanges();
            }
        }
    }
}
