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
    public class user
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public string nickname { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string introduction { get; set; }
        public string headShot { get; set; }
    }
}
