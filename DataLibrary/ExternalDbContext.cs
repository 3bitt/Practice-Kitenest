using Kitenest.Data;
using System;

namespace DataLibrary
{
    public class ExternalDbContext
    {

        private readonly KitenestDbContext _context;

        public ExternalDbContext(KitenestDbContext context)
        {
            _context = context;
        }
    }
}
