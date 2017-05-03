using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    enum documentType { html, css, cplusplus, js }

    public class DocumendModel
    {
        int ID { get; set; }
        string name { get; set; }
        string content { get; set; }
        documentType type { get; set; }
    }
}