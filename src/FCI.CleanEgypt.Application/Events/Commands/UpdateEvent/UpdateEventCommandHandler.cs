using FCI.CleanEgypt.Application.Core.Errors;
using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Commands;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Entities.Events;

namespace FCI.CleanEgypt.Application.Events.Commands.UpdateEvent;

public sealed class UpdateEventCommandHandler
    : ICommandHandler<UpdateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var checkEventIsExists = await _eventRepository.FindByIdAsync(request.EventId, cancellationToken);
        if (checkEventIsExists is null)
            return Result.Fail(ValidationErrors.UpdateEvent.EventIsNotExists);

        var eventToUpdate = Event.Update(checkEventIsExists, request.Name, request.Date, request.Details);

        _eventRepository.Update(eventToUpdate);
        return await _unitOfWork.SaveChangesAsync() == 0
            ? Result.Fail(DatabaseErrors.UpdateEvent.EventIsNotExists)
            : Result.Ok("Event updated successfully.");
    }
}