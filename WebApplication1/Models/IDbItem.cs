using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public interface IDbItem
    {
        [Key]
        int Id { get; set; }


        void ClearNavigationProperties();
    }
}

