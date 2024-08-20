﻿using Gestor.Domain.Entities;

namespace Gestor.Repository.Interfaces
{
    public interface IAccountRepository 
    {
        void Add(Account account);

        void Update(Account entity);

        void Delete(Account entity);

        Task<IEnumerable<Account>> FindAll(int establishmentId, int offset = 0, int limit = 50);

        Task<Account?> FindById(int id);

        Task<bool> SaveChangeAsync();
    }
}
