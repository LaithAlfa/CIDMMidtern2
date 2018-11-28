using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIIDMMiderm2.Models;

using MathLibrary;

namespace CIIDMMiderm2.Controllers
{
    public class MathController : Controller
    {
        
        public IActionResult DoCalculation()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult ShowCalculationResults(MathOperation model)
        {
             switch (model.Operator) {
                case "ADD":
                    model.Result = (MyMathRoutines.Add(model.LeftOperand ,model.RightOperand));                  
                    break;

                case "Subtract":   
                    model.Result = ( MyMathRoutines.Subtract(model.LeftOperand ,model.RightOperand));
                    break;
                case "Multiply":
                    model.Result = (MyMathRoutines.Multiply(model.LeftOperand ,model.RightOperand));
                    break;
                case "Divide":
                    model.Result = (MyMathRoutines.Divide(model.LeftOperand ,model.RightOperand));
                break;
             }

            
            return View(model); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
