using MVVM_Trial.src.model;
using MVVM_Trial.src.viewmodel.commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM_Trial.src.viewmodel
{
    public class TextConvertViewModel : ViewModelBase
    {
        // ********************************************************************
        // | Variable Declarations |
        // ********************************************************************

        // A reference to our model but NOT our view
        // Our model expects a function to do some operation to our string,
        // so we will pass the toUpper() function
        private readonly TextConverterModel _textConverterModel = new TextConverterModel(s => s.ToUpper());

        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();


        // ********************************************************************
        // | Private Functions |
        // ********************************************************************
        private void AddToHistory(string item)
        {
            if (false == _history.Contains(item))
                _history.Add(item);
        }


        private void ConvertText(object parameter)
        {
            // Check if string is null or empty
            if (String.IsNullOrEmpty(SomeText)) return;

            AddToHistory(_textConverterModel.convertText(SomeText));
            SomeText = String.Empty;
        }


        // ********************************************************************
        // | Property Exposure |
        // ********************************************************************

        /// <summary>
        /// Expose the SomeText property.
        /// </summary>
        public string SomeText
        {
            get { return _someText; }
            // We do not have to raise an event as the ViewModelBase class will raise the event for us
            set { SetProperty(ref _someText, value); }
        }


        /// <summary>
        /// Expose the History property.
        /// </summary>
        public IEnumerable<string> History
        {
            get { return _history; }
        }


        /// <summary>
        /// Expose the Command to be bound to key presses or buttons.
        /// </summary>
        public ICommand ConvertTextCommand
        {
            // ConvertText is a function
            get { return new BaseDelegateCommand(ConvertText, null); }
        }
    }
}
