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
        public const string LOGIN = "[dbo].[LoginProc]";
    }
}
