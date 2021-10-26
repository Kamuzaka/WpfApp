using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.Helper;
using WpfApp.ViewModel;



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

        public Blog CopyFromBlogDPO(BlogDPO b)
        {
            AuthorViewModel vmAuthor = new AuthorViewModel();
            int authorId = 0;

            foreach (var a in vmAuthor.ListAuthor)
            {
                if ((a.LastName + " " + a.FirstName) == b.Author)
                {
                    authorId = a.Id;
                    break;
                }
            }

            if (authorId != 0)
            {
                this.Id = b.Id;
                this.AuthorId = authorId;
                this.Title = b.Title;
                this.Content = b.Content;
                this.Date = b.Date;
            }

            return this;
        }
    }
}
