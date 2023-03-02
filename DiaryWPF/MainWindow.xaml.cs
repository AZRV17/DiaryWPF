using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;

namespace DiaryWPF
{
    public partial class MainWindow : Window
    {
        List<Note> notes_1 = new List<Note>();


        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Save(DateTime date, string title, string desc)
        {
            if (title != "")
            {
                Note note = new Note
                {
                    date = date,
                    title = title,
                    description = desc
                };
                notes_1.Add(note);
            }
            string json = JsonConvert.SerializeObject(notes_1);
            File.WriteAllText("C:/Users/alexa/OneDrive/Рабочий стол/Практическая/notes_1.json", json);
        }

        public void Load()
        {
            try
            {
                var json = File.ReadAllText("C:/Users/alexa/OneDrive/Рабочий стол/Практическая/notes_1.json");
                notes_1.Clear();
                notes_1 = JsonConvert.DeserializeObject<List<Note>>(json);
            }
            catch (Exception)
            {
                notes_1 = new List<Note>();
            }
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            notesList.Items.Clear();

            foreach (var n in notes_1)
            {
                if (Convert.ToDateTime(calendar.SelectedDate).DayOfYear == n.date.DayOfYear)
                {
                    notesList.Items.Add(n.title);
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();

            foreach (Note note in notes_1)
            {
                try
                {
                    if (notesList.SelectedItem.ToString() == note.title)
                    {
                        notesList.Items.Remove(note);
                        notes_1.Remove(note);
                        Save(selectedDate, "", "");
                        notesList.Items.Clear();
                        break;
                    }
                }
                catch
                {
                    notesList.Items.Clear();
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            NoteWindow noteWindow = new NoteWindow();
            if (noteWindow.ShowDialog() == true)
            {
                Save(selectedDate, noteWindow.HeaderNote.Text, noteWindow.descriptionTextBox.Text);
            }
        }

        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.GetValueOrDefault();
            NoteWindow noteWindow = new NoteWindow();
            Note new_note = new Note();
            Note old_note = new Note();
            bool isTrue = false;
            foreach (Note note in notes_1) 
            {
                try
                {
                    if (notesList.SelectedItem.ToString() == note.title)
                    {
                        noteWindow.descriptionTextBox.Text = note.description;
                        noteWindow.HeaderNote.Text = note.title;

                        if (noteWindow.ShowDialog() == true)
                        {
                            isTrue = true;
                            old_note = note;

                            new_note.title = noteWindow.HeaderNote.Text;
                            new_note.description = noteWindow.descriptionTextBox.Text;
                            new_note.date = selectedDate;
                            notesList.Items.Clear();
                        }
                        break;
                    }
                }
                catch 
                {
                    notesList.Items.Clear();
                    break;
                }
            }

            if (isTrue)
            {
                notes_1.Remove(old_note);
                Save(new_note.date, new_note.title, new_note.description);
                Load();

                notesList.Items.Add(new_note.title);
            }
        }
    }
}
