using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using DBOperations;
using Microsoft.Data.SqlClient;
using PasswordGeneratorPR;
using Persons.Core.DTOs.CreditCard;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;
using Persons.Core.Mappers;

namespace Persons.Infrastructure.implementation
{
    public sealed class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteCreditCard(Guid personId,CreditCardRequestDTO CreditCard)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId},
                new SqlParameter("@Number",System.Data.SqlDbType.NVarChar,50){Value=CreditCard.Number},
                new SqlParameter("@ExpMonth",System.Data.SqlDbType.Int){Value=CreditCard.ExpMonth},
                new SqlParameter("@ExpYear",System.Data.SqlDbType.Int){Value=CreditCard.ExpYear},
            };

            var deletedRows=  await _context.ChangeStateEntityByStoredProcedure
                (PersonOperations.SP_DELETE_CREDIT_CARD, parameters);
            return deletedRows > 0;
        }

        public async Task<bool> DeletePerson(Guid personId)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId}
                };
            var deletedRows= await _context.ChangeStateEntityByStoredProcedure
                (PersonOperations.SP_DELETE_PERSON, parameters);
            return deletedRows > 0;
        }

        public async Task<PasswordDTO> GetPasswordByPersonEmail(string email)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email",System.Data.SqlDbType.NVarChar,255){Value=email}
                };
            return await _context.GetEntityByStoredProcedure<PasswordDTO>(PersonOperations.SP_LOGIN, parameters);
        }

        public async Task<PersonByEmailResponseDTO> GetPersonByEmail(string email)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email",System.Data.SqlDbType.NVarChar, 255){Value=email},
                };
            var rawPersonData = await _context.GetEntitiesByStoredProcedure<PersonByEmailRawResponse>
                (PersonOperations.SP_GET_PERSON_BY_EMAIL,parameters);
            // mapped raw data on Person Data
            var formatedPersonData = rawPersonData.mapToPersonFromSP();
            return formatedPersonData;
        }

        public async Task<int> InsertCreditCard(Guid personId,CreditCardRequestDTO CreditCard)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId},
                new SqlParameter("@Type",System.Data.SqlDbType.NVarChar,50){Value=CreditCard.Type},
                new SqlParameter("@Number",System.Data.SqlDbType.NVarChar,50){Value=CreditCard.Number},
                new SqlParameter("@ExpMonth",System.Data.SqlDbType.Int){Value=CreditCard.ExpMonth},
                new SqlParameter("@ExpYear",System.Data.SqlDbType.Int){Value=CreditCard.ExpYear},
            };

            var insertedRows = await _context.ChangeStateEntityByStoredProcedure
                (PersonOperations.SP_ADD_CREDIT_CARD,parameters);
            return insertedRows;
        }

        public async Task<int> InsertPerson(RegistrationDTO Registration)
        {
            var hash = PasswordGenerator.HashPassword(Registration.Password.NewPassword, out var salt);
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = Registration.FirstName },
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value=Registration.LastName},
                    new SqlParameter("@BirthDay", SqlDbType.NVarChar, 20) { Value = Registration.BirthDay},
                    new SqlParameter("@Telephone", SqlDbType.NVarChar, 20) { Value = Registration.Telephone},
                    new SqlParameter("@HashPassword", SqlDbType.NVarChar, 500) { Value = hash},
                    new SqlParameter("@SaltPassword", SqlDbType.NVarChar, 500) { Value = Convert.ToBase64String(salt) },
                    new SqlParameter("@Email", SqlDbType.NVarChar, 255) { Value = Registration.EmailAddress.Email},
                    new SqlParameter("@EmailPromotion", SqlDbType.Int) { Value = Registration.EmailAddress.EmailPromotion },
                    new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 255) { Value = Registration.Address.AddressLine1 },
                    new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 255) { Value = Registration.Address.AddressLine2},
                    new SqlParameter("@City", SqlDbType.NVarChar, 100) { Value = Registration.Address.City},
                    new SqlParameter("@PostalCode", SqlDbType.NVarChar, 20) { Value = Registration.Address.PostalCode},
                    new SqlParameter("@CountryCode", SqlDbType.NVarChar, 10) { Value = Registration.Address.CountryCode },
                    new SqlParameter("@Type", SqlDbType.NVarChar, 50) { Value = Registration.CreditCard.Type},
                    new SqlParameter("@Number", SqlDbType.NVarChar, 50) { Value = Registration.CreditCard.Number },
                    new SqlParameter("@ExpMonth", SqlDbType.Int) { Value =Registration.CreditCard.ExpMonth },
                    new SqlParameter("@ExpYear", SqlDbType.Int) { Value = Registration.CreditCard.ExpYear}
                };

            var insertedRows = await _context.ChangeStateEntityByStoredProcedure
                (PersonOperations.SP_REGISTER_PERSON, parameters);
            return insertedRows;
        }

        public async Task<int> UpdatePassword(Guid personId, string hash, string salt)
        {
            var parameters = new SqlParameter[]
                {
                    new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=personId},
                    new SqlParameter("@HashPassword",System.Data.SqlDbType.NVarChar,500){Value=hash},
                    new SqlParameter("@SaltPassword",System.Data.SqlDbType.NVarChar,500){Value=salt}
                };
            
            var updatedRows= await _context.ChangeStateEntityByStoredProcedure
                (PersonOperations.SP_CHANGE_PASSWORD, parameters);
            return updatedRows;
        }
    }
}
