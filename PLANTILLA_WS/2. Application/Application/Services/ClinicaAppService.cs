using Application.Mappers.Contracts;
using Domain.Interfaces;
using Application.Interfaces;
using Application.ViewModels;

namespace Application.Services
{
    public class ClinicaAppService : IClinicaAppService
    {
        private readonly IClinicaRepository _clinicaRepository;
        private readonly IClinicaMapper _clinicaMapper;

        public ClinicaAppService(IClinicaRepository clinicaRepository, IClinicaMapper clinicaMapper)
        {
            _clinicaRepository = clinicaRepository;
            _clinicaMapper = clinicaMapper;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public ClinicaViewModel GetClinicaById(int id)
        {
            var clinica = _clinicaRepository.GetClinicaById(id);
            if (clinica == null)
            {
                return null;
            }
            return _clinicaMapper.MapClinica(clinica);
        }
        public ClinicaViewModel RegisterClinica(ClinicaViewModel clinicaViewModel)
        {
            var clinicaModel = _clinicaMapper.MapClinicaInsert(clinicaViewModel);
            var clinica = _clinicaRepository.RegisterClinica(clinicaModel);
            return _clinicaMapper.MapClinica(clinica);
        }
        public ClinicaViewModel UpdateClinica(ClinicaViewModel clinicaViewModel)
        {
            var clinicaModel = _clinicaMapper.MapClinicaInsert(clinicaViewModel);
            var clinica = _clinicaRepository.UpdateClinica(clinicaModel);
            return _clinicaMapper.MapClinica(clinica);
        }
        public int DeleteClinica(int id)
        {
            return _clinicaRepository.DeleteClinica(id);
        }
    }
}
