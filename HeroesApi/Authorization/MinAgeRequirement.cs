using Microsoft.AspNetCore.Authorization;

namespace HeroesApi.Authorization
{
    public class MinAgeRequirement : IAuthorizationRequirement
    {
        public int MinAge { get; set; }

        public MinAgeRequirement(int minAge)
        {
            MinAge = minAge;
        }
    }
}
