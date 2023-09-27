using System.Collections.Generic;
using System;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public int Food { get; set; } = 50;
    public int Attention { get; set; } = 50;
    public int Rest { get; set; } = 50;

    public string Name { get; set; }

    public int Id { get; } // readonly

    private static List<Pet> _instances = new List<Pet> {};

    public Pet(string petName)
    {
      Name = petName;
      // IsAlive = true;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public void Feed()
    {
      if (Food < 100)
      {
        Food += 10;
        if (Food > 100)
        {
          Food = 100;
        }
      }
    }

    public void Sleep()
    {
      if (Rest < 100)
      {
        Rest += 10;
        if (Rest > 100)
        {
          Rest = 100;
        }
      }
    }

    public void GiveAttention()
    {
      if (Attention < 100)
      {
        Attention += 10;
        if (Attention > 100)
        {
          Attention = 100;
        }
      }
    }

    public void TimePassDecrementFields()
    {
      // Randomizer
      Random rnd = new Random();
      // Set decrement amount for specified property.
      int decrementFood = rnd.Next(1, 10);
      int decrementAttention = rnd.Next(1, 10);
      int decrementRest = rnd.Next(1, 10);
      // Modify needs meter
      Food -= decrementFood;
      Attention -= decrementAttention;
      Rest -= decrementRest;
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}



