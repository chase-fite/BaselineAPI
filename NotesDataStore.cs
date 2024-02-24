using BaselineAPI.Models;

namespace BaselineAPI
{
    /// <summary>
    /// Temporary in memory data store.
    /// </summary>
    public class NotesDataStore
    {
        public List<NoteDto> Notes { get; set; }
        public static NotesDataStore Current { get; } = new NotesDataStore();

        public NotesDataStore() 
        {
            Notes = new List<NoteDto>()
            {
                new NoteDto()
                {
                    Id = 1,
                    Title = "Title",
                    Content = "Content"
                },
                new NoteDto()
                {
                    Id= 2,
                    Title = "Title",
                    Content = "Content"
                }
            };
        }
    }
}
