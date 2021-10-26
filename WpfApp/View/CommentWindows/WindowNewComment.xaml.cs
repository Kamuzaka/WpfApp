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

namespace WpfApp.View.CommentWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowNewComment.xaml
    /// </summary>
    public partial class WindowNewComment : Window
    {
        public WindowNewComment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохранение данных по комментарию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
