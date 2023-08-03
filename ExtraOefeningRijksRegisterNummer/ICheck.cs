using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraOefeningRijksRegisterNummer
{
    public interface ICheck
    {
        public bool Check();
        public string ErrorMessage();  
    }

}
