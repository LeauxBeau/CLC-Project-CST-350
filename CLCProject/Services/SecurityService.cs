using CLCProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace CLCProject.Services
{
    public class SecurityService
    {
        private readonly SecurityDAO _securityDAO;

        public SecurityService(SecurityDAO securityDAO)
        {
            _securityDAO = securityDAO;
        }

        public bool IsValid(UserModel user)
        {
            return _securityDAO.FindUserByNameAndPassword(user);
        }
    }
}

    

