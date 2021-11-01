using Microsoft.AspNetCore.Components;
using ToDoExercise.Models;

namespace ToDoExercise.Pages
{
    public partial class AddTodo:ComponentBase
    {
        private Todo newTodoItem = new Todo();
        private void AddNewTodo()
        {
            TodoData.AddTodo(newTodoItem);
            NavigationManager.NavigateTo("/Todos");
            
        }
        
    }
}