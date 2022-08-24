using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TodList.Model;

namespace TodList.ViewModel
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        public List<TodoList> todoLists;
        //public TodoList itemSelected;

        

        public async Task<bool> GetItems()
        {
            todoLists = await App.Database.GetNotesAsync();
            return true;
        }

        public async Task<bool> InsertItems(TodoList td)
        {
            await App.Database.InsertItems(td);
            return true;
        }

        public async Task<bool> UpdateItems(TodoList td)
        {
            await App.Database.UpdateItems(td);
            return true;
        }
        public async Task<bool> DeleteItems(TodoList td)
        {
            await App.Database.DeleteItems(td);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
