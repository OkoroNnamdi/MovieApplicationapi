using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Entites;
using MovieManagement.Domain.Repository;

namespace MovieManagement.DataAccess.Implementation
{
    public class BiographyRepository:GenericRepository <Biography>,IBiographyRepository
    {
        public BiographyRepository(MovieManagementContext context): base(context)
        {
                
        }
    }
}
