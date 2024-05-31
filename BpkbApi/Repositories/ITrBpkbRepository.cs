using System.Threading.Tasks;
using BpkbApi.Models;

namespace BpkbApi.Repositories
{
    public interface ITrBpkbRepository
    {
        Task<TrBpkb> GetTrBpkb();

        //insert or update if trBpkb is exist
        Task UpsertTrBpkb(TrBpkb trBpkb, string username);
    }
}
