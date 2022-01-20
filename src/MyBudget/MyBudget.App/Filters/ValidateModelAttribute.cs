using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid is false)
            {
                context.Result = new ViewResult();
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            
            if (context.HttpContext.Request.Query.TryGetValue("Error", out StringValues stringValue))
            {
                var value = stringValue.ToString();
                if (Enum.TryParse(value, out DomainError domainError))
                {
                    if(context.Controller is Controller controller)
                        controller!.ViewBag.Error = Map(domainError);
                }
            }
            base.OnActionExecuted(context);
        }

        private string Map(DomainError domainError)
        {
            switch (domainError)
            {
                case DomainError.InvalidCredentials:
                    return "Niepoprawne dane logowania!";
                case DomainError.InvalidUsername:
                    return "Niepoprawny login!";
                case DomainError.UserWithGivenUsernameAlreadyExists:
                    return "Podany login jest już zajęty!";
                case DomainError.PasswordCannotBePartOfUsername:
                    return "Hasło nie może być częścią nazwy użytkownika!";
                case DomainError.PasswordHaveToBeProvided:
                    return "Hasło musi zostać podane!";
                case DomainError.PasswordPolicyVaildationFailed:
                    return "Hasło nie spełnia wymagań!";
                case DomainError.PasswordsAreNotIdentitcal:
                    return "Hasło i powtórzone hasło nie są identyczne!";
                case DomainError.InvalidObjectName:
                    return "Nieprawidłowa nazwa!";
                case DomainError.InvalidOperationValue:
                    return "Nieprawidłowa wartość operacji i jej typ!";
                case DomainError.CannotRenameOperationIfInheritsFromTemplate:
                    return "Nie można zmienić nazwy operacji jeżeli pochodzi ze schematu!";
                case DomainError.InvalidDate:
                    return "Niepoprawna data!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(domainError), domainError, null);
            }
        }
    }
}

