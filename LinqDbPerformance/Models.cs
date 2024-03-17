using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinqDbPerformance
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class Reader
    {
        public int ReaderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime MembershipStartDate { get; set; }
    }

    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
