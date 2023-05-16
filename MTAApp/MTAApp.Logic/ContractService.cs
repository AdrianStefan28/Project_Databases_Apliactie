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

        public Contract UpdateContract(Contract contract)
        {
            return contractRepository.Update(contract);
        }

        public void DeleteContract(int id)
        {
            contractRepository.Remove(id);
        }

        public double CalculateTotalContractCost(Contract contract)
        {
            return (double)(contract.ContractDuration * contract.Cost);
        }

        public void SetContractDuration(Contract contract, double newContractDuration) 
        {
            contract.ContractDuration = newContractDuration;
        }

        public Contract GetContractByType(string type)
        {
            return contractRepository.GetContractByType(type);
        }
    }
}
