using EventHub.Application.DTO;
using EventHub.Application.Queries.Events;
using EventHub.Application.Security;
using EventHub.Core.ValueObjects.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.DAL.Handlers.Events;

internal sealed class GetUserEventsQueryHandler : IRequestHandler<GetUserEventsQuery, IEnumerable<EventDto>>
{
    private readonly EventHubDbContext _dbContext;
    private readonly IUser _user;

    public GetUserEventsQueryHandler(EventHubDbContext dbContext, IUser user)
    {
        _dbContext = dbContext;
        _user = user;
    }

    public async Task<IEnumerable<EventDto>> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
    {
        var userId = _user.GetCurrentUserId();

        if (userId is null)
            throw new NotImplementedException();
        
        var events = await _dbContext.Events
            .Where(e => e.HostId == new UserId(userId.Value))
            .Select(e => new EventDto
            {
                Title = e.Title,
                Description = e.Description,
                EventDate = e.EventDate,
                Location = e.Location,
                NumberOfPeople = e.Registrations.Count()
            }).ToListAsync(cancellationToken);

        return events;
    }
}