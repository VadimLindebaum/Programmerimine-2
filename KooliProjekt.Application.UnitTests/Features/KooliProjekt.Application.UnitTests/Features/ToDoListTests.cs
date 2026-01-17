using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.ToDoLists;
using Xunit;

namespace KooliProjekt.Application.UnitTests.Features
{
    public class ToDoListTests : TestBase
    {
        [Fact]
        public void Get_should_throw_when_dbcontext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GetToDoListQueryHandler(null);
            });
        }

        [Fact]
        public async Task Get_should_return_existing_todo_list()
        {
            // Arrange
            var query = new GetToDoListQuery { Id = 1 };
            var handler = new GetToDoListQueryHandler(DbContext);

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.NotNull(result.Value);
            Assert.Equal(query.Id, result.Value.Id);
        }

        [Theory]
        [InlineData(101)]
        [InlineData(0)]
        [InlineData(-5)]
        public async Task Get_should_return_null_when_todo_list_does_not_exist(int id)
        {
            // Arrange
            var query = new GetToDoListQuery { Id = id };
            var handler = new GetToDoListQueryHandler(DbContext);

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.Null(result.Value);
        }

        [Fact]
        public async Task Get_should_survive_null_request()
        {
            // Arrange
            var query = (GetToDoListQuery)null;
            var handler = new GetToDoListQueryHandler(DbContext);

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.Null(result.Value);
        }
    }
}
