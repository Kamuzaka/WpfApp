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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfApp.View;



namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdAuthor { get; set; }
        public static int IdBlog { get; set; }
        public static int IdComment { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Author_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAuthor wAuthor = new WindowAuthor();
            wAuthor.Show();
        }

        private void Blog_OnClick(object sender, RoutedEventArgs e)
        {
            WindowBlog wBlog = new WindowBlog();
            wBlog.Show();
        }

        private void Comment_OnClick(object sender, RoutedEventArgs e)
        {
            WindowComment wComment = new WindowComment();
            wComment.Show();
        }
    }
}
