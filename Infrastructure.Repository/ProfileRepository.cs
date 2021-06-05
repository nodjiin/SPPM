﻿using Infrastructure.Contracts.Repositories;
using Infrastructure.Entities.Contexts;
using Infrastructure.Entities.Models;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(SPPMContext context) : base(context)
        {
        }
    }
}