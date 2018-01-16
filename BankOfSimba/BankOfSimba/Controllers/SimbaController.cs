using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankOfSimba.Models;
using BankOfSimba.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankOfSimba.Controllers
{
    [Route("")]
    public class SimbaController : Controller
    {
        public static AccountViewModel AccountList { get; set; } = new AccountViewModel();

        [HttpGet("")]               
        
        public IActionResult Index()
        {
            if (AccountList.BankAccountList.Count == 0)
            {
                var simba = new BankAccounts() { Name = "Simba", Balance = 1000.00, AnimalType = "Lion" };
                var nala = new BankAccounts() { Name = "nala", Balance = 2000.00, AnimalType = "Lion" };
                var pumba = new BankAccounts() { Name = "pumba", Balance = 0.00, AnimalType = "Pig" };
                var timon = new BankAccounts() { Name = "timon", Balance = 340.00, AnimalType = "SuchAnimal" };
                var lionKing = new BankAccounts() { Name = "Boss", Balance = 340.00, AnimalType = "King" };
                var evilCharacter = new BankAccounts() { Name = "evilCharacter", Balance = -1.00, AnimalType = "SuchHiena" };
                
                AccountList.BankAccountList.Add(simba);
                AccountList.BankAccountList.Add(nala);
                AccountList.BankAccountList.Add(timon);
                AccountList.BankAccountList.Add(lionKing);
                AccountList.BankAccountList.Add(evilCharacter); 
            }
            return View(AccountList);                     
        }

        [HttpPost("add")]        
        public IActionResult AddAnimal(BankAccounts newAccount)
        {            
            AccountList.BankAccountList.Add(newAccount);

            return RedirectToAction("Index");
        }

        [HttpPost("modify")]
        public IActionResult ModifyAnimal(Modify AnimalToModify)
        {
            int zebraNumber = 0;
            if (AccountList.BankAccountList[AnimalToModify.AnimalInTheTable].AnimalType=="King")
            {
                zebraNumber = 100;
            }
            else
            {
                zebraNumber = 10;
            }
            AccountList.BankAccountList[AnimalToModify.AnimalInTheTable].Balance += zebraNumber;
            return RedirectToAction("Index");
        }
    }
}
