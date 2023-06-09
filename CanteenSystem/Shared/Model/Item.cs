﻿using System.Text.Json.Serialization;

namespace Shared.Model;

public class Item
{
    public int Id { get; set; }
    public string name { get; set; }
    [JsonIgnore]
    public ICollection<Ingredient> Ingredients { get; set; }

    public Item(string name, ICollection<Ingredient> ingredients)
    {
        this.name = name;
        Ingredients = ingredients;
    }

    
    //public List<DateTime> Date { get; set; }

    private Item() {}

}