using System.Linq;
using System.Web.Mvc;
using Bookstore.Application.Queries.Common;
using Bookstore.Domain.Entities.Books;
using Bookstore.Domain.Interfaces;
using Raven.Client;

namespace Bookstore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IService<Book> _service;
        private readonly IDocumentSession _session;

        public BooksController(IService<Book> service, IDocumentSession session)
        {
            _service = service;
            _session = session;
        }

        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult List(string sortKey)
        {
            IQueryable<Book> books = _session.Query<Book>();

            var orderAscending = true;
            switch (sortKey)
            {
                case "Title":
                    orderAscending = TempData["TitleOrderByAscending"] == null ? false : (bool) TempData["TitleOrderByAscending"];
                    books = books.OrderByWithDirection(b => b.Title, orderAscending);
                    TempData["TitleOrderByAscending"] = !orderAscending;
                    break;

                case "Author":
                    orderAscending = TempData["AuthorOrderByAscending"] == null ? false : (bool)TempData["AuthorOrderByAscending"];
                    books = books.OrderByWithDirection(b => b.Author, orderAscending);
                    TempData["AuthorOrderByAscending"] = !orderAscending;
                    break;

                case "Price":
                    orderAscending = TempData["PriceOrderByAscending"] == null ? false : (bool)TempData["PriceOrderByAscending"];
                    books = books.OrderByWithDirection(b => b.Price, orderAscending);
                    TempData["PriceOrderByAscending"] = !orderAscending;
                    break;

                case "YearPublished":
                    orderAscending = TempData["YearPublishedOrderByAscending"] == null ? false : (bool)TempData["YearPublishedOrderByAscending"];
                    books = books.OrderByWithDirection(b => b.YearPublished, orderAscending);
                    TempData["YearPublishedOrderByAscending"] = !orderAscending;
                    break;

                default:
                    books = books.OrderByWithDirection(b => b.Title, true);
                    break;
            }

            return PartialView(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO -- tratar erros gerados na camada de aplicação
                _service.Create(book);

                TempData["status"] = "alert-success";
                TempData["message"] = string.Format("Livro \"{0}\" criado com sucesso.", book.Title);

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["status"] = "alert-danger";
                TempData["message"] = string.Format("Não foi possível criar o usuário - erro no acesso ao banco de dados.");
                return View(book);
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string bookId)
        {
            var book = _service.GetById(bookId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Book book)
        {
            try
            {
                // TODO -- o mapeamento abaixo deve ficar em um AppService especializado - BookAppService
                var updatedBook = _service.GetById(id);

                // atualiza campos do livro
                updatedBook.Title = book.Title;
                updatedBook.Author = book.Author;
                updatedBook.Description = book.Description;
                updatedBook.Price = book.Price;
                updatedBook.YearPublished = book.YearPublished;

                _service.Update();

                TempData["status"] = "alert-success";
                TempData["message"] = string.Format("Livro \"{0}\" atualizado com sucesso.", book.Title);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
