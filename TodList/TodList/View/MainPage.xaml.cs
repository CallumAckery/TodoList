using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodList.Model;
using TodList.ViewModel;
using Xamarin.Forms;

namespace TodList
{
    public partial class MainPage : ContentPage
    {
        public TodoViewModel todoView;

        public MainPage()
        {
            InitializeComponent();
           
            todoView = new TodoViewModel();
            BindingContext = todoView;
            frameAddNote.IsVisible = true;
            addNote.IsVisible = true;
            addNote.Completed += addNote_Completed;

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshItemsView();
        }
       

        public async Task<bool> RefreshItemsView()
        {
            try
            {
                todoListViews.ItemsSource = null;
                var tmp = await App.Database.GetNotesAsync();
                todoListViews.ItemsSource = tmp.OrderBy(u => u.Id);
                
                return true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            return false;
        }


        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            /* Delete Swiped Item */
            var tmp = (SwipeItem)sender;
            TodoList td = (TodoList)tmp.CommandParameter;            
            await todoView.DeleteItems(td);
            /* then refresh page */
            await RefreshItemsView();
            
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            frameAddNote.IsVisible = true;
            addNote.IsVisible = true;
        }



        private void addNote_Completed(object sender, EventArgs e)
        {
            string tmp = addNote.Text;
            AddToDb(tmp);
        }

        private async void AddToDb(string note)
        {
            var t = new TodoList()
            { 
                Notes = note,
            };

            await todoView.InsertItems(t);
            addNote.Text = " ";
            
            await RefreshItemsView();
        }

        /* Swipe all left then change text to Text Decoration to line */

        //private async void SwipeItemLeft_Invoked(object sender, EventArgs e)
        //{
        //    var itemId = (SwipeItem)sender;
        //    var td = (TodoList)itemId.CommandParameter;            
            
        //    await todoView.UpdateItems(td);
        //    await RefreshItemsView();
        //}






    }
}

//#F30DCD << pink