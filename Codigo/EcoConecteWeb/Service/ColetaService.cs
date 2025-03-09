using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;

public class ColetaService : IColetaService
{
    private readonly EcoConecteContext context;

    public ColetaService(EcoConecteContext context)
    {
        this.context = context;
    }

    public uint Create(Coleta coleta)
    {
        context.Add(coleta);
        context.SaveChanges();
        return coleta.Id;
    }

    public void Delete(uint id)
    {
        var coleta = context.Coletas.FirstOrDefault(c => c.Id == id);
        if (coleta != null)
        {
            context.Coletas.Remove(coleta);
            context.SaveChanges();
        }
    }

    public void Update(Coleta coleta)
    {
        context.Update(coleta);
        context.SaveChanges();
    }

    public IEnumerable<Coleta> GetAll()
    {
        return context.Coletas.AsNoTracking();
    }

    public Coleta? GetById(uint id)
    {
        return context.Coletas.Find(id);
    }

    public async Task<Coleta> GetByIdAsync(uint id)
    {
        var coleta = await context.Coletas.FindAsync(id);
        if (coleta == null)
        {
            throw new FileNotFoundException("Coleta não encontrada.");
        }

        return coleta;
    }

    public IEnumerable<Coleta> GetByLagradouro(string lagradouro)
    {
        return context.Coletas
            .Where(c => c.Logradouro.StartsWith(lagradouro))
            .OrderBy(c => c.Logradouro)
            .ToList();
    }

    public void Edit(Coleta coleta)
    {
        context.Update(coleta);
        context.SaveChanges();
    }

    public IEnumerable<Coleta> GetByCep(string cep)
    {
        return context.Coletas.Where(c => c.Cep == cep).ToList();
    }

    public IEnumerable<Coleta> GetByCooperativaId(uint idCooperativa)
    {
        return context.Coletas
            .AsNoTracking()
            .Where(c => c.IdCooperativa == idCooperativa)
            .ToList();
    }

    public async Task<bool> UpdateAsync(Coleta coleta)
    {
        context.Coletas.Update(coleta);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(uint id)
    {
        var coleta = await context.Coletas.FindAsync(id);
        if (coleta == null)
        {
            return false;
        }

        context.Coletas.Remove(coleta);
        await context.SaveChangesAsync();
        return true;
    }
}
