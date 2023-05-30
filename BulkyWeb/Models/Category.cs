﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id  { get; set; }
        [Required]
        [MaxLength(30)]    //add server side validation
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage ="Display order must be between 1-1000")]     //server side validation
        public int DisplayOrder { get; set; }
    }
}
