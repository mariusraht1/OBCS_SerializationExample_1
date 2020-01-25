using System;
using static Library.Library;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Book[] books = new Book[3];
            //Book book1 = new Book("The Never-ending Story", "Michael Ende", BookGenre.Roman, 1979, "9783844912620", 9.99m);
            //Book book2 = new Book("Pilgrim's Progress", "John Bunyan", BookGenre.Roman, 2007, "9283854912619", 12.99m);
            //Book book3 = new Book("Robinson Crusoe", "Daniel Defoe", BookGenre.Roman, 2014, "9583841912603", 0.99m);
            //books[0] = book1;
            //books[1] = book2;
            //books[2] = book3;

            //Inventory inventory = new Inventory(books);

            Serializer serializer = new Serializer();
            Inventory inventory = serializer.ImportFromXml("books.xml");
            serializer.ExportToXml("books.xml", inventory);

            Console.WriteLine(inventory.ToString());

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
