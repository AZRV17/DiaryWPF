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
            MainWindow mainWindow = new MainWindow();
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            string notesText = noteTextBox.Text;
            mainWindow.notes.Add(selectedDate, notesText);
            mainWindow.notesTextBox.Text = mainWindow.notes[selectedDate];
            SaveNotes(mainWindow.notes);
            mainWindow.LoadNotes();
            Close();
        }

        private void SaveNotes(Dictionary<DateTime, string> notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C:/Users/alexa/OneDrive/Рабочий стол/Практическая/notes.json", json);
        }
    }
}
