using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ToDoExercise.Models;

namespace ToDoExercise.Pages
{
    public partial class Edit: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        
        private Todo todoToEdit;
        protected override async Task OnInitializedAsync()
        {
            todoToEdit = TodoData.Get(Id);
            
        }
        private void Save()
        {
            TodoData.Update(todoToEdit);
            NavMgr.NavigateTo("/Todo");
            
        }
        
    }
}