using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace DiaryWPF
{
    public partial class NoteWindow : Window
    {
        
        public NoteWindow()
        {
            InitializeComponent();
        }

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
