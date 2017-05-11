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

        public void saveDocument(int documentID, string content)
        {
            var replace = from doc in _db.DocumentModel
                          where doc.ID == documentID
                          select doc;

            foreach (DocumentModel doc in replace)
            {
                doc.content = content;
            }

            _db.SaveChanges();
        }

        //adds a doccument to database
        public bool addDocument(DocumentModel doc)
        {
            //IF document name already exissts within the same project: return false
            List<DocumentModel> dModel = _db.DocumentModel.Where(d => d.projectID == doc.projectID).ToList();

            foreach(DocumentModel d in dModel)
            {
                if(d.name == doc.name)
                {
                    return false;
                }

            }

            _db.DocumentModel.Add(doc);
            _db.SaveChanges();

            return false;
        }

        //Deletes a single document from database
        public void deleteDocument(int documentID)
        {
            var delete = from doc in _db.DocumentModel
                         where doc.ID == documentID
                         select doc;

            var item = delete.ToList().First();

            _db.DocumentModel.Remove(item);
            _db.SaveChanges();
        }

        public int getProjectIDByDocumentID(int documentID)
        {
            DocumentModel document = _db.DocumentModel.FirstOrDefault(x => x.ID == documentID);
            int projectID = document.projectID;
            return projectID;
        }

        public DocumentModel getDocumentByID(int documentID)
        {
            return _db.DocumentModel.FirstOrDefault(x => x.ID == documentID);
        }
    }
}