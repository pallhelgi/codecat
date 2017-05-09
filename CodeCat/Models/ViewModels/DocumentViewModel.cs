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
        public List<DocumentModel> documents { get; set; }   
    }
}