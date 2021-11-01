
using System.Collections.Generic;
using ToDoExercise.Models;

namespace ToDoExercise.Data
{
    public interface ITodosData
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void Update(Todo todo);
        Todo Get(int id);
    }
}