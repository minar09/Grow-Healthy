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

    [Table("BlogCommentReplies")]
    public class BlogCommentReplies
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BlogID { get; set; }
        public int CommentID { get; set; }
        public string Body { get; set; }
        public DateTime publishDate { get; set; }
        public string Writer { get; set; }
    }


    [Table("BlogComments")]
    public class BlogComments
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BlogID { get; set; }
        public string Body { get; set; }
        public DateTime publishDate { get; set; }
        public string Writer { get; set; }

    }

    [Table("BlogModels")]
    public class BlogModels
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Genre { get; set; }
        public string Body { get; set; }
        public string Writer { get; set; }

    }

   
    public class BlogDBContext : DbContext
    {
        public DbSet<BlogModels> BlogPosts { get; set; }
        public DbSet<BlogComments> BlogPostComments { get; set; }
        public DbSet<BlogCommentReplies> BlogCommentReplies { get; set; }
    }
}