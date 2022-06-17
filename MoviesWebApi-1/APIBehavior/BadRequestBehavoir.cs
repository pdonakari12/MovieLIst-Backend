using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_1.APIBehavior
{
    public class BadRequestBehavoir
    {
        public static void Parse(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
              {
                  var response = new List<string>();
                  foreach (var key in context.ModelState.Keys)
                  {
                      foreach (var error in context.ModelState[key].Errors)
                      {
                          response.Add($"{key}:{error.ErrorMessage}");
                      }
                  }
                  return new BadRequestObjectResult(response);
              };
        }

    }
}
