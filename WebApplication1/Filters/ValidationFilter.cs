using Microsoft.AspNetCore.Mvc.Filters;
using SOLID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        CustomErrorRequestValidator errorObj;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            { 
                var modelstate = context.ModelState
                    .Where(error => error.Value.Errors.Count() > 0 )
                    .ToDictionary( x => x.Key , x => x.Value.Errors.Select( s => s.ErrorMessage).ToArray());

                errorObj = new CustomErrorRequestValidator();
                foreach (var item in modelstate)
                {
                   List<string []> errormessages =  modelstate.Where(m => m.Key == item.Key).Select(v => v.Value).ToList();
                    string[] value = null;
                    errorObj.failures.TryGetValue(item.Key, out value);
                    if(value == null) 
                    errorObj.failures.TryAdd(item.Key,errormessages[0]);
                }    
                throw new ModelValidatorException("ModelSate", "400", "Validation failed for model",errorObj);
            }
           await next();
        }
    }
}
