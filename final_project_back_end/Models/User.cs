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
    [Table("user")]
    public class User
    {
        [Key]
        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(45)]
        public string username { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(45)]
        public string password { get; set; }

        public string nickname { get; set; }

        public string gender { get; set; }

        public string birthday { get; set; }

        public string introduction { get; set; }

        public string headShot { get; set; }
    }
}