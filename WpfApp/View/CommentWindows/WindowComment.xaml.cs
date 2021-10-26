using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

using WpfApp.Model;
using WpfApp.Helper;
using WpfApp.ViewModel;
using WpfApp.View.CommentWindows;



namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowComment.xaml
    /// </summary>
    public partial class WindowComment : Window
    {
        private CommentViewModel vmComment;
        private AuthorViewModel vmAuthor;
        private BlogViewModel vmBlog;
        private ObservableCollection<CommentDPO> commentsDPO;
        private ObservableCollection<CommentDPO> commentsAuthors;
        private ObservableCollection<CommentDPO> commentsBlogs;

        public WindowComment()
        {
            InitializeComponent();

            vmComment = new CommentViewModel();
            vmAuthor = new AuthorViewModel();
            vmBlog = new BlogViewModel();

            commentsAuthors = new ObservableCollection<CommentDPO>();

            foreach (var author in vmAuthor.ListAuthor)
            {
                CommentDPO c = new CommentDPO
                {
                    Author = author.LastName + " " + author.FirstName
                };
                commentsAuthors.Add(c);
            }

            commentsBlogs = new ObservableCollection<CommentDPO>();

            foreach (var blog in vmBlog.ListBlog)
            {
                CommentDPO c = new CommentDPO
                {
                    Blog = blog.Title
                };
            commentsBlogs.Add(c);
            }

            commentsDPO = new ObservableCollection<CommentDPO>();

            foreach (var coment in vmComment.ListComment)
            {
                CommentDPO b = new CommentDPO();
                b = b.CopyFromComment(coment);
                commentsDPO.Add(b);
            }

            lvComment.ItemsSource = commentsDPO;
        }

        /// <summary>
        /// Добавление новых данных по комментарию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewComment wnComment = new WindowNewComment
            {
                Title = "Новый комментарий",
                Owner = this
            };

            int maxIdComment = vmComment.MaxId() + 1;

            CommentDPO cmt = new CommentDPO
            {
                Id = maxIdComment,
                DateComment = DateTime.Now
            };

            wnComment.DataContext = cmt;

            wnComment.CbAuthor.ItemsSource = commentsAuthors;
            wnComment.CbBlog.ItemsSource = commentsBlogs;

            if (wnComment.ShowDialog() == true)
            {
                cmt.Author = ((CommentDPO)wnComment.CbAuthor.SelectedValue).Author;
                cmt.Blog = ((CommentDPO)wnComment.CbBlog.SelectedValue).Blog;

                commentsDPO.Add(cmt);

                Comment c = new Comment();
                c = c.CopyFromCommentDPO(cmt);
                vmComment.ListComment.Add(c);
            }
        }

        /// <summary>
        /// Редактирование данных по комментарию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewComment wnComment = new WindowNewComment
            {
                Title = "Редактирование данных",
                Owner = this
            };

            CommentDPO cmtDPO = (CommentDPO)lvComment.SelectedValue;
            CommentDPO tempCmtDPO;

            if (cmtDPO != null)
            {
                tempCmtDPO = cmtDPO.ShallowCopy();

                wnComment.DataContext = tempCmtDPO;
                wnComment.CbAuthor.ItemsSource = commentsAuthors;
                wnComment.CbBlog.ItemsSource = commentsBlogs;
                wnComment.CbAuthor.Text = tempCmtDPO.Author;
                wnComment.CbBlog.Text = tempCmtDPO.Blog;

                if (wnComment.ShowDialog() == true)
                {
                    cmtDPO.Author = ((CommentDPO)wnComment.CbAuthor.SelectedValue).Author;
                    cmtDPO.Blog = ((CommentDPO)wnComment.CbBlog.SelectedValue).Blog;

                    cmtDPO.Content = tempCmtDPO.Content;
                    cmtDPO.DateComment = tempCmtDPO.DateComment;

                    lvComment.ItemsSource = null;
                    lvComment.ItemsSource = commentsDPO;

                    FindBlog finderB = new FindBlog(cmtDPO.Id);
                    FindAuthor finderA = new FindAuthor(cmtDPO.Id);

/*                    List<Comment> listBlog = vmBlog.ListBlog.ToList();
                    List<Blog> listBlog = vmBlog.ListBlog.ToList();
                    Blog b = listBlog.Find(new Predicate<Blog>(finder.BlogPredicate));

                    b = b.CopyFromBlogDPO(blgDPO);*/
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать комментарий для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        /// <summary>
        /// Удаление данных по комментарию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CommentDPO comment = (CommentDPO)lvComment.SelectedItem;

            if (comment != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по комментарию: \n" + comment.Author + ":\t" + comment.Content,
                    "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    commentsDPO.Remove(comment);
                    Comment cmt = new Comment();

                    cmt = cmt.CopyFromCommentDPO(comment);
                    vmComment.ListComment.Remove(cmt);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать комментарий для удаления",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
