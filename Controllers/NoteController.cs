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
        public JsonResult GetNotes()
        {
            return new JsonResult(NotesDataStore.Current.Notes);
        }

        [HttpGet("{id}")]
        public JsonResult GetNote(int id)
        {
            return new JsonResult(NotesDataStore.Current.Notes.FirstOrDefault(note => note.Id == id));
        }
    }
}
