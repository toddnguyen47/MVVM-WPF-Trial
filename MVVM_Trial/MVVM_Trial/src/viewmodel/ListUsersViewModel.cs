using MVVM_Trial.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        // ********************************************************************
        // | Property Exposure |
        // ********************************************************************
        public List<PersonModel> ListOfPeople
        {
            get { return _listOfPeople; }
            set { this.SetProperty(ref _listOfPeople, value); }
        }
    }
}
