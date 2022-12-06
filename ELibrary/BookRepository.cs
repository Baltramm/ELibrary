using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class BookRepository
    {

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var bd = new AppContext())
            {
                books = bd.Books.ToList();
            }
            return books;
        }

        public Book GetBookById(int Id)
        {
            var book = new Book();

            using (var bd = new AppContext())
            {
                book = bd.Books.FirstOrDefault(x => x.Id == Id);
            }

            return book;
        }

        public void AddBook()
        {
            using (var bd = new AppContext())
            {
                var book = new Book();

                Console.WriteLine("Введите название новой книги:");

                book.Name = NotNullCheck.Check();

                Console.WriteLine("Введите год выпуска книги");

                book.Release_Year = Int32.Parse(NotNullCheck.Check());

                bd.Add(book);
                bd.SaveChanges();
            }

        }

        public void DeleteBookByTitle()
        {
            Console.WriteLine("Введите название книги");

            var Name = NotNullCheck.Check();

            using (var bd = new AppContext())
            {
                try
                {
                    var book = bd.Books.FirstOrDefault(x => x.Name == Name);
                    bd.Books.Remove(book);
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Такой книги не существует!");
                }
            }
        }

        public void UpdateBookTitleById()
        {
            var book = new Book();
            Console.WriteLine("Введите идентификатор книги");


            using (var bd = new AppContext())
            {
                try
                {
                    int Id = Int32.Parse(NotNullCheck.Check());
                    book = bd.Books.FirstOrDefault(x => x.Id == Id);
                    Console.WriteLine("Введите новое имя пользователя: ");
                    string NewName = NotNullCheck.Check();
                    book.Name = NewName;
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Такой книги не существует!");
                }
            }
        }

        public void GetBookByGenreAndDate()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите жанр книги");
                string genre = NotNullCheck.Check();

                int date1 = 0;
                int date2 = 0;

                try
                {
                    Console.WriteLine("Введите временные рамки даты выхода книги: \n Дата 1: ");
                    date1 = Int32.Parse(NotNullCheck.Check());

                    Console.WriteLine("Дата 2");
                    date2 = Int32.Parse(NotNullCheck.Check());
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные");
                }

                var books = db.Books.Where(a => a.Genre.Name == genre).Where(a => a.Release_Year >= date1 & a.Release_Year <= date2).ToList();

                foreach (var book in books)
                    Console.WriteLine(book.Name);
            }

        }

        public void GetCountOfBooksByAuthor()
        {
            Console.WriteLine("Введите автора книги");
            string name = NotNullCheck.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Where(a => a.Author.Name == name).Count();
                Console.WriteLine(books);
            }
        }

        public void GetCountOfBooksByGenre()
        {
            Console.WriteLine("Введите автора книги");
            string genre = NotNullCheck.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Where(a => a.Genre.Name == genre).Count();
                Console.WriteLine(books);
            }
        }


        public bool IsThereBookByAuthorAndName()
        {
            Console.WriteLine("Введите автора книги");
            string name = NotNullCheck.Check();

            Console.WriteLine("Введите название книги");
            string title = NotNullCheck.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Any(a => a.Name == title & a.Author.Name == name);
                return books;
            }
        }

        public void GetTheMostNewBook()
        {
            using (var db = new AppContext())
            {
                var date = db.Books.Max(a => a.Release_Year);
                var book = db.Books.FirstOrDefault(a => a.Release_Year == date);
                Console.WriteLine(book.Name);
            }
        }

        public void GetAllBooksOrederedByName()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.ToList().OrderBy(a => a.Name);
                foreach (var book in books)
                {
                    Console.WriteLine(book.Name);
                }
            }
        }

        public void GetAllBooksOrederedByDescendingByDate()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.ToList().OrderByDescending(a => a.Release_Year);
                foreach (var book in books)
                {
                    Console.WriteLine(book.Name);
                }
            }
        }

    }
}
