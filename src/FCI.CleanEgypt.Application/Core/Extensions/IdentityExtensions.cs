using Microsoft.AspNetCore.Identity;
using System.Text;

namespace FCI.CleanEgypt.Application.Core.Extensions;

public static class IdentityExtensions
{
    public static string GetErrors(this IdentityResult result)
    {
        var sb = new StringBuilder();
        foreach (var error in result.Errors) sb.AppendLine(error.Description);

        return sb.ToString();
    }
}