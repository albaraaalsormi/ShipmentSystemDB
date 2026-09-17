using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Application.IServices;
using Application.ServiceImpl;

using Domain.IRepositories;

using Infrastructure.Data;
using Infrastructure.Repositories;
using Application.Services;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        var configuration = context.Configuration;

                        // 1. DbContext
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString("DefaultConnection")));

                        // 2. Repositories
                        services.AddScoped<IUserRepository, UserRepository>();
                        services.AddScoped<IAddressRepository, AddressRepository>();
                        services.AddScoped<ICustomerRepository, CustomerRepository>();
                        services.AddScoped<IDeliveryPersonRepository, DeliveryPersonRepository>();
                        services.AddScoped<IDeliveryRepository, DeliveryRepository>();
                        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
                        services.AddScoped<IOrderRepository, OrderRepository>();
                        services.AddScoped<IPaymentRepository, PaymentRepository>();
                        services.AddScoped<IProductRepository, ProductRepository>();
                        services.AddScoped<IShipmentRepository, ShipmentRepository>();

                        // 3. Services
                        // 3. Services
                        services.AddScoped<IUserService, UserServiceImpl>();
                        services.AddScoped<IAddressService, AddressServiceImpl>();
                        services.AddScoped<ICustomerService, CustomerServiceImpl>();
                        services.AddScoped<IDeliveryPersonService, DeliveryPersonServiceImpl>();
                        services.AddScoped<IDeliveryService, DeliveryServiceImpl>();
                        services.AddScoped<IOrderItemService, OrderItemServiceImpl>();
                        services.AddScoped<IOrderService, OrderServiceImpl>();
                        services.AddScoped<IPaymentService, PaymentServiceImpl>();
                        services.AddScoped<IProductService, ProductServiceImpl>();
                        services.AddScoped<IShipmentService, ShipmentServiceImpl>();

                        // 4. AutoMapper
                        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                        // 5. Controllers
                        services.AddControllers();

                        // 6. Swagger
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo
                            {
                                Title = "Shipment System API",
                                Version = "v1"
                            });
                        });
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        // Swagger
                        app.UseSwagger();

                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint(
                                "/swagger/v1/swagger.json",
                                "Shipment System API v1");
                        });

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}

