using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;

namespace CodeCat.Services
{
    public class DocumentService : ServiceBase
    {
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
        
        public bool addDocument(DocumentModel doc)
        {
            addDocumentToDB(doc);

            return false;
        }

        public bool deleteDocument(int documentID)
        {
            deleteDocumentFromDB(documentID);
            return true;
        }

        /*public DocumentModel getDocumentByID(int documentID)
        {
            return getDocumentByID(documentID);
        }*/
    }
}