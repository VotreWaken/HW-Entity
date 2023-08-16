using DapperEx.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
namespace WindowsFormsApp27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RequestCB.Items.Add("Add Author");
            RequestCB.Items.Add("Search Author By Id");
            RequestCB.Items.Add("Edit Author");
            RequestCB.Items.Add("Get All Authors");
            RequestCB.Items.Add("Get All Books and Authors");
            RequestCB.Items.Add("Get All Books by Author");
            RequestCB.Items.Add("Add Book");
            RequestCB.Items.Add("Search Book By Id");
            RequestCB.Items.Add("Edit Book");
            RequestCB.Items.Add("Get All Books");
        }

        void OneToMany(string id)
        {
            if (IdTB.Text == string.Empty)
            {
                return;
            }
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            var query = "SELECT * FROM Authors WHERE Id = @Id;"
                + "SELECT Id, Name, YearPress, Id_Author FROM Books WHERE Id_Author = @Id";

            var result = connection.QueryMultiple(query, new { Id = Convert.ToInt32(id) });

            try
            {
                var author = result.ReadSingle<Author>();
                author.Books = result.Read<Book>().ToList();

                AuthorLB.Items.Add(author);
                foreach (var book in author.Books)
                {
                    BookLB.Items.Add(book.Name + book.YearPress);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Id");
            }
        }
        void MultiTableQueryOneToMany()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            var query = "SELECT * FROM Authors JOIN Books ON Authors.Id = Books.Id_Author";

            var authors = new Dictionary<int, Author>();

            var result = connection.Query<Author, Book, Author>(
                query,
                (author, book) =>
                {

                    Author authorEntry;

                    if (!authors.TryGetValue(author.Id, out authorEntry))
                    {
                        authors.Add(author.Id, author);
                        author.Books = new List<Book>();
                        authorEntry = author;
                    }

                    authorEntry.Books.Add(book);

                    return authorEntry;
                },
                splitOn: "Id"
                );


            foreach (var pair in authors)
            {
                var author = pair.Value;
                AuthorLB.Items.Add($"{author.Id}: {author.FirstName} {author.LastName}");
                foreach (var book in author.Books)
                {
                    BookLB.Items.Add("Id Author: " + book.Id_Author + " " + book.Name);
                }
            }
        }
        public void AddAuthor(string name, string surname)
        {
            if (name == string.Empty || surname == string.Empty)
            {
                MessageBox.Show("Author Without Name or Surname Cannot be Created");
                return;
            }
            using (AuthorsRepository rep = new AuthorsRepository())
            {
                rep.Create(new Author
                {
                    FirstName = name,
                    LastName = surname
                });
            }
            MessageBox.Show($"Author successfully created\nName: {name}, Surname: {surname}");
        }
        public void SearchById(string id)
        {
            using (AuthorsRepository rep = new AuthorsRepository())
            {
                try
                {
                    if (id != string.Empty)
                    {
                        var author = rep.GetById(Convert.ToInt32(id));
                        MessageBox.Show(author.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Empty Id");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Id");
                }
            }
        }

        public void EditAuthor(string name, string surname, string id)
        {
            if (name == string.Empty || surname == string.Empty)
            {
                MessageBox.Show("Author Without Name or Surname Cannot be Edited");
                return;
            }
            using (AuthorsRepository rep = new AuthorsRepository())
            {
                try
                {
                    var author = rep.GetById(Convert.ToInt32(id));
                    author.FirstName = name;
                    author.LastName = surname;
                    rep.Update(author);
                }
                catch (Exception)
                {
                    MessageBox.Show("Undefined Author Id Cannot be Edited");
                }
            }
        }
        public void GetAllAuthor()
        {

            using (AuthorsRepository rep = new AuthorsRepository())
            {
                foreach (var item in rep.GetAll())
                {
                    AuthorLB.Items.Add(item);
                }
            }
        }
        private void RequestCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Surname";
            IdTB.ReadOnly = false;
            FindBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            CreateBtn.Enabled = false;
            NameTB.ReadOnly = false;
            SurnameTB.ReadOnly = false;
            NameTB.Text = string.Empty;
            SurnameTB.Text = string.Empty;
            AuthorLB.Items.Clear();
            BookLB.Items.Clear();  
            switch (RequestCB.SelectedIndex)
            {
                case 0:
                    IdTB.ReadOnly = true;
                    CreateBtn.Enabled = true;
                    break;
                case 1:
                    IdTB.ReadOnly = false;
                    NameTB.ReadOnly = true;
                    SurnameTB.ReadOnly = true;
                    FindBtn.Enabled = true;
                    break;
                case 2:
                    IdTB.ReadOnly = false;
                    UpdateBtn.Enabled = true;
                    break;
                case 3:
                    GetAllAuthor();
                    break;
                case 4:
                    IdTB.ReadOnly = false;
                    FindBtn.Enabled = true;
                    NameTB.ReadOnly = true;
                    SurnameTB.ReadOnly = true;
                    break;
                case 5:
                    MultiTableQueryOneToMany();
                    break;
                case 6:
                    CreateBtn.Enabled = true;
                    IdTB.ReadOnly = true;
                    label2.Text = "Pages";
                    break;
                case 7:
                    IdTB.ReadOnly = false;
                    FindBtn.Enabled = true;
                    NameTB.ReadOnly = true;
                    SurnameTB.ReadOnly = true;
                    break;
                case 8:
                    UpdateBtn.Enabled = true;
                    label2.Text = "Pages";
                    break;
                case 9:
                    GetAllBooks();
                    break;
                default:
                    break;
            }
        }


        public void AddBook(string name, string pages, string yearPress, string Id_Press, string Quantity)
        {
            if (name == string.Empty || pages == string.Empty)
            {
                MessageBox.Show("Book Without Name or Pages Cannot be Created");
                return;
            }
            using (BooksRepository rep = new BooksRepository())
            {
                try
                {
                    rep.Create(new Book
                    {
                        Name = name,
                        Pages = Convert.ToInt32(pages),
                        YearPress = Convert.ToInt32(yearPress),
                        Id_Press = Convert.ToInt32(Id_Press),
                        Quantity = Convert.ToInt32(Quantity),
                    });
                    MessageBox.Show($"Book successfully created\nName: {name}, Pages: {pages}");
                }
                catch (Exception)
                {
                    MessageBox.Show("Pages Input Error");
                }
            }
        }
        public void SearchByIdBook(string id)
        {
            using (BooksRepository rep = new BooksRepository())
            {
                try
                {
                    if (id != string.Empty)
                    {
                        var book = rep.GetById(Convert.ToInt32(id));
                        MessageBox.Show(book.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Empty Id");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Id");
                }
            }

        }

        public void EditBook(string name, string pages, string id)
        {
            if (name == string.Empty || pages == string.Empty)
            {
                MessageBox.Show("Book Without Name or Pages Cannot be Edited");
                return;
            }
            using (BooksRepository rep = new BooksRepository())
            {
                try
                {
                    var book = rep.GetById(Convert.ToInt32(id));
                    book.Name = name;
                    book.Pages = Convert.ToInt32(pages);
                    book.YearPress = 5;
                    book.Id_Press = 2;
                    book.Quantity = 2;
                    rep.Update(book);
                }
                catch (Exception)
                {
                    MessageBox.Show("Undefined Book Id Cannot be Edited");
                }
            }
        }
        public void GetAllBooks()
        {
            using (BooksRepository rep = new BooksRepository())
            {
                foreach (var item in rep.GetAll())
                {
                    AuthorLB.Items.Add(item);
                }
            }
        }
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (RequestCB.SelectedIndex == 0)
            {
                AddAuthor(NameTB.Text, SurnameTB.Text);
            }
            if (RequestCB.SelectedIndex == 6)
            {
                AddBook(NameTB.Text, SurnameTB.Text, "2002", "1", "5");
            }
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (RequestCB.SelectedIndex == 2)
            {
                EditAuthor(NameTB.Text, SurnameTB.Text, IdTB.Text);
            }
            if (RequestCB.SelectedIndex == 8)
            {
                EditBook(NameTB.Text, SurnameTB.Text, IdTB.Text);
            }
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            if (RequestCB.SelectedIndex == 1)
            {
                SearchById(IdTB.Text);
            }
            if (RequestCB.SelectedIndex == 7)
            {
                SearchByIdBook(IdTB.Text);
            }
            if (RequestCB.SelectedIndex == 4)
            {
                AuthorLB.Items.Clear();
                BookLB.Items.Clear();
                OneToMany(IdTB.Text);
            }
        }
    }
}
