using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodList.Model
{
    [Table("items")]
    public class TodoList : INotifyPropertyChanged
    {


        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        //[Column("isDone")]
        //public bool isDone { get; set; }

        //public string textDec
        //{
        //    get
        //    {
        //        if (isDone)
        //        {
        //            return "Strikethrough";
        //        }
        //        else
        //        {
        //            return "None";
        //        }
        //    }
        //}


        /* COnstructor pass ID and List */
        public TodoList(int id, string list)
        {
            this.Id = id;
            this.Notes = list;
            
        }

        /* Empty Contstuctor */
        public TodoList()
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
