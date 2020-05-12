using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.Interfaces
{
    public interface IProviderLogic
    {
        List<ProviderViewModel> Read(ProviderBindingModel model);
        void CreateOrUpdate(ProviderBindingModel model);
        void Delete(ProviderBindingModel model);
    }
}
