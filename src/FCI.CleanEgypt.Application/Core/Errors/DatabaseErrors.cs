using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Domain.Common;

namespace FCI.CleanEgypt.Application.Core.Errors;

internal static class DatabaseErrors
{
    internal static class Users
    {
        internal static Error UserIsNotExist(Guid userId) => new($"User with {userId} is not exists.");

        internal static Error FailedToUpdateProfilePicture => new("Failed to update profile picture.");
    }

    internal static class DbTransaction
    {
        internal static Error FailedToSaveChanges<T>(T entity) where T : BaseEntity
            => new($"Failed to save {typeof(T).Name}");
    }

    internal static class CreateEvent
    {
        internal static Error FailedToCreateEvent => new("Failed to create event.");
    }

    internal static class UpdateEvent
    {
        internal static Error EventIsNotExists => new("Event is not exists.");
    }

    internal static class Pins
    {
        internal static Error PinNotFound(Guid Id) =>
            new($"Pin with {Id} is not found.");

        internal static Error FailedToUpdatePin(Guid Id) =>
            new($"Failed to update pin with {Id}.");
    }
}