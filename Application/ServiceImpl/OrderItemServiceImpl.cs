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
    public class OrderItemServiceImpl : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemServiceImpl(
            IOrderItemRepository orderItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public void Create(OrderItemDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<OrderItem>(dto);

            entity.OrderItemID = 0;

            _orderItemRepository.Add(entity);
        }

        public OrderItemDto GetById(int id)
        {
            var entity = _orderItemRepository.GetById(id);

            if (entity == null)
                return null;

            return _mapper.Map<OrderItemDto>(entity);
        }

        public IEnumerable<OrderItemDto> GetAll()
        {
            var entities = _orderItemRepository.GetAll();

            return _mapper.Map<IList<OrderItemDto>>(entities);
        }

        public void Update(OrderItemDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingEntity =
                _orderItemRepository.GetById(dto.OrderItemID);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(dto));

            _mapper.Map(dto, existingEntity);

            _orderItemRepository.Update(existingEntity);
        }

        public void Delete(int id)
        {
            var existingEntity = _orderItemRepository.GetById(id);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(id));

            _orderItemRepository.Delete(id);
        }
    }
}