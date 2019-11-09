using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRepository
{
    public static class UserRepository
    {
        private static readonly SampleDBContext m_dataContext = new SampleDBContext();

        public static List<User> GetAllUsers()
        {
            return m_dataContext.Users.ToList();
        }

        public static List<User> GetUnfinishedGroup4Users()
        {
            return m_dataContext.Users.Where(user => user.Group == UserGroup.Four && user.EndTimeStageTwo == null).ToList();
        }
    }
}
