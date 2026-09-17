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
    public class PaymentServiceImpl : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentServiceImpl(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public void Create(PaymentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = _mapper.Map<Payment>(dto);

            entity.PaymentID = 0;

            _paymentRepository.Add(entity);
        }

        public PaymentDto GetById(int id)
        {
            var entity = _paymentRepository.GetById(id);

            if (entity == null)
                return null;

            return _mapper.Map<PaymentDto>(entity);
        }

        public IEnumerable<PaymentDto> GetAll()
        {
            var entities = _paymentRepository.GetAll();

            return _mapper.Map<IList<PaymentDto>>(entities);
        }

        public void Update(PaymentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingEntity = _paymentRepository.GetById(dto.PaymentID);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(dto));

            _mapper.Map(dto, existingEntity);

            _paymentRepository.Update(existingEntity);
        }

        public void Delete(int id)
        {
            var existingEntity = _paymentRepository.GetById(id);

            if (existingEntity == null)
                throw new ArgumentNullException(nameof(id));

            _paymentRepository.Delete(id);
        }
    }
}