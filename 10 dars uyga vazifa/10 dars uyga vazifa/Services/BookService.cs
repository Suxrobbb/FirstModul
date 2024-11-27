using _10_dars_uyga_vazifa.Models;
namespace _10_dars_uyga_vazifa.Services;

public class BookService
{
    private List<Book> books;

    public BookService()
    {
        books = new List<Book>();
        DataSeed();
    }

    public Book AddBook(Book newBook)
    {
        newBook.Id=Guid.NewGuid();
        books.Add(newBook);
        return newBook;
    }

    public Book GetById(Guid id)
    {
        foreach (var bookDb in books)
        {
            if (bookDb.Id == id)
            {
                return bookDb;
            }
        }
        return null;
    }

    public bool DeleteBook(Guid id)
    {
        var bookFromDb = GetById(id);
        if (bookFromDb is null)
        {
            return false;
        }

        books.Remove(bookFromDb);
        return true;
    }

    public bool UpdateBook(Book newBook)
    {
        var bookFromDb = GetById(newBook.Id);
        if (bookFromDb is null)
        {
            return false;
        }

        var index = books.IndexOf(bookFromDb);
        books[index]= newBook;
        return true;
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public Book GetExpensiveBook()
    {
        if(books==null || books.Count==0)
        {
            return null;
        }
        Book expensiveBook=books[0];
        foreach(var book in books)
        {
            if (book.Price>expensiveBook.Price)
            {
                expensiveBook = book;
            }
        }
        return expensiveBook;
    }

    public Book GetMostPagedBook()
    {
        if(books==null || books.Count==0)
        {
            return null;
        }
        Book mostPagedBook = books[0];
        foreach(var book in books)
        {
            if (book.PageNumber>mostPagedBook.PageNumber)
            {
                mostPagedBook = book;
            }
        }
        return mostPagedBook;
    }

    public Book GetMostReadBook()
    {
        if(books ==null || books.Count==0)
        {
            return null;
        }
        Book mostReadBook = books[0];
        int maxReaders = mostReadBook.ReadersName.Count;
        foreach(var book in books)
        {
            if (book.ReadersName.Count>maxReaders)
            {
                mostReadBook= book;
                maxReaders=book.ReadersName.Count;
            }
        }
        return mostReadBook;
    }







    }
