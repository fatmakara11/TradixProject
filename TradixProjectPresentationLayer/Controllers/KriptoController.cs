// KriptoController.cs
using Microsoft.AspNetCore.Mvc;
using TradixProjectPresentationLayer.Models;
using System.Collections.Generic;
using TradixProject.DataAccessLayer.Repositories;

public class KriptoController : Controller
{
    private readonly IKriptoParaRepository _kriptoParaRepository;

    // Constructor ile repository'i enjekte ediyoruz
    public KriptoController(IKriptoParaRepository kriptoParaRepository)
    {
        _kriptoParaRepository = kriptoParaRepository;
    }

    public IActionResult Index()
    {
        // Repository'den verileri alıyoruz
        List<KriptoPara> kriptoParalar = _kriptoParaRepository.GetAllKriptoParalar();
        return View(kriptoParalar);
    }
}
