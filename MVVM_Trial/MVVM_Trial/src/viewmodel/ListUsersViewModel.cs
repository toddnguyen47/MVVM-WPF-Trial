using MVVM_Trial.src.model;
using MVVM_Trial.src.view;
using MVVM_Trial.src.viewmodel.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Trial.src.viewmodel
{
    public class ListUsersViewModel : ViewModelBase
    {
        public ListUsersViewModel()
        {
            this.LoadFromDb();
        }

        // ********************************************************************
        // | Variable Declarations |
        // ********************************************************************
        private List<PersonModel> _listOfPeople = new List<PersonModel>();


        // ********************************************************************
        // | Private Functions |
        // ********************************************************************
        private void LoadFromDb()
        {
            this.ListOfPeople = SqliteDataAccess.LoadPeople();
        }


        /// <summary>
        /// The Command to show the Add User View.
        /// </summary>
        private void FuncShowAddUser(object parameter)
        {
            AddUserView addUserView = new AddUserView();
            addUserView.Show();
        }


        // ********************************************************************
        // | Property Exposure |
        // ********************************************************************
        public List<PersonModel> ListOfPeople
        {
            get { return _listOfPeople; }
            set { this.SetProperty(ref _listOfPeople, value); }
        }


        public ICommand ShowAddUserView
        {
            get { return new BaseDelegateCommand(FuncShowAddUser, null); }
        }
    }
}
