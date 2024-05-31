using System;
using BpkbApi.Data;
using BpkbApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BpkbApi.Repositories
{
    public class TrBpkbRepository : ITrBpkbRepository
    {
        private readonly BpkbContext _context;

        public TrBpkbRepository(BpkbContext context)
        {
            _context = context;
        }

        public async Task<TrBpkb> GetTrBpkb()
        {
            return await _context.TrBpkbs.FirstOrDefaultAsync();
        }

        public async Task UpsertTrBpkb(TrBpkb trBpkb, string username)
        {
            var existingTrBpkb = await _context.TrBpkbs
            .FirstOrDefaultAsync(b => b.AgreementNumber == trBpkb.AgreementNumber);

            if (existingTrBpkb != null)
            {
                existingTrBpkb.BpkbNo = trBpkb.BpkbNo;
                existingTrBpkb.BranchId = trBpkb.BranchId;
                existingTrBpkb.BpkbDate = trBpkb.BpkbDate;
                existingTrBpkb.FakturNo = trBpkb.FakturNo;
                existingTrBpkb.FakturDate = trBpkb.FakturDate;
                existingTrBpkb.LocationId = trBpkb.LocationId;
                existingTrBpkb.PoliceNo = trBpkb.PoliceNo;
                existingTrBpkb.BpkbDateIn = trBpkb.BpkbDateIn;
                existingTrBpkb.CreatedBy = username;
                existingTrBpkb.CreatedOn = trBpkb.CreatedOn;
                existingTrBpkb.LastUpdatedBy = username;
                existingTrBpkb.LastUpdatedOn = DateTime.UtcNow;

                _context.TrBpkbs.Update(existingTrBpkb);
            }
            else
            {
                trBpkb.CreatedBy = username;
                trBpkb.CreatedOn = DateTime.UtcNow;
                trBpkb.LastUpdatedBy = username;
                trBpkb.LastUpdatedOn = DateTime.UtcNow;

                _context.TrBpkbs.Add(trBpkb);
            }

            await _context.SaveChangesAsync();
        }
    }
}

