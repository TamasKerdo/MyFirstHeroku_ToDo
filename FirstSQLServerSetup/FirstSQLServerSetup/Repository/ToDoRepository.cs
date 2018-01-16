using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstSQLServerSetup.Entities;
using FirstSQLServerSetup.Models;

namespace FirstSQLServerSetup.Repository
{
    public class ToDoRepository
    {
        public ToDoContext Todocontext { get; set; }
        public long IdToUpdate { get; set; }

        public ToDoRepository(ToDoContext todocontext)
        {
            Todocontext = todocontext;
        }

        public List<ToDo> GetAll()
        {            
            return Todocontext.ToDos.ToList();
        }

        public List<ToDo> GetActive(bool isActive)
        {
            if (isActive)
            {
                return Todocontext.ToDos.Where(x => x.IsDone == false).ToList();
            }
            return Todocontext.ToDos.Where(x => x.IsDone == true).ToList();
        }

        public List<ToDo> GetFullList()
        {
            return Todocontext.ToDos.ToList();
        }

        public void DeleteToDo(long idToDelete)
        {
            ToDo ToDoToRemove = Todocontext.ToDos.FirstOrDefault(x => x.Id == idToDelete);
            Todocontext.ToDos.Remove(ToDoToRemove);
            Todocontext.SaveChanges();
        }

        public void UpdateToDo(ToDo todoToUpdate)
        {
            todoToUpdate.Id = IdToUpdate;
            Todocontext.ToDos.Update(todoToUpdate);
            Todocontext.SaveChanges();
        }

        public ToDo GetToDo(long todoId)
        {
            return Todocontext.ToDos.FirstOrDefault(x => x.Id == todoId);
        }
    }
}
