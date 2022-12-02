﻿using System.Net;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Services;
using Shop.Repositories;
using Microsoft.Extensions.Logging;

var factory = new ApplicationDbContextFactory();
var context = factory.CreateDbContext(new string[0]);

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<CustomerService>();

var customerRepository = new CustomerRepository(context);

var cusomerService = new CustomerService(customerRepository, logger);

var name = "name1";
var address = "address1";
var email = "email1@gmail.com";
var phone = "phone1";

var customer1 = cusomerService.AddCustomer(name, address, email, phone);
var customer2 = cusomerService.AddCustomer(name, address, email, phone);

cusomerService.DeleteCustomer(customer1);

Console.WriteLine(cusomerService.GetCustomer(customer2).Name);