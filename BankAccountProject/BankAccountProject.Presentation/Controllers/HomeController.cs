using AutoMapper;
using BankAccountProject.Dtos;
using BankAccountProject.Presentation.ApiConnection.ApiInterface;
using BankAccountProject.Presentation.Models;
using BankAccountProject.Services;
using BankAccountProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankAccountProject.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        //private readonly IApiConnection _connection;
        private readonly IMapper _mapper;


        public HomeController(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
            //_connection = apiConnection;
        }

        public async Task<IActionResult> Index()
        {
            //await SyncData();
            var bankList = await _bankAccountService.GetAllBankAccountsAsync();

            return View(bankList);

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

        //public async Task<IActionResult> SyncData()
        //{
        //    try
        //    {
        //        var apiData = await _connection.GetBankAccounts();
        //        var dbData = await _bankAccountService.GetAllBankAccountsAsync();

        //        foreach (var apiAccount in apiData)
        //        {
        //            var dbAccount = dbData.FirstOrDefault(ba => ba.id == apiAccount.id);
        //            if (dbAccount != null)
        //            {
        //                if (dbAccount.Equals(apiAccount)) continue;

        //                if (apiAccount.borc is null) apiAccount.borc = 0;

        //                await _bankAccountService.UpdateBankAccountAsync(apiAccount);
        //            }
        //            else
        //            {
        //                if (apiAccount.borc is null) apiAccount.borc = 0;
        //                await _bankAccountService.AddBankAccountAsync(apiAccount);
        //            }

        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(message: ex.Message);
        //    }
        //}
    }
}