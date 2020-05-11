using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.Interfaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);
        void CreateOrUpdate(RequestBindingModel model);
        void Delete(RequestBindingModel model);
    }
}
