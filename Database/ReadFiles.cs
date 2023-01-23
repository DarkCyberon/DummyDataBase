using System;
using System.Collections.Generic;

namespace Database{
  class ReadFiles{
    public static List<Book> ReadBookData (string[] books){
      var booksData = new List<Book> ();
      for (int i = 0; i < books.Length; i++) {
        string[] elements = books[i].Split(';');

        int id = Int32.Parse(elements[0]);
        string author = elements[1];
        string name = elements[2];
        int yearOfPublication = Int32.Parse(elements[3]);
        int bookcaseId = Int32.Parse(elements[4]);
        int shelfNumber = Int32.Parse(elements[5]);
        bool isAccessable = bool.Parse(elements[6]);

        booksData.Add(new Book(id, author, name, yearOfPublication, bookcaseId, shelfNumber, isAccessable));
      }
      booksData.Sort(delegate (Book book1, Book book2)
        { return book1.Id.CompareTo(book2.Id); });
      return booksData;
    }
    
    public static List<Reader> ReadReaderData (string[] readers){
      var readersData = new List<Reader> ();
      for (int i = 0; i < readers.Length; i++){
        string[] elements = readers[i].Split(';');

        int id = Int32.Parse(elements[0]);
        string name = elements[1];

        readersData.Add(new Reader(id, name));
      }
      readersData.Sort(delegate (Reader reader1, Reader reader2)
        { return reader1.Id.CompareTo(reader2.Id); });
      return readersData;
    }

    public static List<BookStatus> ReadBookStatusData (string[] booksStatuses, List<Book> books, List<Reader> readers){
      var booksStatusesData = new List<BookStatus>();

      for(int i = 0; i < booksStatuses.Length; i++ ) {
        string[] elements = booksStatuses[i].Split(';');

        int bookId = Int32.Parse(elements[0]);
        int readerId = Int32.Parse(elements[1]);
        string takenDate = elements[2];
        string returnDate = elements[3];
        
        booksStatusesData.Add(new BookStatus(books[bookId - 1], readers[readerId-1], takenDate));
      }
      booksStatusesData.Sort(delegate (BookStatus status1, BookStatus status2)
            { return status1.Book.Id.CompareTo(status2.Book.Id); });
            return booksStatusesData; 
    }
  }
}