using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    enum documentType { html, css, cplusplus, js }

    public class DocumendModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        documentType type { get; set; }
    }
}