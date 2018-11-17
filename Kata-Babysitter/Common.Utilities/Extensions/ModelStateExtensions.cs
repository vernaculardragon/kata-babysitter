using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Common.Utilities.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary dict, List<ValidationError> errors)
        {
            foreach (var error in errors)
            {
                dict.AddModelError(error.Property,error.Message);
            }

        }
    }
}
