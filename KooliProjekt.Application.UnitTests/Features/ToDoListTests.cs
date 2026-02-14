using FluentValidation.Results;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features.ToDoLists;
using Microsoft.EntityFrameworkCore;
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
        public async Task Get_should_throw_when_request_is_null()
        {
            // Arrange
            var request = (GetToDoListQuery)null;
            var handler = new GetToDoListQueryHandler(DbContext);

            // Act && Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(request, CancellationToken.None);
            });
            Assert.Equal("request", ex.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Get_should_return_null_when_request_id_is_null_or_negative(int id)
        {
            // Arrange
            var query = new GetToDoListQuery { Id = id };
            var handler = new GetToDoListQueryHandler(GetFaultyDbContext());

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
        public void List_should_throw_when_dbcontext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ListToDoListsQueryHandler(null);
            });
        }

        [Fact]
        public async Task List_should_throw_when_request_is_null()
        {
            // Arrange
            var request = (ListToDoListsQuery)null;
            var handler = new ListToDoListsQueryHandler(DbContext);

            // Act && Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(request, CancellationToken.None);
            });
            Assert.Equal("request", ex.ParamName);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(-1, 5)]
        [InlineData(4, -10)]
        [InlineData(5, -5)]
        [InlineData(0, 0)]
        [InlineData(-5, -10)]
        public async Task List_should_return_null_when_page_or_page_size_is_zero_or_negative(int page, int pageSize)
        {
            // Arrange
            var query = new ListToDoListsQuery { Page = page, PageSize = pageSize };
            var handler = new ListToDoListsQueryHandler(GetFaultyDbContext());

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.Null(result.Value);
        }

        [Fact]
        public async Task List_should_return_page_of_todo_lists()
        {
            // Arrange
            var query = new ListToDoListsQuery { Page = 1, PageSize = 5 };
            var handler = new ListToDoListsQueryHandler(DbContext);

            foreach(var i in Enumerable.Range(1, 15))
            {
                var todoList = new ToDoList { Title = $"Test list {i}" };
                await DbContext.ToDoLists.AddAsync(todoList);
            }

            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.NotNull(result.Value);
            Assert.Equal(query.Page, result.Value.CurrentPage);
            Assert.Equal(query.PageSize, result.Value.Results.Count);
        }

        [Fact]
        public async Task List_should_return_empty_result_if_todo_lists_doesnt_exist()
        {
            // Arrange
            var query = new ListToDoListsQuery { Page = 1, PageSize = 5 };
            var handler = new ListToDoListsQueryHandler(DbContext);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Value.Results);
        }

        [Fact]
        public void Delete_should_throw_when_dbcontext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new DeleteToDoListCommandHandler(null);
            });
        }

        [Fact]
        public async Task Delete_should_throw_when_request_is_null()
        {
            // Arrange
            var request = (DeleteToDoListCommand)null;
            var handler = new DeleteToDoListCommandHandler(DbContext);

            // Act && Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(request, CancellationToken.None);
            });
            Assert.Equal("request", ex.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public async Task Delete_should_not_use_dbcontext_if_id_is_zero_or_less(int id)
        {
            // Arrange
            var query = new DeleteToDoListCommand { Id = id };
            var handler = new DeleteToDoListCommandHandler(GetFaultyDbContext());

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
        }

        [Fact]
        public async Task Delete_should_delete_existing_todo_list()
        {
            // Arrange
            var query = new DeleteToDoListCommand { Id = 1 };
            var handler = new DeleteToDoListCommandHandler(DbContext);

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            var count = DbContext.ToDoLists.Count();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Delete_should_work_with_not_existing_list()
        {
            // Arrange
            var query = new DeleteToDoListCommand { Id = 1034 };
            var handler = new DeleteToDoListCommandHandler(DbContext);

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
        }

        [Fact]
        public void Save_should_throw_when_dbcontext_is_null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SaveToDoListCommandHandler(null);
            });
        }

        [Fact]
        public async Task Save_should_throw_when_request_is_null()
        {
            // Arrange
            var request = (SaveToDoListCommand)null;
            var handler = new SaveToDoListCommandHandler(DbContext);

            // Act && Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(request, CancellationToken.None);
            });
            Assert.Equal("request", ex.ParamName);
        }

        [Fact]
        public async Task Save_should_not_use_dbcontext_if_id_is_negative()
        {
            // Arrange
            var query = new SaveToDoListCommand { Id = -1 };
            var handler = new SaveToDoListCommandHandler(GetFaultyDbContext());

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasErrors);
        }

        [Fact]
        public async Task Save_should_add_new_todo_list()
        {
            // Arrange
            var query = new SaveToDoListCommand { Id = 0, Title = "Test list" };
            var handler = new SaveToDoListCommandHandler(DbContext);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            var savedList = await DbContext.ToDoLists.FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.NotNull(savedList);
            Assert.Equal(query.Title, savedList.Title);
        }

        [Fact]
        public async Task Save_should_update_existing_todo_list()
        {
            // Arrange
            var query = new SaveToDoListCommand { Id = 1, Title = "Test list" };
            var handler = new SaveToDoListCommandHandler(DbContext);
            var todoList = new ToDoList { Title = "Old title" };

            await DbContext.ToDoLists.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            var savedList = await DbContext.ToDoLists.FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.HasErrors);
            Assert.NotNull(savedList);
            Assert.Equal(query.Title, savedList.Title);
        }

        [Fact]
        public async Task Save_should_survive_not_existing_list()
        {
            // Arrange
            var query = new SaveToDoListCommand { Id = 10, Title = "Test list" };
            var handler = new SaveToDoListCommandHandler(DbContext);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            var savedList = await DbContext.ToDoLists.FirstOrDefaultAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.HasErrors);
            Assert.Null(savedList);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("01234567890123456789012345678901234567890123456789000")]
        public async Task SaveValidator_should_fail_when_title_is_invalid(string title)
        {
            // Arrange
            var command = new SaveToDoListCommand { Title = title };
            var validator = new SaveToDoListCommandValidator(DbContext);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);

            var error = result.Errors.First();
            Assert.Equal(nameof(SaveToDoListCommand.Title), error.PropertyName);
        }

        [Fact]
        public async Task SaveValidator_should_succeed_when_title_is_valid()
        {
            // Arrange
            var command = new SaveToDoListCommand { Title = "Test list" };
            var validator = new SaveToDoListCommandValidator(DbContext);

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }
    }
}