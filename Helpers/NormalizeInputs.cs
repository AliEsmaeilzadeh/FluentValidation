using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationProject.Helpers
{
    public class NormalizeInputs: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameters = context.ActionArguments.Keys.ToArray();

            foreach (var parameterName in parameters)
            {
                context.ActionArguments.TryGetValue(parameterName, out object parameterValue);
                if (parameterValue != null)
                {
                    var parameterType = parameterValue.GetType();

                    if (parameterType == typeof(int)
                                || parameterType == typeof(long)
                                || parameterType == typeof(byte)
                                || parameterType == typeof(DateTime)
                                || parameterType == typeof(double)
                                || parameterType.IsEnum)
                        continue;

                    else if (parameterType == typeof(string))
                    {
                        var normalValue = Common.PersianDigitToEnglish(parameterValue);
                        context.ActionArguments[parameterName] = normalValue;
                    }

                    else
                    {
                        var properties = parameterType.GetProperties();
                        foreach (var property in properties)
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                var currValue = property.GetValue(parameterValue);
                                var normalValue = Common.PersianDigitToEnglish(currValue);
                                property.SetValue(parameterValue, normalValue);
                            }
                        }
                    }
                }
            }
        }
    }
}
