using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.ViewModel;
using WpfApp.Model;



namespace WpfApp.Helper
{
    class BlogDPO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


        public BlogDPO() { }
        public BlogDPO(int Id, string Author, string Title, string Content, DateTime Date)
        {
            this.Id = Id;
            this.Author = Author;
            this.Title = Title;
            this.Content = Content;
            this.Date = Date;
        }

        public BlogDPO CopyFromBlog(Blog blog)
        {
            BlogDPO blgDPO = new BlogDPO();
            AuthorViewModel vmAuthor = new AuthorViewModel();

            string author = string.Empty;

            foreach (var a in vmAuthor.ListAuthor)
            {
                if (a.Id == blog.AuthorId)
                {
                    author = a.LastName + " " + a.FirstName;
                    break;
                }
            }

            if (author != string.Empty)
            {
                blgDPO.Id = blog.Id;
                blgDPO.Author = author;
                blgDPO.Title = blog.Title;
                blgDPO.Content = blog.Content;
                blgDPO.Date = blog.Date;
            }

            return blgDPO;
        }

        public BlogDPO ShallowCopy()
        {
            return (BlogDPO)this.MemberwiseClone();
        }
    }
}