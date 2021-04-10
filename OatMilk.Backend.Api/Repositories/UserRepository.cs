using AutoMapper;
using OatMilk.Backend.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Repositories
{
    public interface IUserRepository
    {

    }

    public class UserRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UserRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
