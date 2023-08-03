using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraOefeningRijksRegisterNummer
{
    public class CheckList
    {
        private List<ICheck> _checkList;

        public CheckList()
        {
        }

        public List<ICheck> ListOfChecks
        {
            get
            {
                return _checkList;
            }

            set
            {
                _checkList = value;
            }

        }

    }

}
