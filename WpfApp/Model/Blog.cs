using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp.Model
{
    class Blog
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Blog() { }
        public Blog(int Id, int AuthorId, string Title, string Content, DateTime Date)
        {
            this.Id = Id;
            this.AuthorId = AuthorId;
            this.Title = Title;
            this.Content = Content;
            this.Date = Date;
        }
    }
}
