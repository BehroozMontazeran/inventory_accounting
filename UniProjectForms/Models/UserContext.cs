using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UniProjectForms.Models
{
    public class UserContext :DbContext
    {
        public DbSet<FormModel> Forms { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}