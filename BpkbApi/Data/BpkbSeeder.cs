using Microsoft.EntityFrameworkCore;
using BpkbApi.Models;
using System;

namespace BpkbApi.Data
{
    public class DataSeeder
    {
        private readonly BpkbContext _context;

        public DataSeeder(BpkbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.Migrate();

            if (!_context.MsStorageLocations.Any())
            {
                _context.MsStorageLocations.AddRange(
                    new MsStorageLocation { LocationId = "LOC1", LocationName = "Warehouse A" },
                    new MsStorageLocation { LocationId = "LOC2", LocationName = "Warehouse B" },
                    new MsStorageLocation { LocationId = "LOC3", LocationName = "Warehouse C" }
                );
                _context.SaveChanges();
            }

            if (!_context.MsUsers.Any())
            {
                _context.MsUsers.AddRange(
                    new MsUser { UserName = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), IsActive = true },
                    new MsUser { UserName = "user1", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), IsActive = true },
                    new MsUser { UserName = "user2", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), IsActive = false }
                );
                _context.SaveChanges();
            }
        }
    }
}
