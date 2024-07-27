﻿using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.Entities.Models;

namespace YB.DataAccess.Repositories.EntityFramework
{
    public class EFGuestDal : EfGenericRepositoryDal<Guest>, IGuestDal
    {
        public EFGuestDal(ApplicationDbContext _context) : base(_context)
        {
        }
    }
}
