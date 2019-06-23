using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml.Linq;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project_back_end.Models
{
    [Table("book_info")]
    public class Book
    {
        [Key]
        [Column(TypeName = "int")]
        [Required]
        public int id { get; set; }

        public string book_name { get; set; }

        public string author { get; set; }

        public string publisher { get; set; }

        public string translator { get; set; }

        public string publish_date { get; set; }

        public int page_num { get; set; }

        public string isbn { get; set; }


    }
}