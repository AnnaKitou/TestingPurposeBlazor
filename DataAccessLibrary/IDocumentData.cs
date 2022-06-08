using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDocumentData
    {
        Task<List<DocumentModel>> GetDocuments();
        Task InsertDocument(DocumentModel document);
        Task<List<DocumentModel>> SortDocument(int? searchString);
    }
}