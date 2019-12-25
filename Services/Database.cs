using System.Collections.Generic;
using Todo.Models;

namespace Todo.Services
{
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "犬の散歩" },
            new TodoItem { Description = "牛乳を買う"},
            new TodoItem { Description = "アヴァロニアの学習", IsChecked = true },
        };
    }
}