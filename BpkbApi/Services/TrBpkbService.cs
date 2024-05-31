
using System.ComponentModel.DataAnnotations;
using BpkbApi.Models;
using BpkbApi.Repositories;

namespace BpkbApi.Services
{
    public class TrBpkbService : ITrBpkbService
    {
        private readonly ITrBpkbRepository _trBpkbRepository;

        public TrBpkbService(ITrBpkbRepository trBpkbRepository)
        {
            _trBpkbRepository = trBpkbRepository;
        }

        public async Task<TrBpkb> GetTrBpkb()
        {
            return await _trBpkbRepository.GetTrBpkb();
        }

        public async Task UpsertTrBpkb(RequestTrBpkb trBpkb, string username)
        {
            if (trBpkb == null)
            {
                throw new ArgumentNullException(nameof(trBpkb));
            }

            ValidateTrBpkb(trBpkb);

            var trBpkb_ = new TrBpkb
            {
                AgreementNumber = trBpkb.AgreementNumber,
                BpkbNo = trBpkb.BpkbNo,
                BranchId = trBpkb.BranchId,
                BpkbDate = trBpkb.BpkbDate,
                FakturNo = trBpkb.FakturNo,
                FakturDate = trBpkb.FakturDate,
                LocationId = trBpkb.LocationId,
                PoliceNo = trBpkb.PoliceNo,
                BpkbDateIn = trBpkb.BpkbDateIn,
            };

            await _trBpkbRepository.UpsertTrBpkb(trBpkb_, username);
        }

        private void ValidateTrBpkb(RequestTrBpkb trBpkb)
        {
            var validationContext = new ValidationContext(trBpkb);
            Validator.ValidateObject(trBpkb, validationContext, validateAllProperties: true);
        }
    }
}