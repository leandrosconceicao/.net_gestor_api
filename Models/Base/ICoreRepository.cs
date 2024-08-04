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

        Task<ReadEstablishmentDto?> FindEstablishmentById(int id);

        Task<IEnumerable<ReadEstablishmentDto>> FindAllEstablishments(int offset = 0, int limit = 50);

        Task<ReadUserDto?> FindUserById(int id);

        Task<IEnumerable<ReadUserDto>> FindAllUsers(int offset = 0, int limit = 50);
    }
}
