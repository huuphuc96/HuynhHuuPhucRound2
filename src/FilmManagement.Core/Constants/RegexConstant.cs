using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagement.Core.Constants
{
    public class RegexConstant
    {
        public const string PASSWORD = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%!^&*()~`:;?_-]).{8,20}$";
        public const string EMAIL = @"^(?=.*[a-zA-Z].*\@.*)(([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)?\@((([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)+)(\.(([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)+)+$";
    }
}
