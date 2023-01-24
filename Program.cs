using System.IO;
using System.Collections.Generic;

namespace Database {
  class Program {
    public static void Main () {
      string[] books = File.ReadAllLines("../Books.csv");
      string[] readers = File.ReadAllLines("../Readers.csv");
      string[] booksStatuses = File.ReadAllLines("../BooksStatuses.csv");

      Scheme bookScheme = Scheme.ReadScheme("../BookScheme.json");
      Scheme readerScheme = Scheme.ReadScheme("../ReaderScheme.json");
      Scheme bookStatusScheme = Scheme.ReadScheme("../BookStatusScheme.json");

      DataCheck.IsLinesCorrespondToScheme(books, bookScheme);
      DataCheck.IsLinesCorrespondToScheme(readers,readerScheme);
      DataCheck.IsLinesCorrespondToScheme(booksStatuses, bookStatusScheme);

      List<Book> booksData = ReadFiles.ReadBookData(books);
      List<Reader> readersData = ReadFiles.ReadReaderData(readers);
      List<BookStatus> bookStatusesData = ReadFiles.ReadBookStatusData(booksStatuses, booksData, readersData);

      DrawTheTable.CollectTheTable(bookStatusesData, booksData);
    }
  }
}