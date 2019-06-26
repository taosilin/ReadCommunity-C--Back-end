using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class comment
    {
        [Key]
        public int commentid { get; set; }
        public Nullable<int> bookid { get; set; }
        public string username { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> commenttime { get; set; }
    }
}
