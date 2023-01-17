using System.Security.Principal;

namespace WebMVCnew.Services
{
    public interface IIdentityService<T>
    {
        T Get(IPrincipal principal);
    }
}
