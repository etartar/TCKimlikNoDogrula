using System.Threading.Tasks;
using TCKimlikNoDogrula.Models;

namespace TCKimlikNoDogrula.PersonService
{
    public interface IPersonService
    {
        Task<bool> VerifyCid(Citizen citizen);
    }
}
