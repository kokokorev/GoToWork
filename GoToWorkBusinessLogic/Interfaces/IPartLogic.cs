using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.Interfaces
{
    public interface IPartLogic
    {
        List<PartViewModel> Read(PartBindingModel model);
        void CreateOrUpdate(PartBindingModel model);
        void Delete(PartBindingModel model);
    }
}
