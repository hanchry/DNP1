using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ToDoExercise.Models;


namespace ToDoExercise.Pages
{
    public partial class Todos:ComponentBase
    {
        private IList<Todo> todosToShow;
        private IList<Todo> allTodos;

        private bool? filterByIsCompleted;
        private int? filterById;

        protected override async Task OnInitializedAsync()
        {
            allTodos = TodosData.GetTodos();
            todosToShow = allTodos;
        }
        
        private void RemoveTodo(int todoId) {
            Todo todoToRemove = todosToShow.First(t => t.TodoId == todoId);
            TodosData.RemoveTodo(todoId);
            allTodos.Remove(todoToRemove);
            todosToShow.Remove(todoToRemove);
            
        }
        private void CompletedChange(ChangeEventArgs evt, Todo todo) {
            todo.IsCompleted=(bool)evt.Value;
            TodosData.Update(todo);
            
        }

        private void Edit(int id)
        {
            NavMgr.NavigateTo($"Edit/{id}");
        }

        private void FilterByUserId(ChangeEventArgs changeEventArgs) {
            filterById = null;
            
            try {
                filterById = int.Parse(changeEventArgs.Value.ToString());
                
            } catch (Exception e) { }
            ExecuteFilter();
        }

        private void FilterByCompletedStatus(ChangeEventArgs changeEventArgs)
        {
            filterByIsCompleted = null;
            try
            {
                filterByIsCompleted = bool.Parse(changeEventArgs.Value.ToString());
            }
            catch(Exception e)
            {
                
            }
            ExecuteFilter();
        }

        private void ExecuteFilter()
        {
            todosToShow = allTodos.Where(t =>
                    (filterById != null && t.UserId == filterById || filterById == null) &&
                    (filterByIsCompleted != null && t.IsCompleted == filterByIsCompleted ||
                     filterByIsCompleted == null))
                .ToList();
        }
        
    }
}