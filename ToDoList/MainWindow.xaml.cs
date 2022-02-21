using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ToDoList {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ToDoListOps tdl;

        public MainWindow() {
            InitializeComponent();
            tdl = new ToDoListOps();
            PopulateTasks("ToDoList");
        }

        private void PopulateTasks(string listName) {
            List<Task> tasks;
            if (listName == "ToDoList") {
                tasks = tdl.Tasks;
            } else {
                tasks = tdl.DoneTasks;
            }
            foreach (Task task in tasks) {
                toDoList.Items.Add(task.Description);
            }
        }

        private void ContextMenuDeleteClicked(object sender, RoutedEventArgs e) {
            tdl.DeleteTask(toDoList.SelectedItem.ToString());
            toDoList.Items.Remove(toDoList.SelectedItem);
        }

        private void ContextMenuDoneClicked(object sender, RoutedEventArgs e) {
            if (tdl.CurrentList == "ToDoList") {
                tdl.MoveToDoneList(toDoList.SelectedItem.ToString());
                toDoList.Items.Remove(toDoList.SelectedItem);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e) {
            if (addTaskTextBox.Text.Length > 0) {
                tdl.AddTask(addTaskTextBox.Text);
                toDoList.Items.Add(addTaskTextBox.Text);
                addTaskTextBox.Text = "";
            }
        }

        private void doneListButton_Click(object sender, RoutedEventArgs e) {
            addTaskTextBox.IsEnabled = false;
            addButton.IsEnabled = false;
            toDoList.Items.Clear();
            tdl.CurrentList = "DoneList";
            PopulateTasks(tdl.CurrentList);
        }

        private void toDoListButton_Click(object sender, RoutedEventArgs e) {
            addTaskTextBox.IsEnabled = true;
            addButton.IsEnabled = true;
            toDoList.Items.Clear();
            tdl.CurrentList = "ToDoList";
            PopulateTasks(tdl.CurrentList);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Color.FromRgb(0x00, 0xCB, 0xFF));
            btn.Foreground = new SolidColorBrush(Color.FromRgb(0x00, 0x28, 0x33));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.Black);
            btn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Window_Closed(object sender, EventArgs e) {
            tdl.SaveTasksToFile();
        }
    }
}
