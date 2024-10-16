﻿using DataAccess.ModelsDB;
using DataAccessGeneral;
using DomainIdentity;

namespace DataAccessIdentity
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InspireoContext repositoryContext) : base(repositoryContext) 
        {

        }
    }
}