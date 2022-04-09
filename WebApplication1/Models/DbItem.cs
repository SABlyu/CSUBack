using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public abstract class DbItem : IDbItem
    {
        [Key]
        public int Id { get; set; }

        public abstract void ClearNavigationProperties();
    }
}

