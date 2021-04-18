using TodoApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoItem> _todos;

        public TodoService(ITodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todos = database.GetCollection<TodoItem>(settings.TodoCollectionName);
        }

        public List<TodoItem> Get() =>
            _todos.Find(todoItem => true).ToList();

        public TodoItem Get(string id) =>
            _todos.Find<TodoItem>(todoItem => todoItem.Id == id).FirstOrDefault();

        public TodoItem Create(TodoItem todoItem)
        {
            _todos.InsertOne(todoItem);
            return todoItem;
        }

        public void Update(string id, TodoItem itemIn) =>
            _todos.ReplaceOne(todoItem => todoItem.Id == id, itemIn);

        public void Remove(TodoItem itemIn) =>
            _todos.DeleteOne(todoItem => todoItem.Id == itemIn.Id);

        public void Remove(string id) =>
            _todos.DeleteOne(todoItem => todoItem.Id == id);
    }
}