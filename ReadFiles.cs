using System;
using System.Collections.Generic;

namespace Database{
  class ReadFiles{
    public List<Book> ReadBookData (string[] books){
      var booksData = new List<Book> ();
      for (int i = 0; i < books.Length; i++) {
        string[] elements = books[i].Split(';');

        const int bookIdIndex = 0;
        const int bookAuthorIndex = 1;
        const int bookNameIndex = 2;
        const int bookYearOfPublicationIndex = 3;
        const int bookBookcaseIdIndex = 4;
        const int bookShelfNumberIndex = 5;
        const int bookIsAccessable = 6;

        int id = Int32.Parse(elements[bookIdIndex]);
        string author = elements[bookAuthorIndex];
        string name = elements[bookNameIndex];
        int yearOfPublication = Int32.Parse(elements[bookYearOfPublicationIndex]);
        int bookcaseId = Int32.Parse(elements[bookBookcaseIdIndex]);
        int shelfNumber = Int32.Parse(elements[bookShelfNumberIndex]);
        bool isAccessable = bool.Parse(elements[bookIsAccessable]);

        booksData.Add(new Book(id, author, name, yearOfPublication, bookcaseId, shelfNumber, isAccessable));
      }
      booksData.Sort(delegate (Book book1, Book book2)
        { return book1.Id.CompareTo(book2.Id); });
      return booksData;
    }
    
    public List<Reader> ReadReaderData (string[] readers){
      var readersData = new List<Reader> ();
      for (int i = 0; i < readers.Length; i++){
        string[] elements = readers[i].Split(';');

        const int readerIdIndex = 0;
        const int readerNameIndex = 1;

        int id = Int32.Parse(elements[readerIdIndex]);
        string name = elements[readerNameIndex];

        readersData.Add(new Reader(id, name));
      }
      readersData.Sort(delegate (Reader reader1, Reader reader2)
        { return reader1.Id.CompareTo(reader2.Id); });
      return readersData;
    }

    public List<BookStatus> ReadBookStatusData (string[] booksStatuses, List<Book> books, List<Reader> readers){
      var booksStatusesData = new List<BookStatus>();

      for(int i = 0; i < booksStatuses.Length; i++ ) {
        string[] elements = booksStatuses[i].Split(';');

        const int statusBookIdIndex = 0;
        const int statusReaderIdIndex = 1;
        const int statusTakenDateIndex = 2;
        const int statusReturnDateIndex = 3;

        int bookId = Int32.Parse(elements[statusBookIdIndex]);
        int readerId = Int32.Parse(elements[statusReaderIdIndex]);
        string takenDate = elements[statusTakenDateIndex];
        string returnDate = elements[statusReturnDateIndex];
        
        booksStatusesData.Add(new BookStatus(books[bookId - 1], readers[readerId-1], takenDate));
      }
      booksStatusesData.Sort(delegate (BookStatus status1, BookStatus status2)
            { return status1.Book.Id.CompareTo(status2.Book.Id); });
            return booksStatusesData; 
    }
  }
}