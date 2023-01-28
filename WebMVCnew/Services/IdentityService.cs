using System.Security.Claims;
using System.Security.Principal;
using WebMVCnew.webModels;

namespace WebMVCnew.Services
{
    public class IdentityService : IIdentityService<ApplicationUser>
    {
        public ApplicationUser Get(IPrincipal principal)
        {
            if(principal is ClaimsPrincipal claims)
            {
                var user = new ApplicationUser
                {
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value ?? "",
                    Id = claims.Claims.FirstOrDefault(x => x.Type == "Preferred_username")?.Value ?? "",
                };
                return user;
            }
            throw new ArgumentException(message: "The principal must be a claimsprincipal", paramName: nameof(principal));
        }
    }
}
