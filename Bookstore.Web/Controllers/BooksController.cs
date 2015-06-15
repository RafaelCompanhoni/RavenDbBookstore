using System.Collections.Generic;
using System.Web.Mvc;
using Bookstore.Domain.Entities.Books;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IService<Book> _service;

        public BooksController(IService<Book> service)
        {
            _service = service;
        }

        // GET: Books
        public ActionResult Index()
        {
            List<Book> books = _service.GetAll();
            return View(books);
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
