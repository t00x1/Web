﻿using Domain.Interfaces;
using Domain.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace businessLogic.Service
{ 
public class UserService : IUserService
{
    private IRepositoryWrapper _repositoryWrapper;

    public UserService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task<List<User>> GetAll()
    {
        return await _repositoryWrapper.User.FindAll();
    }

    
    public async Task<User> GetById(int id)
    {
        var user = await _repositoryWrapper.User
            .FindByCondition(x => x.IdOfUser == id);
        return user.First();
    }

    public async Task Create(User model)
    {
        await _repositoryWrapper.User.Create(model);
        _repositoryWrapper.Save();
    }

    public async Task Update(User model)
    {
        _repositoryWrapper.User.Update(model);
        _repositoryWrapper.Save();
    }

    public async Task Delete(int id)
    {
        var user = await _repositoryWrapper.User
            .FindByCondition(x => x.IdOfUser == id);

            await _repositoryWrapper.User.Delete(user.First());
        _repositoryWrapper.Save();
    }
    
}
}