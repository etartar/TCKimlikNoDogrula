using System.Globalization;
using System.Threading.Tasks;
using TCKimlikNoDogrula.Models;
using wsKPSPublic;

namespace TCKimlikNoDogrula.PersonService
{
    public class PersonServiceManager : IPersonService
    {
        public async Task<bool> VerifyCid(Citizen citizen)
        {
            return await Verify(citizen);
        }

        private async Task<bool> Verify(Citizen citizen)
        {
            var locale = new CultureInfo("tr-TR", false);
            var kpsPublicSoapClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var result = await kpsPublicSoapClient.TCKimlikNoDogrulaAsync(citizen.CitizenId, citizen.Name.ToUpper(locale), citizen.Surname.ToUpper(locale), citizen.BirthYear);
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
