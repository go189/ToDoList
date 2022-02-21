using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoList {
    static class TaskPersister {

        public static List<Task> GetTasksFromFile() {
            List<Task> tasks = new List<Task>();
            try { 
                using (StreamReader sr = new StreamReader(@"C:\Users\benja\OneDrive\Documents\Programming\Projects\C#\ToDoList\ToDoList\tasks.txt")) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        tasks.Add(new Task() { Description = line});
                    }
                }
                
            } catch (Exception ex) {
                return tasks;
            }
            return tasks;
        }

        public static List<Task> GetDoneTasksFromFile() {
            List<Task> doneTasks = new List<Task>();
            try {     
                using (StreamReader sr = new StreamReader(@"C:\Users\benja\OneDrive\Documents\Programming\Projects\C#\ToDoList\ToDoList\doneTasks.txt")) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        doneTasks.Add(new Task() { Description = line });
                    }
                }
            } catch (Exception ex) {
                return doneTasks;
            }
            return doneTasks;
        }

        public static void SaveTasksToFile(List<Task> tasks, List<Task> doneTasks) {  
            using (StreamWriter sw = new StreamWriter(@"C:\Users\benja\OneDrive\Documents\Programming\Projects\C#\ToDoList\ToDoList\tasks.txt")) {
                foreach (Task task in tasks) { 
                    sw.WriteLine(task.Description);
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\benja\OneDrive\Documents\Programming\Projects\C#\ToDoList\ToDoList\doneTasks.txt")) {
                foreach (Task task in doneTasks) {
                    sw.WriteLine(task.Description);
                }
            } 
        }
    }
}