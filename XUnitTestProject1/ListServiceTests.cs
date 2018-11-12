using Moq;
using System;
using System.Collections.Generic;
using TodoList.Models;
using TodoList.Repositories;
using TodoList.Services;
using Xunit;

namespace XUnitTodoListTests
{
    public class ListServiceTests
    {
        [Fact]
        public void SortTodosTest()
        {
            var a = new TodoListModel { Name = "Clean Livingroom", Id = Guid.NewGuid() };
            var b = new TodoListModel { Name = "Clean Kitchen", Id = Guid.NewGuid() };
            var c = new TodoListModel { Name = "Make Lemonade", Id = Guid.NewGuid() };
            var d = new TodoListModel { Name = "Call Internet Provider", Id = Guid.NewGuid() };
            var e = new TodoListModel { Name = "Clean Bedroom", Id = Guid.NewGuid() };
            var f = new TodoListModel { Name = "Paint room", Id = Guid.NewGuid() };
            var g = new TodoListModel { Name = "Make Paint", Id = Guid.NewGuid() };
            var h = new TodoListModel { Name = "Provide Food for Party", Id = Guid.NewGuid() };
            // TODO make a fake list and assert the item is in it.
            List<TodoListModel> list = new List<TodoListModel>{ a,b,c,d,e,f,g,h};
            string sortString = "oo";
            var listServiceMock = new ListService(new Mock<ITodoListRepository>().Object);
            var result =  listServiceMock.SearchTodos(list, sortString);

            Assert.True(result.Count == 4);
        }

    }
}
