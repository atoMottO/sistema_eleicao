using EmpregaAI.Services.Interfaces;
using EmpregaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpregaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurriculoController : ControllerBase
{
    private readonly ICurriculoService _curriculoService;
    public CurriculoController(ICurriculoService curriculoService)
    {
        _curriculoService = curriculoService;
    }
    [HttpPost]
    public async Task<IActionResult> AdicionaCurriculo([FromBody] Curriculo curriculo)
    {
        return Ok(await _curriculoService.AdicionaCurriculo(curriculo));
    }
    [HttpGet]
    public async Task<IActionResult> ListaCurriculos()
    {
        var curriculos = await _curriculoService.ListarCurriculos();
        return Ok(curriculos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarCurriculoPorId(Guid id)
    {
        var curriculo = await _curriculoService.ListarCurriculoPorID(id);

        return Ok(curriculo);
    }

    [HttpPut("Atualizar")]
    public async Task<IActionResult> AtualizarCurriculo([FromBody] Curriculo curriculo)
    {
        var atualizado = await _curriculoService.AtualizarCurriculo(curriculo);

        return Ok(atualizado);
    }

    [HttpPut("Deletar")]
    public async Task<IActionResult> ExcluirCurriculo([FromBody] Curriculo curriculo)
    {
        var excluido = await _curriculoService.ExcluirCurriculo(curriculo);

        return Ok(excluido);
    }
}
