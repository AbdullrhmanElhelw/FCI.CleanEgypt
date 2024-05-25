using FCI.CleanEgypt.Contracts.ApiResponse.Results;
using FCI.CleanEgypt.Contracts.CQRS.Queries;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Application.Users.Queries.GetUser;

public sealed class GetUserQueryHandler
    : IQueryHandler<GetUserQuery, GetUserDto>
{
    private readonly UserManager<User> _userManager;

    public GetUserQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var checkUserIsExist = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (checkUserIsExist is null)
            return Result.Fail<GetUserDto>("User not found");

        return Result.Ok(new GetUserDto(checkUserIsExist.FirstName,
            checkUserIsExist.LastName,
            checkUserIsExist.Email,
            checkUserIsExist.DateOfBirth.Year,
            checkUserIsExist.DateOfBirth.Month,
            checkUserIsExist.DateOfBirth.Day));
    }
}