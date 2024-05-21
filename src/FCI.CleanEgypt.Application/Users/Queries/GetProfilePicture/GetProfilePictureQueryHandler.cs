using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Application.Users.Queries.GetProfilePicture;

public sealed class GetProfilePictureQueryHandler
    : IQueryHandler<GetProfilePictureQuery, GetProfilePictureResponse>
{
    private readonly UserManager<User> _userManager;

    public GetProfilePictureQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<GetProfilePictureResponse>> Handle(GetProfilePictureQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (checkUserIsExists is null)
        {
            return Result.Fail<GetProfilePictureResponse>("User not found");
        }

        var imageToRetrieve = checkUserIsExists.ProfilePicture;
        if (imageToRetrieve is null)
        {
            return Result.Fail<GetProfilePictureResponse>("User has no profile picture");
        }

        return Result.Ok(new GetProfilePictureResponse(imageToRetrieve.FileName,
                                                       imageToRetrieve.ContentType,
                                                       imageToRetrieve.Data));
    }
}