using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.Interfaces
{
    public interface IToyLogic
    {
        List<ToyViewModel> Read(ToyBindingModel model);
        void CreateOrUpdate(ToyBindingModel model);
        void Delete(ToyBindingModel model);

    }
}
