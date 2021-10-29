using Xamarin.Forms;
namespace TaskList.Model
{
    class Tasks  : BindableObject
    {
        private string _task;
        private bool _Complete;


        public Tasks(string tasks)
        {
           Task  = tasks;
           Complete = false;  
        }   

        public string Task
        {
            get => _task;
            set
            {
                if (_task == value) return;
                _task = value;
                OnPropertyChanged();
            }
        }


        public bool Complete
        {
            get => _Complete;
            set
            {
                _Complete = value;
                OnPropertyChanged();
            }
        }
    }
}
