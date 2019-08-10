using Common.Mixins;
using DBModel;
using DBModel.Trail;
using DBModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailRepository
{
    public class TrailRepository
    {
        // Make class into a singleton
        private static readonly Lazy<TrailRepository> lazy = new Lazy<TrailRepository> (() => new TrailRepository());
        public static TrailRepository Instance { get { return lazy.Value; } }


        public List<TrailOne> m_trailOnes { get; private set; } = new List<TrailOne>();
        public List<TrailTwo> m_trailTwos { get; private set; } = new List<TrailTwo>();


        private void LoadTrailsFromDatabase()
        {
            using (var dataContext = new SampleDBContext())
            {
                m_trailOnes = dataContext.TrailOnes.ToList();
                m_trailTwos = dataContext.TrailTwos.ToList();
            }
        }

        public TrailRepository()
        {
            LoadTrailsFromDatabase();
        }

        public List<TrailOne> GetStageOneTrails()
        {
            List<TrailOne> stageOneTrails = new List<TrailOne>();
            stageOneTrails.AddRange(m_trailOnes);
            stageOneTrails.Shuffle();
            return stageOneTrails;
        }

        public List<TrailTwo> GetStageTwoTrails()
        {
            List<TrailTwo> stageTwoTrails = new List<TrailTwo>();
            stageTwoTrails.AddRange(m_trailTwos);
            stageTwoTrails.AddRange(m_trailOnes.Select(v => (TrailTwo)v));
            stageTwoTrails.Shuffle();
            return stageTwoTrails;
        }

    }
}
