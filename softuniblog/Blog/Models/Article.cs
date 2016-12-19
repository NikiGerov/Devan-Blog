using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Article
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;

        public Article()
        {
            this.Tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
        }

        public Article(string authorId, string title, string content, string imgurl, int categoryId)
        {
            this.AuthorId = authorId;
            this.Title = title;
            this.Content = content;
            this.ImgUrl = imgurl;
            this.CategoryId = categoryId;
            this.Tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
            this.ViewCounter = 0;
            ;

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImgUrl { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public int ViewCounter { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool IsUserAuthor(string username)
        {
            return this.Author.UserName.Equals(username);
        }
    }
}