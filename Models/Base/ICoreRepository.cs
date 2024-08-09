using Api.Data.Dtos.AccountDtos;
using Api.Data.Dtos.EstablishmentDtos;
using Api.Data.Dtos.UserDtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Base
{
    public interface ICoreRepository 
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Establishment?> FindEstablishmentById(int id);

        Task<IEnumerable<Establishment>> FindAllEstablishments(int offset = 0, int limit = 50);

        Task<User?> FindUserById(int id);

        Task<IEnumerable<User>> FindAllUsers(int offset = 0, int limit = 50);

        Task<Account?> FindAccountById(int id);

        Task<IEnumerable<Account>> FindAllAccounts(int establishmentId, int offset = 0, int limit = 50);
    }
}
