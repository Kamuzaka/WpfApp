using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

using WpfApp.Model;



namespace WpfApp.ViewModel
{
    class AuthorViewModel
    {
        public ObservableCollection <Author> ListAuthor { get; set; } = new ObservableCollection <Author> ();

        public AuthorViewModel()
        {
            this.ListAuthor.Add(
                new Author
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Email = "Иванов@mail.ru",
                    Phone = "8 928 111 11 11",
                    DateRegistration = new DateTime(2001, 01, 01)
                });


            this.ListAuthor.Add(
                new Author
                {
                    Id = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    Email = "Петров@mail.ru",
                    Phone = "8 928 222 22 22",
                    DateRegistration = new DateTime(2002, 02, 02)
                });


            this.ListAuthor.Add(
                new Author
                {
                    Id = 3,
                    FirstName = "Виктор",
                    LastName = "Викторов",
                    Email = "Викторов@mail.ru",
                    Phone = "8 928 333 33 33",
                    DateRegistration = new DateTime(2003, 03, 03)
                });


            this.ListAuthor.Add(
                new Author
                {
                    Id = 4,
                    FirstName = "Сидор",
                    LastName = "Сидоров",
                    Email = "Сидоров@mail.ru",
                    Phone = "8 928 444 44 44",
                    DateRegistration = new DateTime(2004, 04, 04)
                });

            this.ListAuthor.Add(
                new Author
                {
                    Id = 5,
                    FirstName = "Артур",
                    LastName = "Артуров",
                    Email = "Артуров@mail.ru",
                    Phone = "8 928 555 55 55",
                    DateRegistration = new DateTime(2005, 05, 05)
                });
        }

        public int MaxId()
        {
            int max = 0;

            foreach (var a in this.ListAuthor)
            {
                if (max < a.Id)
                {
                    max = a.Id;
                };
            }

            return max;
        }
    }
}
