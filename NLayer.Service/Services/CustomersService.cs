using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CustomersService : Service<Customers>, ICustomersService
    {

        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CustomersService(IGenericRepository<Customers> repository, ICustomersRepository customersRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task UpdateAsync(CustomersUpdateDto customersDto)
        {
            var existingCustomer = await _customersRepository.GetByIdAsync(customersDto.Id);

            if (existingCustomer == null)
            {
                // Eğer belirtilen Id'ye sahip bir müşteri bulunamazsa hata işlemleri burada gerçekleştirilebilir.
                throw new Exception("Customer not found.");
            }

            // AutoMapper kullanarak CustomersUpdateDto'yu Customers sınıfına dönüştürme
            _mapper.Map(customersDto, existingCustomer);

            //// Dönüştürülen müşteriyi güncelleme işlemi
            //await _customersRepository.UpdateAsync(existingCustomer);

            //// Unit of Work'u kaydetme işlemi
            //await _unitOfWork.CommitAsync();
        }
    }













        
}
