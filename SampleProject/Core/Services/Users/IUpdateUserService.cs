﻿using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface IUpdateUserService
    {
        void Update(User user, string name, string email, int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags);
    }
}