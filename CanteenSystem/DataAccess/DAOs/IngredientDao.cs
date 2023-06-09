﻿using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Model;

namespace EfcDataAccess.DAOs;

public class IngredientDao : IIngredientDao
{
    private readonly DataContext context;
    
    public IngredientDao(DataContext context)
    {
        this.context = context;
    }
    
    public async Task<Ingredient> CreateAsync(Ingredient ingredient)
    {
        EntityEntry<Ingredient> added = await context.Ingredients.AddAsync(ingredient);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task UpdateAsync(Ingredient ingredient)
    {
        context.Ingredients.Update(ingredient);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ingredient>> GetAsync()
    {
        IEnumerable<Ingredient> list = context.Ingredients.ToList();
        return list;
    }

    public async Task<Ingredient?> GetByIdAsync(int id)
    {
        Ingredient? found = await context.Ingredients
            .AsNoTracking()
            .Include(i => i.Allergens)
            .SingleOrDefaultAsync(post => post.Id == id);
        return found;
    }

    public async Task DeleteAsync(int id)
    {
        Ingredient? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Ingredient with id {id} not found");
        }

        context.Ingredients.Remove(existing);
        await context.SaveChangesAsync();

    }

    public async Task<Ingredient?> GetByNameAsync(string name)
    {
        Ingredient? found = await context.Ingredients
            .AsNoTracking()
            .Include(i => i.Allergens)
            .SingleOrDefaultAsync(post => post.Name == name);
        return found;
    }
}