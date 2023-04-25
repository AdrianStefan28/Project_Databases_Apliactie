using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class ContractService
    {
        private readonly IContractRepository contractRepository;
        public ContractService(IContractRepository contractRepository)
        {
            this.contractRepository = contractRepository;
        }

        public IEnumerable<Contract> GetContracts()
        {
            return contractRepository.GetAll();
        }
    }
}
