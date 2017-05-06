using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    enum documentType { html, css, cplusplus, js }

    public class DocumentModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Document name")]
        [Required(ErrorMessage = "You must enter a name for the document!")]
        public string name { get; set; }

        public string content { get; set; }

        [Display(Name = "Document type")]
        [Required(ErrorMessage = "You must select a document type!")]
        documentType type { get; set; }

        public virtual ProjectModel projects { get; set; }
    }
}

