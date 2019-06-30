using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Trial.src.viewmodel
{
    /// <summary>
    /// The basis for all ViewModel classes.
    /// ViewModel is supposed to:
    ///     1. Expose the model's properties
    ///     2. NO REFERENCES TO THE VIEW -> View will bind to the ViewModel!
    ///     https://www.markwithall.com/programming/2013/03/01/worlds-simplest-csharp-wpf-mvvm-example.html
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set the new value of the field. `ref` means it is passed by reference.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Field to Change</param>
        /// <param name="newValue">Value to Change to</param>
        /// <param name="propertyName">OPTIONAL: Property Name</param>
        /// <returns><code>true</code> if changed properly, <code>false</code> otherwise</returns>
        protected bool SetProperty<T> (ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            // If the new value is different than the old value, then do work!
            if (false == (EqualityComparer<T>.Default.Equals(field, newValue)))
            {
                field = newValue;

                // Invoke a property change
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
