namespace Mct_16
{
    public class Book
    {
        public Book(string name, string autor)
        {
            Name = name;
            Author = autor;
        }

        public string Name { get; set; }
        public string Author { get; set; }
    }
}
