using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Domain.Entities.Events;

namespace FCI.CleanEgypt.Application.Core.Errors;

internal static class DatabaseErrors
{
    internal static class Users
    {
        internal static Error UserIsNotExist(Guid userId) => new($"User with {userId} is not exists.");
        internal static Error FailedToUpdateProfilePicture => new("Failed to update profile picture.");
    }

    internal static class CreateEvent
    {
        internal static Error FailedToCreateEvent => new("Failed to create event.");
    }

    internal static class UpdateEvent
    {
        internal static Error EventIsNotExists => new("Event is not exists.");
    }
}