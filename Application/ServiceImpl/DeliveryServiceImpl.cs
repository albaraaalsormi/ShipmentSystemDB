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
    public class DeliveryServiceImpl : IDeliveryService
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryServiceImpl(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public void Create(DeliveryDto deliveryDto)
        {
            if (deliveryDto == null)
                throw new ArgumentNullException(nameof(deliveryDto));

            var deliveryEntity = _mapper.Map<Delivery>(deliveryDto);

            deliveryEntity.DeliveryID = 0;

            _deliveryRepository.Add(deliveryEntity);
        }

        public DeliveryDto GetById(int id)
        {
            var deliveryEntity = _deliveryRepository.GetById(id);

            if (deliveryEntity == null)
                return null;

            return _mapper.Map<DeliveryDto>(deliveryEntity);
        }

        public IEnumerable<DeliveryDto> GetAll()
        {
            var deliveryEntities = _deliveryRepository.GetAll();

            return _mapper.Map<IList<DeliveryDto>>(deliveryEntities);
        }

        public void Update(DeliveryDto deliveryDto)
        {
            if (deliveryDto == null)
                throw new ArgumentNullException(nameof(deliveryDto));

            var existingDelivery = _deliveryRepository.GetById(deliveryDto.DeliveryID);

            if (existingDelivery == null)
                throw new ArgumentNullException(nameof(deliveryDto));

            _mapper.Map(deliveryDto, existingDelivery);

            _deliveryRepository.Update(existingDelivery);
        }

        public void Delete(int id)
        {
            var existingDelivery = _deliveryRepository.GetById(id);

            if (existingDelivery == null)
                throw new ArgumentNullException(nameof(id));

            _deliveryRepository.Delete(id);
        }
    }
}