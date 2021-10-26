using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.ViewModel;
using WpfApp.Model;



namespace WpfApp.Helper
{
    class CommentDPO
    {
        public int Id { get; set; }
        public string Blog { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }

        public CommentDPO() { }
        public CommentDPO(int Id, string Blog, string Author, string Content, DateTime DateComment)
        {
            this.Id = Id;
            this.Blog = Blog;
            this.Author = Author;
            this.Content = Content;
            this.DateComment = DateComment;
        }

        public CommentDPO CopyFromComment(Comment comment)
        {
            CommentDPO cmtDPO = new CommentDPO();

            AuthorViewModel vmAuthor = new AuthorViewModel();
            BlogViewModel vmBlog = new BlogViewModel();

            string author = string.Empty;
            string blog = string.Empty;

            foreach (var a in vmAuthor.ListAuthor)
            {
                if (a.Id == comment.AuthorId)
                {
                    author = a.LastName + " " + a.FirstName;
                    break;
                }
            }

            foreach (var b in vmBlog.ListBlog)
            {
                if (b.Id == comment.BlogId)
                {
                    blog = b.Title;
                    break;
                }
            }

            if (author != string.Empty && blog != string.Empty)
            {
                cmtDPO.Id = comment.Id;
                cmtDPO.Blog = blog;
                cmtDPO.Author = author;
                cmtDPO.Content = comment.Content;
                cmtDPO.DateComment = comment.DateComment;
            }

            return cmtDPO;
        }

        public CommentDPO ShallowCopy()
        {
            return (CommentDPO)this.MemberwiseClone();
        }
    }
}