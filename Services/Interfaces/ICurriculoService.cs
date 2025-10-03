using EmpregaAPI.Models;

namespace EmpregaAI.Services.Interfaces
{
    public interface ICurriculoService
    {
        Task<Curriculo> AdicionaCurriculo(Curriculo curriculo);
        Task<List<Curriculo>> ListarCurriculos();
        Task<Curriculo> ListarCurriculoPorID(Guid id);
        Task<Curriculo> AtualizarCurriculo(Curriculo curriculo);
        Task<Curriculo> ExcluirCurriculo(Curriculo curriculo);
    }
}
