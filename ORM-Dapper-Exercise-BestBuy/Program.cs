using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper_Exercise_BestBuy;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);


var departmentRepo = new DepartmentRepository(conn);

//departmentRepo.InsertDepartment("Compact Discs");

var departments = departmentRepo.GetAllDepartments();

foreach (var dep in departments)
{
    Console.WriteLine($"Department Name: {dep.Name} | Department ID: {dep.DepartmentID}");
}


var productRepo = new ProductRepository(conn);

//productRepo.CreateProduct("HP Pavillion Laptop", 249.99, 1);

productRepo.UpdateProduct("HP Pavillion Laptop", 229.99, 1);

var products = productRepo.GetAllProducts();

foreach (var prod in products)
{
    Console.WriteLine($"Product Name: {prod.Name} | Price: {prod.Price} | Category ID: {prod.CategoryID}");
}