using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class ApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }

        public IEnumerable<Apartment> GetApartments()
        {
            return apartmentRepository.GetAll();
        }
     

    }
}
