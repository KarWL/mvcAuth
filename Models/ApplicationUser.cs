using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace mvcApp.Models
{    
    public class ApplicationUser : IdentityUser
    {       
         public ICollection<PropertyInfo> PropertyInfos { get; set; }
     
    }

}
