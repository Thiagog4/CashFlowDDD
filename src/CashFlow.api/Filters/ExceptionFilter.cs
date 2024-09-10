using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CashFlow.Exception;
namespace CashFlow.api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = context.Exception as CashFlowException;
        var errorResponse = new ResponseErrorJson(cashFlowException!.GetErrors());


        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(cashFlowException);


        //if (context.Exception is ErrorOnValidationException)
        //{
        //    var ex = (ErrorOnValidationException)context.Exception;
        //    var errorResponse = new ResponseErrorJson(ex.Errors);
        //    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        //    context.Result = new BadRequestResult();
        //}
        //else if(context.Exception is NotFoundException notFoundException)
        //{
        //    var errorResponse = new ResponseErrorJson(notFoundException.Message);
        //    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        //    context.Result = new NotFoundObjectResult(errorResponse);
        //}
        //else
        //{
        //    var errorResponse = new ResponseErrorJson(context.Exception.Message);
        //    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        //    context.Result = new BadRequestObjectResult(errorResponse);
        //}
    }
    
    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
    
}