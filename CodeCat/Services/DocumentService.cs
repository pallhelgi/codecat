using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;

namespace CodeCat.Services
{
    public class DocumentService : ServiceBase
    {
        public DocumentService(IAppDataContext context) : base(context)
        {

        }

        public DocumentModel document;

        public bool saveDocument(int documentID, string content)
        {
            var replace = from doc in _db.DocumentModel
                          where doc.ID == documentID
                          select doc;

            foreach (DocumentModel doc in replace)
            {
                doc.content = content;
            }

            _db.SaveChanges();

            return true;
        }

        //adds a doccument to database
        public bool addDocument(DocumentModel doc)
        {
            _db.DocumentModel.Add(doc);
            _db.SaveChanges();

            return false;
        }

        //Deletes a single document from database
        public bool deleteDocument(int documentID)
        {
            var delete = from doc in _db.DocumentModel
                         where doc.ID == documentID
                         select doc;

            var item = delete.ToList().First();
            _db.DocumentModel.Remove(item);
            _db.SaveChanges();

            return true;
        }

        /*public DocumentModel getDocumentByID(int documentID)
        {
            return getDocumentByID(documentID);
        }*/
    }
}