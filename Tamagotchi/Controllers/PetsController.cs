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

    // localhost:5001/pets/1
    [HttpGet("/pets/{id}")] // dynamic routing 
    public ActionResult Show(int id)
    {
      Pet specifiedPet = Pet.Find(id);
      return View(specifiedPet);
    }

    //[HttpPost("/pets/{id}/feed")]
    //[HttpPost("/pets/{id}/attention")]
    //[HttpPost("/pets/{id}/rest")]        
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
      return RedirectToAction("Show", new { id });
      // ALTERNATIVE APPROACH: return View(foundPet);
    }
  }
}

