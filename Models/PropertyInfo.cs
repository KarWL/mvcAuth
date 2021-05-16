using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcApp.Models
{    
    public class PropertyInfo
    {

        [Display(Name = "Assest Id")]
        [DataType(DataType.Text)]
        public Guid Id { get; set; }
        
        [Display(Name = "Assest Name")]
        [DataType(DataType.Text)]
        [Required]
        public string AssetName { get; set; }

        [Display(Name = "Assest Type")]
        [DataType(DataType.Text)]
        public string AssetType { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public string UserId {get; set;}
        public ApplicationUser User {get; set;}
     
    }

}
