using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class PollService
    {
        private readonly IPollRepository pollRepository;
        public PollService(IPollRepository pollRepository)
        {
            this.pollRepository = pollRepository;
        }

        public IEnumerable<Poll> GetPolls()
        {
            return pollRepository.GetAll();
        }
        public Poll GetPoll(int id)
        {
            return pollRepository.Get(id);
        }

        public Poll AddPoll(Poll poll)
        {
            return pollRepository.Add(poll);
        }
        public Poll UpdatePoll(Poll poll)
        {
            return pollRepository.Update(poll);
        }

        public void DeletePoll(int id)
        {
            pollRepository.Remove(id);
        }

    }
}
