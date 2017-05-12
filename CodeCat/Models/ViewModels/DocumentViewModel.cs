using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;

namespace CodeCat.Models.ViewModels
{
    public class DocumentViewModel
    {
        public DocumentModel document;

        public int? selectedDocument { get; set; }

        public List<DocumentModel> documents { get; set; }

        public string documentName { get; set; }

        public string docProjectName { get; set; }
    }
}