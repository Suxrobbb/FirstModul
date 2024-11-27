namespace _10_dars_uyga_vazifa.Models;

public class Book
{
    //properties => Id, Title, PublicationDate, Description, PageNumber, Price, AuthorsName, ReadersName
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime PublicationDate { get; set; }

    public int PageNumber { get; set; }

    public int Price { get; set; }

    public List<Book> AuthorsName { get; set; }

    public List<Book> ReadersName { get; set; }




}
