using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ToDoListDetailsDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public IList<ToDoItemDto> Items { get; set; } = new List<ToDoItemDto>();
    }
}
