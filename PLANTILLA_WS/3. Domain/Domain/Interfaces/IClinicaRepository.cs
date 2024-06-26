
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IClinicaRepository
    {
        public ClinicaModel GetClinicaById(int id);
        public ClinicaModel RegisterClinica(ClinicaModel clinicaModel);
        public ClinicaModel UpdateClinica(ClinicaModel clinicaModel);
        public int DeleteClinica(int id);
    }
}
