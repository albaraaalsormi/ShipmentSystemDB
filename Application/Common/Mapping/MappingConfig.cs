using Application.DTOs;
using AutoMapper;
using Domain.Entities;


public class MappingConfig : Profile
{
    public  MappingConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Delivery, DeliveryDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Shipment,ShipmentDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<DeliveryPerson, DeliveryPersonDto>().ReverseMap();
        CreateMap<Address,AddressDto>().ReverseMap();
    }
}
