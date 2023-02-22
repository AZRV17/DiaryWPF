using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace DiaryWPF
{
    public partial class MainWindow : Window
    {
        public Dictionary<DateTime, string> notes;

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
        }

        public void LoadNotes()
        {
            try
            {
                string json = File.ReadAllText("C:/Users/alexa/OneDrive/Рабочий стол/Практическая/notes.json");
                notes = JsonConvert.DeserializeObject<Dictionary<DateTime, string>>(json);
            }
            catch (Exception)
            {
                notes = new Dictionary<DateTime, string>();
            }
        }

        public void SaveNotes()
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C:/Users/alexa/OneDrive/Рабочий стол/Практическая/notes.json", json);
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            if (notes.ContainsKey(selectedDate))
            {
                notesTextBox.Text = notes[selectedDate];
            }
            else
            {
                notesTextBox.Text = "";
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            string notesText = notesTextBox.Text;
            if (notes.ContainsKey(selectedDate))
            {
                notes[selectedDate] = notesText;
            }
            else
            {
                notes.Add(selectedDate, notesText);
            }
            SaveNotes();
            MessageBox.Show("Notes saved successfully.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            if (notes.ContainsKey(selectedDate))
            {
                notes.Remove(selectedDate);
                SaveNotes();
                MessageBox.Show("Notes deleted successfully.");
                notesTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("No notes to delete.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow noteWindow = new NoteWindow();
            noteWindow.Show();
            notesTextBox.Text = noteWindow.noteTextBox.Text;
            LoadNotes();
        }
    }
}
