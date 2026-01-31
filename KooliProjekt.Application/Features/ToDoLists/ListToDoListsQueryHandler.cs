using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ToDoLists
{
    public class ListToDoListsQueryHandler : IRequestHandler<ListToDoListsQuery, OperationResult<PagedResult<ToDoList>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListToDoListsQueryHandler(ApplicationDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ToDoList>>> Handle(ListToDoListsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var result = new OperationResult<PagedResult<ToDoList>>();

            if (request.Page <= 0 || request.PageSize <= 0)
            {
                return result;
            }

            result.Value = await _dbContext
                .ToDoLists
                .OrderBy(list => list.Title)
                .GetPagedAsync(request.Page, request.PageSize);

            return result;
        }
    }
}