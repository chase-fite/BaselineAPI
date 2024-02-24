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
            return new JsonResult(new { id = 1, title = "title", content = "content" });
        }
    }
}
