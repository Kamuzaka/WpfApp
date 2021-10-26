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

using WpfApp.Model;
using WpfApp.ViewModel;
using WpfApp.View.AuthorWindows;



namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthor.xaml
    /// </summary>
    public partial class WindowAuthor : Window
    {
        private AuthorViewModel vmAuthor { get; set; } = new AuthorViewModel();

        public WindowAuthor()
        {
            InitializeComponent();
            lvAuthor.ItemsSource = vmAuthor.ListAuthor;
        }


        /// <summary>
        /// Добавление новых данных по автору
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAuthor wnAuthor = new WindowNewAuthor
            {
                Title = "Новый автор",
                Owner = this
            };

            int maxIdAuthor = vmAuthor.MaxId() + 1;

            Author author = new Author
            {
                Id = maxIdAuthor
            };

            wnAuthor.DataContext = author;

            if (wnAuthor.ShowDialog() == true)
            {
                vmAuthor.ListAuthor.Add(author);
            }
        }

        /// <summary>
        /// Редактирование данных по автору
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAuthor wnAuthor = new WindowNewAuthor
            {
                Title = "Редактирование автора",
                Owner = this
            };

            Author author = lvAuthor.SelectedItem as Author;

            if (author != null)
            {
                Author tempAuthor = author.ShallowCopy();
                wnAuthor.DataContext = tempAuthor;

                if (wnAuthor.ShowDialog() == true)
                {
                    // сохранение данных
                    author.FirstName = tempAuthor.FirstName;
                    author.LastName = tempAuthor.LastName;
                    author.Email = tempAuthor.Email;
                    author.Phone = tempAuthor.Phone;
                    author.DateRegistration = tempAuthor.DateRegistration;

                    lvAuthor.ItemsSource = null;
                    lvAuthor.ItemsSource = vmAuthor.ListAuthor;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать автора для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Удаление данных по автору
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Author author = (Author)lvAuthor.SelectedItem;
            if (author != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные автора: " + author.LastName + " " + author.FirstName,
                    "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    vmAuthor.ListAuthor.Remove(author);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать автора для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}