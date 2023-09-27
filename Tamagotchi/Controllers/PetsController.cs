using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
  public class PetsController : Controller
  {
    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Pet> pets = Pet.GetAll();
      return View(pets);
    }

    [HttpGet("/pets/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/pets")]
    public ActionResult Create(string petName)
    {
      Pet newlyAdopted = new(petName);
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/passtime")]
    public ActionResult PassTime()
    {
      List<Pet> currentPets = Pet.GetAll();
      foreach(Pet individual in currentPets)
      {
        individual.TimePassDecrementFields();
      }
      // return View("Index", currentPets);
      return RedirectToAction("Index");
    }
    
    [HttpGet("/pets/{id}")] // dynamic routing 
    public ActionResult Show(int id)
    {
      Pet specifiedPet = Pet.Find(id);
      return View(specifiedPet);
    }

    [HttpPost("/pets/{id}")]
    public ActionResult Update(int id, string button)
    {
      Pet foundPet = Pet.Find(id);
      if (button == "feed")
      {
        foundPet.Feed();
      }
      else if (button == "rest")
      {
        foundPet.Sleep();
      }
      else if (button == "attention")
      {
        foundPet.GiveAttention();
      }
      // return RedirectToAction("Show", new { id });
      // ALTERNATIVE APPROACH: 
      return View("Show", foundPet);
    }
  }
}

