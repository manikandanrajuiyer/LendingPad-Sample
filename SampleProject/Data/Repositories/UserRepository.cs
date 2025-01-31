﻿using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDocumentSession _documentSession;

        public UserRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<User> Get(UserTypes? userType = null, string name = null, string email = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<User, UsersListIndex>();

            var hasFirstParameter = false;
            if (userType != null)
            {
                query = query.WhereEquals("Type", (int)userType);
                hasFirstParameter = true;
            }

            if (name != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Name:*{name}*");
            }

            if (email != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("Email", email);
            }
            return query?.ToList();
        }

        public IEnumerable<User> Get(string tag)
        {
            var query = _documentSession.Advanced.DocumentQuery<User, UsersListIndex>();

            // is it a right way to filter condisering performance of RavenDB?
            // is there a better way?
            return query.ToList().Where(user => user.Tags.Any(tags => string.Equals(tags, tag, StringComparison.OrdinalIgnoreCase)));
        }
      

        public void DeleteAll()
        {
            base.DeleteAll<UsersListIndex>();
        }
    }
}