using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace GrowHealthy.Models
{
    public class NewsModels
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Body { get; set; }
        public string Writer { get; set; }

    }

    public class NewsDBContext : DbContext
    {
        public DbSet<NewsModels> NewsPosts { get; set; }
    }
}