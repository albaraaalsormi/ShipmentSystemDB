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
    public class AddressServiceImpl : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressServiceImpl(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public void Create(AddressDto addressDto)
        {
            if (addressDto == null)
                throw new ArgumentNullException(nameof(addressDto));

            var addressEntity = _mapper.Map<Address>(addressDto);

            addressEntity.AddressID = 0;

            _addressRepository.Add(addressEntity);
        }

        public AddressDto GetById(int id)
        {
            var addressEntity = _addressRepository.GetById(id);

            if (addressEntity == null)
                return null;

            return _mapper.Map<AddressDto>(addressEntity);
        }

        public IEnumerable<AddressDto> GetAll()
        {
            var addressEntities = _addressRepository.GetAll();

            return _mapper.Map<IList<AddressDto>>(addressEntities);
        }

        public void Update(AddressDto addressDto)
        {
            if (addressDto == null)
                throw new ArgumentNullException(nameof(addressDto));

            var existingAddress = _addressRepository.GetById(addressDto.AddressID);

            if (existingAddress == null)
                throw new ArgumentNullException(nameof(addressDto));

            _mapper.Map(addressDto, existingAddress);

            _addressRepository.Update(existingAddress);
        }

        public void Delete(int id)
        {
            var existingAddress = _addressRepository.GetById(id);

            if (existingAddress == null)
                throw new ArgumentNullException(nameof(id));

            _addressRepository.Delete(id);
        }
    }
}