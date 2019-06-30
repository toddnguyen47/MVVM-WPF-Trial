using MVVM_Trial.src.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_Trial.src.view
{
    /// <summary>
    /// Interaction logic for TextConverterView.xaml
    /// </summary>
    public partial class TextConverterView : Window
    {
        public TextConverterView()
        {
            // Bind our View to the ViewModel
            ViewModelBase viewModel = new TextConvertViewModel();
            DataContext = viewModel;
            
            InitializeComponent();
        }
    }
}
