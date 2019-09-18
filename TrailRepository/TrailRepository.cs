using DBModel;
using DBModel.Trail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRepository
{
    public interface ITrailRepository
    {
        List<TrailOne> LoadTrailOnesFromDatabase();
        List<TrailTwo> LoadTrailTwosFromDatabase();
    }

    public class TrailRepository : ITrailRepository
    {
        private readonly SampleDBContext m_dataContext = new SampleDBContext();

        private List<TrailOne> m_trailOnes = null;
        private List<TrailTwo> m_trailTwos = null;
        public List<TrailOne> LoadTrailOnesFromDatabase()
        {
            if(m_trailOnes == null)
                m_trailOnes = m_dataContext.TrailOnes.ToList();
            return m_trailOnes;
        }

        public List<TrailTwo> LoadTrailTwosFromDatabase()
        {
            if (m_trailTwos == null)
            {
                var trailOnes = LoadTrailOnesFromDatabase();
                m_trailTwos = m_dataContext.TrailTwos.ToList();
                m_trailTwos.AddRange(trailOnes.Select(v => (TrailTwo)v));
            }

            return m_trailTwos;
        }

    }
}
