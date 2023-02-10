using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ToDo_MVC.Models;

namespace ToDo_MVC.Tools
{
    public class ExceptionFilter : IFilterMetadata
    {
        private readonly IHostEnvironment _hostEnvironment;
        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context) 
        {
            ErrorViewModel errorViewModel = new ErrorViewModel() { Message = context.Exception.Message };

            if (!_hostEnvironment.IsDevelopment())
            {
                errorViewModel.Message = "Something went wrong...";
            }

            ViewResult result = new ViewResult() { ViewName = "ShowError" };
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Model = errorViewModel;

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
