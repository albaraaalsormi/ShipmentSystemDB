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
    public class OrderServiceImpl : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderServiceImpl(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void Create(OrderDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<Order>(dto);

            entity.OrderID = 0;

            _orderRepository.Add(entity);
        }

        public OrderDto GetById(int id)
        {
            var entity = _orderRepository.GetById(id);

            if (entity == null)
                return null;

            return _mapper.Map<OrderDto>(entity);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var entities = _orderRepository.GetAll();

            return _mapper.Map<IList<OrderDto>>(entities);
        }

        public void Update(OrderDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingEntity = _orderRepository.GetById(dto.OrderID);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(dto));

            _mapper.Map(dto, existingEntity);

            _orderRepository.Update(existingEntity);
        }

        public void Delete(int id)
        {
            var existingEntity = _orderRepository.GetById(id);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(id));

            _orderRepository.Delete(id);
        }
    }
}