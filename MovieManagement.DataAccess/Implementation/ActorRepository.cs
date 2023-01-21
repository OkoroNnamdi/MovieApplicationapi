﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Entites;
using MovieManagement.Domain.Repository;

namespace MovieManagement.DataAccess.Implementation
{
    public  class ActorRepository:GenericRepository<Actor>,IActorRepository
    {
        public ActorRepository(MovieManagementContext context) : base(context)
        {

        }

        public IEnumerable<Actor> GetActorWithMovie()
        {
            throw new NotImplementedException();
        }
    }
}
