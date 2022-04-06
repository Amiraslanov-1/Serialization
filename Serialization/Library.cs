using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    class Library

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public Book GetBookById(int id)
        {
            Book result = Books.Find(book => book.Id == id);
            if (result == null)
                throw new BookIsNotFound("The Book İs Not Available!\n");
            return result;
        }

        public void RemoveBook(int? id)
        {

            if (id == null)
            {
                throw new ArgumentNullException("Argument is Null !");
            }
            var result = Books.Find(book => book.Id == id);
            if (result != null)
            {
                Books.Remove(result);
                Console.WriteLine("Book Succesfuly Deleted !");
            }
            else
            {
                throw new ResultIsNullException("Result is Null !");

            }
        }
        public List<Book> SearchBook(string search)
        {
            List<Book> books = new List<Book>();
            foreach (var book in Books)
            {
                if (book.Name.Contains(search))
                {
                    books.Add(book);
                }
                if (book.AuthorName.Contains(search))
                {
                    books.Add(book);
                }
                if (book.Price.ToString().Contains(search))
                {
                    books.Add(book);
                }
                else
                    throw new ResultIsNullException("Book is Not Found");

            }
            return books;
        }

    }
}
