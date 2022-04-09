using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NoteController(NoteService noteService)
        {
            _noteService = noteService;
        }


        [HttpGet("all")]
        public Task<List<Note>> GetNotes() => _noteService.GetNotes();

        [HttpGet("{id}")]
        public Task<Note> GetNote(int id) => _noteService.FindItem(id);

        [HttpPost]
        public Task<Note> AddNote([FromBody] Note note) => _noteService.AddItem(note);

        [HttpPut]
        public Task<Note> UpdateNote([FromBody] Note note) => _noteService.UpdateItem(note);

    }
}

