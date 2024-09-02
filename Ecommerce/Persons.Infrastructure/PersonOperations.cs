using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Infrastructure
{
    public interface PersonOperations
    {
        public const string SP_REGISTER_PERSON = "[dbo].[InsertPerson]";
        public const string SP_LOGIN = "[dbo].[LoginProc]";
        public const string SP_CHANGE_PASSWORD = "[dbo].[ChangePassword]";
        public const string SP_CREATE_CREDIT_CARD = "[dbo].[InsertCreditCard]";
        public const string SP_DELETE_PERSON = "[dbo].[DeletePerson]";
        public const string SP_GET_PERSON_BY_EMAIL = "[dbo].[GetPersonById]";
    }
}
