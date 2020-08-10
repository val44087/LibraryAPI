using LibraryApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAPIIntergrationTests
{    
public static class DataUtils
    {
        public static void Initialize(LibraryDataContext db)
        {
            db.Books.AddRange(
            GetSeedingBooks());

            db.SaveChanges();
        }
        public static void ReinitializeDb(LibraryDataContext db)
        {
            db.Books.RemoveRange(db.Books); // delete all the books.
            Initialize(db);
        }

        public static List<Book> GetSeedingBooks()
        {
            return new List<Book>
            {   
            new Book { Id = 1, Title ="Jaws", Author="Benchley", Genre="Fiction", InStock=true, NumberOfPages = 200},
            new Book { Id = 2, Title ="Title 2", Author="Smith", Genre="Fantasy", InStock=true, NumberOfPages = 389},
            new Book { Id =3, Title = "It", Author = "King", Genre="Horror", InStock=false, NumberOfPages=979}
            };

        }
    }
}


   