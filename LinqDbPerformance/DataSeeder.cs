using Microsoft.EntityFrameworkCore;

namespace LinqDbPerformance
{
    public static class DataSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var numberOfBooks = 50000;
            var numberOfReaders = 50000;
            var numberOfLoans = 100000;
            
            var books = GenerateBooks(numberOfBooks);
            modelBuilder.Entity<Book>().HasData(books);

            var readers = GenerateReaders(numberOfReaders);
            modelBuilder.Entity<Reader>().HasData(readers);

            var loans = GenerateLoans(numberOfLoans, books, readers);
            modelBuilder.Entity<Loan>().HasData(loans);
        }
        static List<Book> GenerateBooks(int count)
        {
            var books = new List<Book>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                books.Add(new Book
                {
                    BookId = i+1,
                    Title = $"Book {i + 1}",
                    Author = $"Author {random.Next(1, 100)}",
                    ISBN = $"ISBN-{random.Next(100000000, 999999999)}",
                    PublishedDate = DateTime.Now.AddYears(-random.Next(1, 20))
                });
            }

            return books;
        }
        static List<Reader> GenerateReaders(int count)
        {
            var readers = new List<Reader>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                readers.Add(new Reader
                {
                    ReaderId = i + 1,
                    Name = $"Reader {i + 1}",
                    Email = $"reader{i + 1}@example.com",
                    MembershipStartDate = DateTime.Now.AddYears(-random.Next(1, 10))
                }) ;
            }

            return readers;
        }

        static List<Loan> GenerateLoans(int count, List<Book> books, List<Reader> readers)
        {
            var loans = new List<Loan>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                var book = books[random.Next(books.Count)];
                var reader = readers[random.Next(readers.Count)];

                loans.Add(new Loan
                {
                    LoanId = i+1,
                    BookId = book.BookId,
                    ReaderId = reader.ReaderId,
                    IssueDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                    DueDate = DateTime.Now.AddDays(random.Next(1, 30))
                });
            }

            return loans;
        }
    }
}
