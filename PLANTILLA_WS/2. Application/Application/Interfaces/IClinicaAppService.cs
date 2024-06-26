using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IClinicaAppService : IDisposable
    {
        public ClinicaViewModel GetClinicaById(int id);
        public ClinicaViewModel RegisterClinica(ClinicaViewModel clinicaViewModel);
        public ClinicaViewModel UpdateClinica(ClinicaViewModel clinicaViewModel);
        public int DeleteClinica(int id);
    }
}
