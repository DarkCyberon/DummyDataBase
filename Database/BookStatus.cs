using System;

namespace Database {
  class BookStatus{
    public readonly Book Book;
    public readonly Reader Reader;
    public readonly string BookTakenDate;
    public string BookReturnDate { get; private set; }

    public BookStatus (Book book, Reader reader, string bookTakenDate) {
      Book = book;
      Reader = reader;
      BookTakenDate = bookTakenDate;
    }

    public static void ReturnBook (BookStatus bookStatus, string returnDate) {
      string takenDate = bookStatus.BookTakenDate;
      if (CheckTheDates(takenDate, returnDate))
        bookStatus.BookReturnDate = returnDate;
      else {
        throw new Exception("The date of issue of the book must be earlier than the return date!");
      }  
    }

    private static bool CheckTheDates (string takenDate, string returnDate) {
      string[] partsTD = takenDate.Split(','); //0 - день, 1 - месяц, 2 - год
      string[] partsRD = returnDate.Split(',');
      
      int returnDay = Int32.Parse(partsRD[0]);
      int returnMonth = Int32.Parse(partsRD[1]);
      int returnYear = Int32.Parse(partsRD[2]);

      int takenDay = Int32.Parse(partsTD[0]);
      int takenMonth = Int32.Parse(partsTD[1]);
      int takenYear = Int32.Parse(partsTD[2]);


      if (returnYear < takenYear) 
        return false;
      else if (returnYear > takenYear)
        return true;
      if (returnMonth < takenMonth)
        return false;
      else if (returnMonth > takenMonth)
        return true;
      if (returnDay < takenDay) 
        return false;
      else if (returnDay >= takenDay)
        return true;
      return false;
    }
  }
}