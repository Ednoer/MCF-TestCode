using BpkbApi.Models;

namespace BpkbApi.Services
{
    public interface ITrBpkbService
    {
        Task<TrBpkb> GetTrBpkb();

        //insert or update if trBpkb is exist
        Task UpsertTrBpkb(RequestTrBpkb trBpkb, string username);
    }
}