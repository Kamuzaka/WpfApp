using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.ViewModel;
using WpfApp.Model;



namespace WpfApp.Helper
{
    class FindAuthor
    {
        int Id;

        public FindAuthor(int Id)
        {
            this.Id = Id;
        }

        public bool AuthorPredicate(Author author)
        {
            return author.Id == Id;
        }
    }
}
