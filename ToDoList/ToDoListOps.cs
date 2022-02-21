using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList {
    class ToDoListOps {
        private List<Task> tasks;
        private List<Task> doneTasks;
        private string currentList;

        public ToDoListOps() {
            tasks = TaskPersister.GetTasksFromFile();
            doneTasks = TaskPersister.GetDoneTasksFromFile();
            currentList = "ToDoList";
        }

        public List<Task> Tasks {
            get {
                return tasks;
            }
            private set { 
                tasks = value;
            }
        }

        public List<Task> DoneTasks {
            get {
                return doneTasks;
            }
            private set { 
                doneTasks = value;
            }
        }

        public string CurrentList {
            get {
                return currentList;
            }
            set {
                currentList = value;
            }
        }

        public void AddTask(string task) {
            Tasks.Add(new Task() { Description = task });
        }

        public void MoveToDoneList(string description) {
            for (int i = 0; i < tasks.Count; i++) {
                if (tasks[i].Description == description) {
                    doneTasks.Add(tasks[i]);
                    tasks.Remove(tasks[i]);
                }  
            }
        }

        public void DeleteTask(string description) {
            if (currentList == "ToDoList") {
                for (int i = 0; i < tasks.Count; i++) {
                    if (tasks[i].Description == description) {
                        tasks.Remove(tasks[i]);
                    }
                }
            } else {
                for (int i = 0; i < tasks.Count; i++) {
                    if (doneTasks[i].Description == description) {
                        tasks.Remove(doneTasks[i]);
                    }
                }
            }
        }

        public void SaveTasksToFile() {
            TaskPersister.SaveTasksToFile(Tasks, DoneTasks);
        }
    }
}
