using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

using WpfApp.Model;



namespace WpfApp.ViewModel
{
    class CommentViewModel
    {
        public ObservableCollection <Comment> ListComment { get; set; } = new ObservableCollection <Comment> ();

        public CommentViewModel()
        {
            this.ListComment.Add(
                new Comment
                {
                    Id = 1,
                    BlogId = 1,
                    AuthorId = 3,
                    Content = "Комментарий 1",
                    DateComment = new DateTime(2020, 01, 10)
                });


            this.ListComment.Add(
                new Comment
                {
                    Id = 2,
                    BlogId = 2,
                    AuthorId = 4,
                    Content = "Комментарий 2",
                    DateComment = new DateTime(2020, 02, 20)
                });
        }

        public int MaxId()
        {
            int max = 0;

            foreach (var c in this.ListComment)
            {
                if (max < c.Id)
                {
                    max = c.Id;
                };
            }

            return max;
        }
    }
}
