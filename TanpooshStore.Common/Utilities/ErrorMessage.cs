using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TanpooshStore.Common.Utilities
{
    public class ErrorMessage
    {
        public const string RequierdMsg = "{0} را وارد نمایید";
        public const string MaxLenghtMsg = " {0} نباید بیشتر از {1} کاراکتر باشد";
        public const string MinLenghtMsg = " {0} نباید کمتر از {1} کاراکتر باشد";
        public const string RegExpMsg = "قالب نوشتاری {0} اشتباه است";
        public const string Compare = "{0} وارد شده یکسان نمی باشد";
        public const string StringLength = "{0} باید حداقل 6 کاراکتر و حداکثر 100 کاراکتر باشد";
    }    
}
