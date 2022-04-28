using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HeroesApi.Authorization
{
    public class MinAgeHandler : AuthorizationHandler<MinAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAgeRequirement requirement)
        {
            if(context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask;

            DateTime dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => 
                c.Type == ClaimTypes.DateOfBirth
            ).Value);

            int minAge = DateTime.Now.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-minAge))
                minAge--;

            if (minAge >= requirement.MinAge) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
