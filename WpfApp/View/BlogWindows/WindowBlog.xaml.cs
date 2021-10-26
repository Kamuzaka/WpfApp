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
using WpfApp.View.BlogWindows;



namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowBlog.xaml
    /// </summary>
    public partial class WindowBlog : Window
    {
        private BlogViewModel vmBlog;
        private AuthorViewModel vmAuthor;
        private ObservableCollection<BlogDPO> blogsDPO;
        private ObservableCollection<BlogDPO> authors;


        public WindowBlog()
        {
            InitializeComponent();

            vmBlog = new BlogViewModel();
            vmAuthor = new AuthorViewModel();
            authors = new ObservableCollection<BlogDPO>();

            foreach (var author in vmAuthor.ListAuthor)
            {
                BlogDPO b = new BlogDPO
                {
                    Author = author.LastName + " " + author.FirstName
                };
                authors.Add(b);
            }

            blogsDPO = new ObservableCollection<BlogDPO>();


            foreach (var blog in vmBlog.ListBlog)
            {
                BlogDPO b = new BlogDPO();
                b = b.CopyFromBlog(blog);
                blogsDPO.Add(b);
            }

            lvBlog.ItemsSource = blogsDPO;
        }

        /// <summary>
        /// Добавление новых данных по блогу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewBlog wnBlog = new WindowNewBlog
            {
                Title = "Новый блог",
                Owner = this
            };

            int maxIdBlog = vmBlog.MaxId() + 1;

            BlogDPO blg = new BlogDPO
            {
                Id = maxIdBlog,
                Date = DateTime.Now
            };

            wnBlog.DataContext = blg;

            ////////////////////////////////////////////////
            wnBlog.CbAuthor.ItemsSource = authors;
            ////////////////////////////////////////////////

            if (wnBlog.ShowDialog() == true)
            {
                blg.Author = ((BlogDPO)wnBlog.CbAuthor.SelectedValue).Author;

                blogsDPO.Add(blg);

                Blog b = new Blog();
                b = b.CopyFromBlogDPO(blg);
                vmBlog.ListBlog.Add(b);
            }
        }

        /// <summary>
        /// Редактирование данных по блогу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewBlog wnBlog = new WindowNewBlog
            {
                Title = "Редактирование данных",
                Owner = this
            };

            BlogDPO blgDPO = (BlogDPO)lvBlog.SelectedValue;
            BlogDPO tempBlgDPO;

            if (blgDPO != null)
            {
                tempBlgDPO = blgDPO.ShallowCopy();

                wnBlog.DataContext = tempBlgDPO;
                ////////////////////////////////////////////////
                wnBlog.CbAuthor.ItemsSource = authors;
                ////////////////////////////////////////////////
                wnBlog.CbAuthor.Text = tempBlgDPO.Author;

                if (wnBlog.ShowDialog() == true)
                {
                    blgDPO.Author = ((BlogDPO)wnBlog.CbAuthor.SelectedValue).Author;
                    blgDPO.Title = tempBlgDPO.Title;
                    blgDPO.Content = tempBlgDPO.Content;
                    blgDPO.Date = tempBlgDPO.Date;

                    lvBlog.ItemsSource = null;
                    lvBlog.ItemsSource = blogsDPO;

                    FindBlog finder = new FindBlog(blgDPO.Id);
                    List<Blog> listBlog = vmBlog.ListBlog.ToList();
                    Blog b = listBlog.Find(new Predicate<Blog>(finder.BlogPredicate));

                    b = b.CopyFromBlogDPO(blgDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать блог для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        /// <summary>
        /// Удаление данных по блогу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BlogDPO blog = (BlogDPO)lvBlog.SelectedItem;

            if (blog != null)
            {
               MessageBoxResult result = MessageBox.Show("Удалить данные по блогу: \n" + blog.Author + ":\t" + blog.Title,
                   "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    blogsDPO.Remove(blog);
                    Blog blg = new Blog();
                    blg = blg.CopyFromBlogDPO(blog);
                    vmBlog.ListBlog.Remove(blg);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по блогу для удаления",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
