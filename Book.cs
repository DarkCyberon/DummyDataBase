namespace Database {
  class Book {
    public static int BooksNamesMaxLength = 0; //Длинна самого длинного названия
    public static int AuthorsMaxLength = 0; //Длина самого длинного "имени" автора


    public readonly int Id;
    public readonly string Author;
    public readonly string Name;
    public readonly int YearOfPublication;

    public int BookcaseId { get; set;}
    public int ShelfNumber { get; set;}
    public bool IsAccesable { get; set;}

    public Book (int id, string author, string name, int yearOfPublication, int bookcaseId, int shelfNumber, bool isAccesable)     {
        Id = id;
        Author = author;
        Name = name;
        YearOfPublication = yearOfPublication;
        BookcaseId = bookcaseId;
        ShelfNumber = shelfNumber;
        IsAccesable = isAccesable;

        if (name.Length > BooksNamesMaxLength) 
          BooksNamesMaxLength = name.Length;
        
        if (author.Length > AuthorsMaxLength)
          AuthorsMaxLength = author.Length;
      }
  }
}