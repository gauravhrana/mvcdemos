namespace MVCDemos.Models
{
    public class Book
    {

        public virtual int? BookId { get; set; }
        public virtual string BookCode { get; set; }
        public virtual string BookName { get; set; }
        public virtual string BookDesc { get; set; }
        public virtual string BookAuthor { get; set; }

        //public string Mode { get; set; }

    }
}