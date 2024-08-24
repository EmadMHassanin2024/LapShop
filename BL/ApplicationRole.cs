using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //TbForms
    //TbPremission 
    // ApplicationRole: IdentityRole
  public class ApplicationRole: IdentityRole
    {
        public string RolePermisstions { get; set; }


    }
}
