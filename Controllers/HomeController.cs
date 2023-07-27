﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebDevAss2.Models;
using WebDevAss2.Data.Repositories;
using WebDevAss2.Data;

namespace WebDevAss2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserDataWebServiceRepository<List<Customer>> _jsonDataWebService;
    private readonly IDataAccessRepository _dataAccess;
    private readonly McbaDbContext _context;

    public HomeController(
        ILogger<HomeController> logger
        , IUserDataWebServiceRepository<List<Customer>> jsonDataWebService
        , IDataAccessRepository dataAccess
        , McbaDbContext context)
    {
        _logger = logger;
        _jsonDataWebService = jsonDataWebService;
        _dataAccess = dataAccess;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Paginate out user data here for proof of concept
        List<Customer> customers = await _jsonDataWebService.FetchJsonData("https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/");
        _dataAccess.StoreJsonData(customers);

        return View(customers[0]);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
