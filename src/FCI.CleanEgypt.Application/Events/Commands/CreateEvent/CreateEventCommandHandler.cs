using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Entities.Events;

namespace FCI.CleanEgypt.Application.Events.Commands.CreateEvent;

public sealed class CreateEventCommandHandler
    : ICommandHandler<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var checkEventIsExists = await _eventRepository.FindEventByNameAsync(request.Name, cancellationToken);

        if (checkEventIsExists is not null)
            return Result.Fail("Event is Already Exists");

        var eventToAdd = Event.Create(
            request.Name,
            request.Date,
            request.Details);

        _eventRepository.Add(eventToAdd);
        return await _unitOfWork.SaveChangesAsync() == 0
            ? Result.Fail("Failed To Save")
            : Result.Ok("Added Successfully");
    }
}