using Dapper;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DocumentData : IDocumentData
    {
        private readonly ISqlDataAccess _db;

        public DocumentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<DocumentModel>> GetDocuments()
        {
            string sql = "select*from dbo.Documents order by id asc";

            return _db.LoadData<DocumentModel, dynamic>(sql, new { });
        }

        public Task InsertDocument(DocumentModel document)
        {
            string sql = @"insert into dbo.Documents (Name, StatusCode, Freeze)
                           values (@Name, @StatusCode, @Freeze)";

            return _db.SaveData(sql, document);
        }

        public async Task<List<DocumentModel>> SortDocument(int? searchString)
        {
            string sql = "select*from dbo.Documents order by id asc";

            using (var connection = new SqlConnection("Data Source=LAPTOP-944TFLEK;Initial Catalog=TestingPurpose;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var documents = connection.Query<DocumentModel>(sql).AsQueryable();
                var queryStringParam = new Dictionary<string, int>
                {
                    ["CurrentFilter"] = searchString==null ? -1 : searchString.Value,
                };
                if (searchString != -1)
                {
                    documents = documents.Where(a => a.StatusCode == searchString);
                }
                else
                {
                return   await _db.LoadData<DocumentModel, dynamic>(sql, new { });
                }


                return documents.ToList();
            }




        }
    }
}
