using System;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; } = new List<Book>();
    public List<MediaItem> MediaItems { get; } = new List<MediaItem>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine($"Library: {Name} - Address: {Address}");
        Console.WriteLine("Books:");
        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}, Published: {book.PublicationYear})");
        }

        Console.WriteLine("Media Items:");
        foreach (var mediaItem in MediaItems)
        {
            Console.WriteLine($"{mediaItem.Title} - Type: {mediaItem.MediaType}, Duration: {mediaItem.Duration} minutes");
        }
    }

    public List<Book> SearchBooks(string keyword)
    {
        return Books.Where(book => book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                   book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                   book.ISBN.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
    }

    public List<MediaItem> SearchMediaItems(string keyword)
    {
        return MediaItems.Where(item => item.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                        item.MediaType.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                         .ToList();
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
}

public class MediaItem
{
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }
}

public class Program
{
    public static void Main()
    {
        Library myLibrary = new Library
        {
            Name = "My Library",
            Address = "123 Main Street, City"
        };

        Book book1 = new Book
        {
            Title = "Sample Book 1",
            Author = "John Doe",
            ISBN = "1234567890",
            PublicationYear = 2021
        };

        Book book2 = new Book
        {
            Title = "Sample Book 2",
            Author = "Jane Smith",
            ISBN = "0987654321",
            PublicationYear = 2022
        };

        MediaItem mediaItem1 = new MediaItem
        {
            Title = "Sample DVD",
            MediaType = "DVD",
            Duration = 120
        };

        MediaItem mediaItem2 = new MediaItem
        {
            Title = "Sample CD",
            MediaType = "CD",
            Duration = 60
        };

        myLibrary.AddBook(book1);
        myLibrary.AddBook(book2);
        myLibrary.AddMediaItem(mediaItem1);
        myLibrary.AddMediaItem(mediaItem2);

        myLibrary.PrintCatalog();

        // Search feature example
        Console.WriteLine("\nEnter a keyword to search for books or media items:");
        string keyword = Console.ReadLine();
        List<Book> foundBooks = myLibrary.SearchBooks(keyword);
        List<MediaItem> foundMediaItems = myLibrary.SearchMediaItems(keyword);

        if (foundBooks.Count > 0 || foundMediaItems.Count > 0)
        {
            Console.WriteLine("Search Results:");
            if (foundBooks.Count > 0)
            {
                Console.WriteLine("\nBooks:");
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}, Published: {book.PublicationYear})");
                }
            }
            if (foundMediaItems.Count > 0)
            {
                Console.WriteLine("\nMedia Items:");
                foreach (var mediaItem in foundMediaItems)
                {
                    Console.WriteLine($"{mediaItem.Title} - Type: {mediaItem.MediaType}, Duration: {mediaItem.Duration} minutes");
                }
            }
        }
        else
        {
            Console.WriteLine("No matching results found.");
        }
    }
}
