using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.ViewModel;
using WpfApp.Model;



namespace WpfApp.Helper
{
    class FindBlog
    {
        int Id;

        public FindBlog(int Id)
        {
            this.Id = Id;
        }

        public bool BlogPredicate(Blog blog)
        {
            return blog.Id == Id;
        }
    }
}
