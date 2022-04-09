using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class NoteService : DbService<Note>
    {
        protected override DbSet<Note> DbSet => _db.Notes;

        public NoteService(DatabaseContext db) : base(db) { }


        public Task<List<Note>> GetNotes()
        {
            return _db.Notes.ToListAsync();
        }


        public async Task<Note> AddNote(Note note)
        {
            // CLEAR NAVIGATION PROPERTIES!!! (AKA User property)
            // if you don't do that, EF will
            // try to inject another instance
            // of Nav Props to DB

            // user exists in DB -> clear nav prop
            if (note.User != null && note.User.Id != 0)
            {
                note.UserId = note.User.Id;
                note.User = null;
            }
            // else EF will insert new User in DB
            // and update Foreign Key of Note entry

            // inject data
            await _db.AddAsync(note);
            await _db.SaveChangesAsync();

            return await FindItem(note.Id);
        }

        protected override IQueryable<Note> IncludeProperties(IQueryable<Note> query)
        {
            throw new NotImplementedException();
        }
    }
}

