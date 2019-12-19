﻿using System.Threading.Tasks;
using Microsoft.MobCAT.Repository.Abstractions;

namespace Microsoft.MobCAT.Repository.InMemory
{
    public class BaseInMemoryRepositoryStore : IRepositoryContext
    {
        protected virtual void OnResetRepositories() { }

        public Task DeleteAsync()
            => Task.Run(OnResetRepositories);

        public Task ResetAsync()
            => Task.Run(OnResetRepositories);

        public Task SetupAsync()
            => Task.Run(OnResetRepositories);

        public void ResetRepositories()
            => OnResetRepositories();
    }
}