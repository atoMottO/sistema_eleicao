using System.Security.Cryptography;
using EmpregaAI.Services.Interfaces;
using EmpregaAPI.Data;
using EmpregaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpregaAI.Services
{
    public class CurriculoService : ICurriculoService
    {
        private readonly CurriculoContext _context;
        public CurriculoService(CurriculoContext context)
        {
            _context = context;
        }
        public async Task<Curriculo> AdicionaCurriculo(Curriculo curriculo)
        {
            curriculo.Id = new Guid();
            curriculo.Excluido = false;

            _context.Curriculos.Add(curriculo);
            await _context.SaveChangesAsync();
            return curriculo;
        }

        public async Task<List<Curriculo>> ListarCurriculos()
        {
            var lista = await _context.Curriculos.Where(x => x.Excluido != true).ToListAsync();
            if (lista.Count == 0)
            {
                return new List<Curriculo>();
            }

            return lista;
        }

        public async Task<Curriculo> ListarCurriculoPorID(Guid id)
        {
            return await _context.Curriculos.FirstOrDefaultAsync(x => x.Id == id && x.Excluido != true);
        }

        public async Task<Curriculo> AtualizarCurriculo(Curriculo curriculo)
        {
            var c = await ListarCurriculoPorID(curriculo.Id);

            _context.Entry(c).CurrentValues.SetValues(curriculo);

            await _context.SaveChangesAsync();
            return c;

        }
        public async Task<Curriculo> ExcluirCurriculo(Curriculo curriculo)
        {
            var c = await ListarCurriculoPorID(curriculo.Id);

            c.Excluido = true;

            await _context.SaveChangesAsync();
            return c;

        }
    }
}
