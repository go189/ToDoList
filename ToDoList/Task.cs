using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList {
    class Task {
        private string description;

        public string Description {
            get {
                return description;
            }

            set {
                description = value;
            }
        }
    }
}
