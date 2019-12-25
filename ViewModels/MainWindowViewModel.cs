using System;
using System.Collections.Generic;
using System.Text;
using Todo.Services;
using ReactiveUI;
using Todo.Models;
using System.Reactive.Linq;

namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List { get; }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null)
            ).Take(1)
            .Subscribe(model =>
            {
                if (model != null)
                {
                    List.Items.Add(model);
                }

                Content = List;
            });

            Content = vm;
        }
    }
}
