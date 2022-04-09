using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    // dotnet ef migrations add NotesAdded --context DatabaseContext
    public class Note : DbItem
    {
        [MaxLength(200)]
        public string Text { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }



        public override void ClearNavigationProperties()
        {
            User = null;
        }
    }
}

