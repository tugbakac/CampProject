using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDTO : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
