using System;
using Raven.Client;

namespace Bookstore.Persistence.Interfaces
{
    public interface IStore
    {
        IDocumentStore DocumentStore { get; }
    }
}
