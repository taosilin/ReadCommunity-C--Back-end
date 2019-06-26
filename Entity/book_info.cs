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
    public class book_info
    {
        [Key]
        public int id { get; set; }
        public string book_name { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string translator { get; set; }
        public string publish_date { get; set; }
        public Nullable<int> page_num { get; set; }
        public string isbn { get; set; }
        public Nullable<float> score { get; set; }
        public Nullable<int> rating_num { get; set; }
        public string book_image { get; set; }
        public string introduction { get; set; }
        public string tags { get; set; }
        public string author_info { get; set; }
        public string producer { get; set; }
        public string original_name { get; set; }
        public string binding { get; set; }
        public string subtitle { get; set; }
        public string series { get; set; }
        public Nullable<float> star1 { get; set; }
        public Nullable<float> star2 { get; set; }
        public Nullable<float> star3 { get; set; }
        public Nullable<float> star4 { get; set; }
        public Nullable<float> star5 { get; set; }

    }
}
