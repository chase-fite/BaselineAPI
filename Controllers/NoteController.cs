﻿using BaselineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaselineAPI.Controllers
{
    /// <summary>
    /// The note controller class.
    /// </summary>
    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// Gets all notes. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<NoteDto>> GetNotes()
        {
            return Ok(NotesDataStore.Current.Notes);
        }
        
        /// <summary>
        /// Gets the note with the specified identifier.
        /// </summary>
        /// <param name="id">The note identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNote")]
        public ActionResult<NoteDto> GetNote(int id)
        {
            var note = NotesDataStore.Current.Notes.FirstOrDefault(note => note.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public ActionResult<NoteDto> CreateNote(NoteForCreationDto noteForCreation)
        {
            // Temporarily calculate the note id to be used on creation for in memory data store
            var maxNoteId = NotesDataStore.Current.Notes.Max(note => note.Id);

            var newNote = new NoteDto()
            {
                Id = ++maxNoteId,
                Title = noteForCreation.Title,
                Content = noteForCreation.Content
            };

            NotesDataStore.Current.Notes.Add(newNote);

            return CreatedAtRoute("GetNote", new { Id = newNote.Id }, newNote);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, NoteForUpdateDto note)
        {
            var noteToUpdate = NotesDataStore.Current.Notes.FirstOrDefault(noteToUpdate =>
            {
                return noteToUpdate.Id == id;
            });
            if (noteToUpdate == null) return NotFound();

            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;

            return NoContent();
        }
    }
}
