using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

using WpfApp.Model;



namespace WpfApp.ViewModel
{
    class BlogViewModel
    {
        public ObservableCollection<Blog> ListBlog { get; set; } = new ObservableCollection<Blog>();


        public BlogViewModel()
        {
            this.ListBlog.Add(
                new Blog
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Заголовок 1",
                    Content = "Контент 1",
                    Date = new DateTime(2020, 01, 01)
                });


            this.ListBlog.Add(
                new Blog
                {
                    Id = 2,
                    AuthorId = 2,
                    Title = "Заголовок 2",
                    Content = "Контент 2",
                    Date = new DateTime(2020, 02, 02)
                });
        }

        public int MaxId()
        {
            int max = 0;

            foreach (var b in this.ListBlog)
            {
                if (max < b.Id)
                {
                    max = b.Id;
                };
            }

            return max;
        }
    }
}
