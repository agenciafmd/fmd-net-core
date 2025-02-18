using System.Net;
using Fmd.Net.Core.DomainObjects;
using Fmd.Net.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fmd.Net.Core.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException domainException)
        {
            var resposta = new BaseResponse<object>(false, null, null, new List<string> { domainException.Message });
            
            var verboHttp = context.HttpContext.Request.Method;
            context.Result = verboHttp == HttpMethod.Get.Method || verboHttp == HttpMethod.Delete.Method ? 
                new NotFoundObjectResult(resposta) :
                new BadRequestObjectResult(resposta);
            
            return;
        }
        
        if (context.Exception is not DomainException)
        {
            var resposta = new BaseResponse<object>(false, null, null, 
                new List<string> { context.Exception.Message, context.Exception.InnerException?.Message });
            
            context.Result = new ObjectResult(resposta) { StatusCode = (int)HttpStatusCode.InternalServerError };
            
            return;
        }
        
        context.ExceptionHandled = true;
    }
}