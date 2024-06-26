using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Contracts.Context;
using Domain.Interfaces;
using Common.Logs;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly IContextDatabase _context;
        protected readonly ILogger<ExceptionHandler> _logger;

        public ClinicaRepository(ContextDatabase context)
        {
            _context = context;
        }
        public ClinicaModel GetClinicaById(int id)
        {
            return _context.Clinica.Find(id);
        }

        public ClinicaModel RegisterClinica(ClinicaModel clinicaModel)
        {
            clinicaModel.CREATED_AT = DateTime.UtcNow;
            clinicaModel.UPDATED_AT = DateTime.UtcNow;
            _context.Clinica.Add(clinicaModel);
            _context.SaveChanges();
            return clinicaModel;
        }

        public ClinicaModel UpdateClinica(ClinicaModel clinicaModel)
        {
            var existingClinica = _context.Clinica.Find(clinicaModel.ID_CLINICA);
            if (existingClinica == null)
            {
                return null;
            }

            existingClinica.NAME_CLINICA = clinicaModel.NAME_CLINICA;
            existingClinica.DESC_CLINICA = clinicaModel.DESC_CLINICA;
            existingClinica.TYPE_CLINICA = clinicaModel.TYPE_CLINICA;
            existingClinica.COLOR_PRINCIPAL = clinicaModel.COLOR_PRINCIPAL;
            existingClinica.COLOR_SECUNDARY = clinicaModel.COLOR_SECUNDARY;
            existingClinica.LOGO_CLINICA = clinicaModel.LOGO_CLINICA;
            existingClinica.UPDATED_AT = DateTime.UtcNow;

            _context.Entry(existingClinica).Property("NAME_CLINICA").IsModified = true;
            _context.Entry(existingClinica).Property("DESC_CLINICA").IsModified = true;
            _context.Entry(existingClinica).Property("TYPE_CLINICA").IsModified = true;
            _context.Entry(existingClinica).Property("COLOR_PRINCIPAL").IsModified = true;
            _context.Entry(existingClinica).Property("COLOR_SECUNDARY").IsModified = true;
            _context.Entry(existingClinica).Property("LOGO_CLINICA").IsModified = true;
            _context.Entry(existingClinica).Property("UPDATED_AT").IsModified = true;
            _context.SaveChanges();
            return existingClinica;
        }

        public int DeleteClinica(int id)
        {
            var user = _context.Clinica.Find(id);
            if (user != null)
            {
                _context.Clinica.Remove(user);
                return _context.SaveChanges();
            }
            return 0;
        }


    }
}
