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

        public DocumentModel getDocument(int documentID)
        {
            return null;
        }

        public bool saveDocument(int documentID, string content)
        {
            saveDocumentToDB(documentID, content);

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
    }
}