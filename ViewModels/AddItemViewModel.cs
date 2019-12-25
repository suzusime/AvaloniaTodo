using System.Reactive;
using ReactiveUI;
using Todo.Models;

namespace Todo.ViewModels
{
    class AddItemViewModel : ViewModelBase
    {
        string description;

        public AddItemViewModel()
        {
            // bool値を返す函数みたいなもの
            // thisが変更されると呼び出され、
            // まず第一引数でx(=this)のDescriptionを取得
            // 第二引数がそのx(=this.Description)をもとにboolを返す
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x)
            );

            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                okEnabled
            );
            Cancel = ReactiveCommand.Create(() => { });
        }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}