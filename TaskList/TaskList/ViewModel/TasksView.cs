using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using TaskList.Model;

using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace TaskList.ViewModel
{
    class TasksView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Tasks> Task { get;  }

        public TasksView()
        {

            Task = new ObservableCollection<Tasks>();
            CreateCommand = new Command(Create);
            DeleteCommand = new Command(Delete);
        }

        public ICommand CreateCommand {  get; }
        public ICommand DeleteCommand {  get; }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Create(object task)
        {
            Task.Add(new Tasks(task.ToString()));
            OnPropertyChanged();
        }

        private async void Delete(object taskObject)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Are you sure?", string.Format("Would you like to remove the  project"), "Yes", "No");
            if (answer)
                if (taskObject is Tasks task)
                {
                    Task.Remove(task);
                }
            OnPropertyChanged();
        }





    }
}
