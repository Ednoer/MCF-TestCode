using System.Threading.Tasks;
using BpkbApi.Models;

namespace BpkbApi.Repositories
{
    public interface ITrBpkbRepository
    {
        Task<TrBpkb> GetTrBpkb();
        Task UpsertTrBpkb(TrBpkb trBpkb);
    }
}
