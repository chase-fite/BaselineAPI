using BaselineAPI.Models;
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
        /// Gets all note records. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<NoteDto>> GetNotes()
        {
            return Ok(NotesDataStore.Current.Notes);
        }

        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetNote(int id)
        {
            var note = NotesDataStore.Current.Notes.FirstOrDefault(note => note.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }
    }
}
