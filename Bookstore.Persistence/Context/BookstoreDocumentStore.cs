using Raven.Client;
using Raven.Client.Document;
using Bookstore.Persistence.Interfaces;

namespace Bookstore.Persistence.Context
{
    public class BookstoreDocumentStore : IStore
    {
        public IDocumentStore DocumentStore { get; set; }

        public BookstoreDocumentStore()
        {
            DocumentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Books"
            };

            // Inicializa o gerenciador de sessão e registra os índices
            DocumentStore.Initialize();
            //IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), DocumentStore);
        }
    }
}
