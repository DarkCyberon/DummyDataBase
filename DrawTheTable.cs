using System;
using System.Collections.Generic;
using System.Text;

namespace Database {
  class DrawTheTable {
    static int MaxReaderNameLength = 0;
    static int DateLength = 10; // 01.01.0001 = 10
    
    public static void CollectTheTable (List<BookStatus> booksStatusesData, List<Book> booksData) {
      var table = new StringBuilder();
      CountMaxReaderName(booksStatusesData);
      booksStatusesData = DeleteReapetingNotes(booksStatusesData);
      table.Append(DrawTheHead());

      int indexOfTakenBooks = 0;
      for (int i = 0; i < booksData.Count; i++){
        if (booksData[i].IsAccesable)
          table.Append(DrawTheLineForAccesBook(booksData[i]));
        else
          table.Append(DrawTheLineForTakenBook(booksStatusesData[indexOfTakenBooks++]));
      }
      Console.WriteLine(table);
    }
    
    private static List<BookStatus> DeleteReapetingNotes (List<BookStatus> notes){
      var result = new List<BookStatus>();
      foreach (var note in notes) {
        if (note.BookReturnDate == "") {
          result.Add(note);
        }
      }
      return result;
    }

    private static void CountMaxReaderName (List<BookStatus> notes){
      foreach (var note in notes){
        int NameLength = note.Reader.Name.Length;
        if (NameLength > MaxReaderNameLength)
          MaxReaderNameLength = NameLength;
      }
    }
    
    private static StringBuilder DrawTheHead(){
      var headOfTable = new StringBuilder();
      var separators = new List<string>();
      var headElements = new List<string>();

      headElements.Add("Автор".PadRight(Book.AuthorsMaxLength));
      headElements.Add("Название".PadRight(Book.BooksNamesMaxLength));
      headElements.Add("Читает".PadRight(MaxReaderNameLength));
      headElements.Add("Взял".PadRight(DateLength));

      foreach (var element in headElements) 
        separators.Add(new string('-', element.Length));
      headOfTable.Append(CollectTheLine(headElements));
      headOfTable.Append(CollectTheLine(separators));

      return headOfTable;
    }

    private static StringBuilder DrawTheLineForAccesBook(Book book){
      var bookData = new List<string>();
      bookData.Add(book.Author.PadRight(Book.AuthorsMaxLength));
      bookData.Add(book.Name.PadRight(Book.BooksNamesMaxLength));
      bookData.Add(new string(' ', MaxReaderNameLength));
      bookData.Add(new string(' ', DateLength));

      return CollectTheLine(bookData);
    }

    private static StringBuilder DrawTheLineForTakenBook(BookStatus bookStatus){
      var bookData = new List<string>();
      bookData.Add(bookStatus.Book.Author.PadRight(Book.AuthorsMaxLength));
      bookData.Add(bookStatus.Book.Name.PadRight(Book.BooksNamesMaxLength));
      bookData.Add(bookStatus.Reader.Name.PadRight(MaxReaderNameLength));
      bookData.Add(bookStatus.BookTakenDate.PadRight(DateLength));

      return CollectTheLine(bookData);
    }
    
    private static StringBuilder CollectTheLine(List<string> elements){
      var line = new StringBuilder();

      foreach (string element in elements)
        line.Append($"|{element}");
      line.Append("|\n");
      return line;
    }
  }
}