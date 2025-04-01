using E_comm.Aspects;
using E_comm.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Aspects;
using E_Commerce.Aspects;
using Ecommerce.Exceptions;
using E_Commerce.Exceptions;

namespace e_comm.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;

            if (exceptionType == typeof(ProductNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(ProductAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else
            {
                var result = new StatusCodeResult(500);
                context.Result = result;
            }


            //cart exceptions
            if (context.Exception is CartNotFoundException || context.Exception is CartItemNotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception is CartAlreadyExistsException || context.Exception is CartItemAlreadyExistsException)
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }

        }
    }
}
