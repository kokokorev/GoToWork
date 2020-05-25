using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoToWorkRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderLogic _logic;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 10;

        public ProviderController(IProviderLogic logic)
        {
            this._logic = logic;
        }

        [HttpGet]
        public ProviderViewModel Login(string email, string password) => _logic.Read(new ProviderBindingModel
        {
            Email = email,
            Password = password
        })?.FirstOrDefault();

        [HttpPost]
        public void Registration(ProviderBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        /* не используется */
        [HttpPost]
        public void UpdateData(ProviderBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        private void CheckData(ProviderBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("В качестве логина должна быть указана почта");
            }

            if (model.Password.Length > _passwordMaxLength
                || model.Password.Length < _passwordMinLength
                || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль должен быть длиной от {_passwordMinLength} до { _passwordMaxLength } и должен состоять из цифр, букв и небуквенных символов");
            }
        }
    }
}