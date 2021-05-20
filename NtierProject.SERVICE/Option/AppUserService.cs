using NtierProject.SERVICE.Base;
using NTierProject.MODEL.Entities;

namespace NtierProject.SERVICE.Option
{
    public class AppUserService:BaseService<AppUser>
    {
        public bool CheckCredentials(string _username, string _password)
        {
            return Any(x => x.UserName == _username && x.Password == _password);
        }
    }
}
