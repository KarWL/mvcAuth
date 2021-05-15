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
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string Description { get; set; }

        public string UserId {get; set;}
        public ApplicationUser User {get; set;}
     
    }

}
