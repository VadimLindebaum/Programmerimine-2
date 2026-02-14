using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using KooliProjekt.IntegrationTests.Helpers;
using Microsoft.Identity.Client;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    [Collection("Sequential")]
    public class TodoListsControllerTests : TestBase
    {
        [Fact]
        public async Task List_should_return_positive_result()
        {
            // Arrange
            var url = "/api/ToDoLists/List?page=1&pageSize=4";

            // Act
            var response = await Client.GetFromJsonAsync<OperationResult<PagedResult<ToDoList>>>(url);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Value);
            Assert.False(response.HasErrors);
        }

        [Fact]
        public async Task Get_should_return_existing_list()
        {
            // Arrange
            var url = "/api/ToDoLists/Get?id=1";

            var todoList = new ToDoList { Title = "Test list" };
            await DbContext.AddAsync(todoList);
            await DbContext.SaveChangesAsync();

            // Act
            var response = await Client.GetFromJsonAsync<OperationResult<ToDoListDetailsDto>>(url);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Value);
            Assert.False(response.HasErrors);
            Assert.Equal(1, response.Value.Id);
        }

        [Fact]
        public async Task Get_should_return_error_for_missing_list()
        {
            // Arrange
            var url = "/api/ToDoLists/Get?id=134";

            // Act
            var response = await Client.GetAsync(url);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }

}
