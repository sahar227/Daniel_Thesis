using DBModel;
using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRepository
{
    public static class TrailRepository
    {
        private static List<TrailOne> m_trailOnes = null;
        private static List<TrailTwo> m_trailTwos = null;
        public static List<TrailOne> LoadTrailOnesFromDatabase()
        {
            if (m_trailOnes == null)
            {
                using (var context = new SampleDBContext())
                    m_trailOnes = context.TrailOnes.ToList();
            }
            return m_trailOnes;
        }

        public static List<TrailTwo> LoadTrailTwosFromDatabase()
        {
            if (m_trailTwos == null)
            {
                var trailOnes = LoadTrailOnesFromDatabase();
                using (var context = new SampleDBContext())
                    m_trailTwos = context.TrailTwos.ToList();
                m_trailTwos.AddRange(trailOnes.Select(v => (TrailTwo)v));
            }
            return m_trailTwos;
        }

    }
}
