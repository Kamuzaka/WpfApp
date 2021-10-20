using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp.Model
{
    class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AuthoId { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }

        public Comment() { }
        public Comment(int Id, int BlogId, int AuthoId, string Content, DateTime DateComment)
        {
            this.Id = Id;
            this.BlogId = BlogId;
            this.AuthoId = AuthoId;
            this.Content = Content;
            this.DateComment = DateComment;
        }
    }
}
