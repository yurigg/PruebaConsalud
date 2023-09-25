using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.DTO
{
    public class BusinessException : System.Exception
    {
        public override string Message => this._userMessage;
        private readonly string _userMessage;

        public BusinessException(string userMessage)
        {
            _userMessage = userMessage;
        }

    }
}
