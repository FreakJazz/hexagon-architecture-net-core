
using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Contracts
{
    public interface IClinicaMapper
    {
        public ClinicaViewModel MapClinica(ClinicaModel clinicaModel);
        public ClinicaModel MapClinicaInsert(ClinicaViewModel clinicaModel);

    }
}
