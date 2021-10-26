using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.Helper;
using WpfApp.ViewModel;



namespace WpfApp.Model
{
    class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }

        public Comment() { }
        public Comment(int Id, int BlogId, int AuthoId, string Content, DateTime DateComment)
        {
            this.Id = Id;
            this.BlogId = BlogId;
            this.AuthorId = AuthorId;
            this.Content = Content;
            this.DateComment = DateComment;
        }

        public Comment CopyFromCommentDPO(CommentDPO c)
        {
            AuthorViewModel vmAuthor = new AuthorViewModel();
            BlogViewModel vmBlog = new BlogViewModel();

            int authorId = 0;
            int blogId = 0;

            foreach (var a in vmAuthor.ListAuthor)
            {
                if ((a.LastName + " " + a.FirstName) == c.Author)
                {
                    authorId = a.Id;
                    break;
                }
            }

            foreach (var b in vmBlog.ListBlog)
            {
                if (b.Title == c.Blog)
                {
                    blogId = b.Id;
                    break;
                }
            }

            if (authorId != 0 && blogId != 0)
            {
                this.Id = c.Id;
                this.BlogId = blogId;
                this.AuthorId = authorId;
                this.Content = c.Content;
                this.DateComment = c.DateComment;
            }

            return this;
        }
    }
}
