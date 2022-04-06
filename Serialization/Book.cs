using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }

        public Book(int id,string name,string authorName,double price)
        {
            Id = id;
            Name = name;
            AuthorName = authorName;
            Price = price;

        }
        public string ShowInfo()
        {
            return $"ID : {Id}\nName : {Name}\nAuthor Name : {AuthorName}\nPrice : {Price}";
        }
        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
