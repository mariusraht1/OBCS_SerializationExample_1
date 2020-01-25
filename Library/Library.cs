using System.IO;
using System.Xml.Serialization;

namespace Library
{
    public class Library
    {
        public enum BookGenre
        {
            Roman,
            Sachbuch
        }

        public class Book
        {
            [XmlAttribute]
            public string Title { get; set; }
            [XmlAttribute]
            public string Author { get; set; }
            public BookGenre Genre { get; set; }
            public int Year { get; set; }
            public string ISBN { get; set; }
            public decimal Price { get; set; }

            public Book() { }

            public Book(string title, string author, BookGenre genre, int year, string isbn, decimal price)
            {
                Title = title;
                Author = author;
                Genre = genre;
                Year = year;
                ISBN = isbn;
                Price = price;
            }
        }

        public class Inventory
        {
            public Book[] Books { get; set; }

            private decimal totalValue;
            public decimal TotalValue
            {
                get
                {
                    totalValue = 0;

                    for (int i = 0; i < Books.Length; i++)
                    {
                        totalValue += Books[i].Price;
                    }

                    return totalValue;
                }
                set
                {
                    totalValue = value;
                }
            }

            public Inventory() { }

            public Inventory(Book[] books)
            {
                Books = books;
            }

            public override string ToString()
            {
                string output = "";

                for (int i = 0; i < Books.Length; i++)
                {
                    output += $"{Books[i].Title}\n";
                }
                output += $"Gesamtwert: {TotalValue}";

                return output;

            }
        }

        public class Serializer
        {
            public void ExportToXml(string fileName, Inventory inventory)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Inventory));

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, inventory);
                }
            }

            public Inventory ImportFromXml(string fileName)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Inventory));

                using (StreamReader reader = new StreamReader(fileName))
                {
                    Inventory inventory = (Inventory)serializer.Deserialize(reader);
                    return inventory;
                }
            }
        }
    }
}
