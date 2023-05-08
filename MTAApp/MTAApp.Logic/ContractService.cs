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

        public Contract GetContract(int id)
        {
            return contractRepository.Get(id);
        }

        public Contract AddContract(Contract contract)
        {
            return contractRepository.Add(contract);
        }

        public void DeleteContract(int id)
        {
            contractRepository.Remove(id);
        }

    }
}
