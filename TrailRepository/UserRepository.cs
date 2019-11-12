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

        public static void UpsertUser(User user)
        {
            if (user != null)
                using (var context = new SampleDBContext())
                {
                    var userEntity = context.Users.Update(user);
                    context.SaveChanges();
                    user.Id = userEntity.Entity.Id;
                }
        }

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
