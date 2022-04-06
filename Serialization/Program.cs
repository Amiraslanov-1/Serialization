using System;
using System.IO;
using Newtonsoft.Json;
namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string fullPath = @"C:\Users\mrtan\OneDrive\Рабочий стол\Serialization\Serialization\";
            if (!Directory.Exists(fullPath + "Files"))
            {
                Directory.CreateDirectory(fullPath + "Files");
            };

            if (!File.Exists(fullPath + "Files\\Database.json"))
            {
                File.Create(fullPath + "Files\\Database.json");


            }

            Library library = new Library()
            {
                Id = 1,
                Name = "One",

            };




            bool ischeck = true;
            do
            {
                Console.WriteLine("Menu\n1.Add book\n2.Get Book By ID\n3.Remove Book\n0.Quit\n");
                Console.WriteLine("Make Your Choice :");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("- Enter ID :");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("- Enter Book Name :");
                        string Name = Console.ReadLine();
                        Console.WriteLine("- Enter The Author Of The Book :");
                        string AuthorName = Console.ReadLine();
                        Console.WriteLine("- Price Daxil Edin :");
                        double Price = Convert.ToDouble(Console.ReadLine());
                        Book book = new Book(Id, Name, AuthorName, Price);
                        library.AddBook(book);
                        string JsonStr = JsonConvert.SerializeObject(library);
                        using (StreamWriter sw = new StreamWriter(fullPath + @"Files\Database.json"))
                        {
                            sw.Write(JsonStr);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter ID : ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        string bookJsonStr;
                        using (StreamReader sr = new StreamReader(fullPath + @"Files\Database.json"))
                        {
                            bookJsonStr = sr.ReadToEnd();
                        }
                        Library library1 = JsonConvert.DeserializeObject<Library>(bookJsonStr);
                        try
                        {
                            Console.WriteLine(library1.GetBookById(bookId));

                        }
                        catch (BookIsNotFound ex)
                        {

                            Console.WriteLine(ex.Message);
                        }


                        break;
                    case "3":
                        Console.WriteLine("Enter  İd The Book You Want To Delete :");
                        int removeBookById = Convert.ToInt32(Console.ReadLine());
                        string newBookJsonStr = String.Empty;
                        string json;
                        string oldBookJsonStr;
                        using (StreamReader sw = new StreamReader(fullPath + @"Files\Database.json"))
                        {
                            json = sw.ReadToEnd();

                            Library library2 = JsonConvert.DeserializeObject<Library>(json);

                            try
                            {
                                library2.RemoveBook(removeBookById);

                            }
                            catch (ResultIsNullException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            oldBookJsonStr = JsonConvert.SerializeObject(library2);
                            newBookJsonStr = oldBookJsonStr;
                        }
                        using (StreamWriter sw = new StreamWriter(fullPath + @"Files\Database.json"))
                        {
                            sw.WriteLine(newBookJsonStr);
                        }
                        break;
                  
                    case "0":
                        ischeck = false;
                        break;

                    default:
                        break;
                }



            } while (ischeck);
        }
    }
}
