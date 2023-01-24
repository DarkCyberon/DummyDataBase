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

    public void ReturnBook (BookStatus bookStatus, string returnDate) {
      string takenDate = bookStatus.BookTakenDate;
      if (CheckTheDates(takenDate, returnDate))
        bookStatus.BookReturnDate = returnDate;
      else {
        throw new Exception("The date of issue of the book must be earlier than the return date!");
      }  
    }

    private bool CheckTheDates (string takenDate, string returnDate) {

     int[] takenDateArray = DateToArray(takenDate);
      int[] returnDateArray = DateToArray(returnDate);

      for (int i = 0; i < returnDateArray.Length; i++) {
        if (returnDateArray[i] < takenDateArray[i]) 
          return false;
        else if (returnDateArray[i] > takenDateArray[i])
          return true;
      }
      return true;
    }

    private int[] DateToArray(string date) {
      
      const int dateDayIndex = 0;
      const int dateMonthIndex = 1;
      const int dateYearIndex = 2;
      const char dateSeparator = '.';

      string[] elements = date.Split(dateSeparator);
      int day = Int32.Parse(partsRD[dateDayIndex]);
      int month = Int32.Parse(partsRD[dateMonthIndex]);
      int year = Int32.Parse(partsRD[dateYearIndex]);
      
      return new int[] { year, month, day };
    }
  }
}