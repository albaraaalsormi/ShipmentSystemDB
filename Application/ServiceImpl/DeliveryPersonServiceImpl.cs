using System;
using System.Collections.Generic;
using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Repositories;
using Domain.IRepositories;
using Application.IServices;

namespace Application.Services
{
    public class DeliveryPersonServiceImpl : IDeliveryPersonService
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryPersonRepository _deliveryPersonRepository;

        public DeliveryPersonServiceImpl(
            IDeliveryPersonRepository deliveryPersonRepository,
            IMapper mapper)
        {
            _deliveryPersonRepository = deliveryPersonRepository;
            _mapper = mapper;
        }

        public void Create(DeliveryPersonDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<DeliveryPerson>(dto);

            entity.DeliveryPersonID = 0;

            _deliveryPersonRepository.Add(entity);
        }

        public DeliveryPersonDto GetById(int id)
        {
            var entity = _deliveryPersonRepository.GetById(id);

            if (entity == null)
                return null;

            return _mapper.Map<DeliveryPersonDto>(entity);
        }

        public IEnumerable<DeliveryPersonDto> GetAll()
        {
            var entities = _deliveryPersonRepository.GetAll();

            return _mapper.Map<IList<DeliveryPersonDto>>(entities);
        }

        public void Update(DeliveryPersonDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingEntity =
                _deliveryPersonRepository.GetById(dto.DeliveryPersonID);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(dto));

            _mapper.Map(dto, existingEntity);

            _deliveryPersonRepository.Update(existingEntity);
        }

        public void Delete(int id)
        {
            var existingEntity = _deliveryPersonRepository.GetById(id);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(id));

            _deliveryPersonRepository.Delete(id);
        }
    }
}