
using Application.Mappers.Contracts;
using Application.ViewModels;
using Domain.Models;

namespace Application.Mappers.Mapper
{
    public class ClinicaMapper : IClinicaMapper
    {
        public ClinicaViewModel MapClinica(ClinicaModel clinicaModel)
        {
            var clinicaViewModel = new ClinicaViewModel
            {
                idClinica = clinicaModel.ID_CLINICA,
                CreatedAt = clinicaModel.CREATED_AT,
                UpdatedAt = clinicaModel.UPDATED_AT,
                nameClinica = clinicaModel.NAME_CLINICA,
                descriptionClinica = clinicaModel.DESC_CLINICA,
                colorPrincipal = clinicaModel.COLOR_PRINCIPAL,
                colorSecundary = clinicaModel.COLOR_SECUNDARY,
                logoClinica = clinicaModel.LOGO_CLINICA,
                typeClinica = clinicaModel.TYPE_CLINICA,
            };
            return clinicaViewModel;
        }
        public ClinicaModel MapClinicaInsert(ClinicaViewModel clinicaModel)
        {
            var clinicaViewModel = new ClinicaModel
            {
                ID_CLINICA = clinicaModel.idClinica,
                CREATED_AT = clinicaModel.CreatedAt,
                UPDATED_AT = clinicaModel.UpdatedAt,
                NAME_CLINICA = clinicaModel.nameClinica,
                DESC_CLINICA = clinicaModel.descriptionClinica,
                COLOR_PRINCIPAL = clinicaModel.colorPrincipal,
                COLOR_SECUNDARY = clinicaModel.colorSecundary,
                LOGO_CLINICA = clinicaModel.logoClinica,
                TYPE_CLINICA = clinicaModel.typeClinica,
            };
            return clinicaViewModel;
        }
    }
}
