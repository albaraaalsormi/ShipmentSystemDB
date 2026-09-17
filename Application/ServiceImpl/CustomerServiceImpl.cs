using System;
using System.Collections.Generic;
using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.IServices;
using Domain.IRepositories;

namespace Application.Services
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public void Create(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var customerEntity = _mapper.Map<Customer>(customerDto);

            customerEntity.CustomerID = 0;

            _customerRepository.Add(customerEntity);
        }

        public CustomerDto GetById(int id)
        {
            var customerEntity = _customerRepository.GetById(id);

            if (customerEntity == null)
                return null;

            return _mapper.Map<CustomerDto>(customerEntity);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customerEntities = _customerRepository.GetAll();

            return _mapper.Map<IList<CustomerDto>>(customerEntities);
        }

        public void Update(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            var existingCustomer = _customerRepository.GetById(customerDto.CustomerID);

            if (existingCustomer == null)
                throw new ArgumentNullException(nameof(customerDto));

            _mapper.Map(customerDto, existingCustomer);

            _customerRepository.Update(existingCustomer);
        }

        public void Delete(int id)
        {
            var existingCustomer = _customerRepository.GetById(id);

            if (existingCustomer == null)
                throw new ArgumentNullException(nameof(id));

            _customerRepository.Delete(id);
        }
    }
}