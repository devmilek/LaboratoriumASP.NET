using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Mappers;

namespace WebApp.Services;

public interface IComputerService
{
    int Add(Computer computer);
    void Delete(int id);
    List<Computer> FindAll();
    Computer? FindById(int id);
    void Update(Computer computer);
    List<OrganizationEntity> FindAllOrganizations();
}

public class EFComputerService : IComputerService
{
    private readonly AppDbContext _context;

    public EFComputerService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Computer computer)
    {
        var e = _context.Computers.Add(ComputerMapper.ToEntity(computer));
        _context.SaveChanges();
        return e.Entity.Id;
    }

    public void Delete(int id)
    {
        ComputerEntity? find = _context.Computers.Find(id);
        if (find != null)
        {
            _context.Computers.Remove(find);
            _context.SaveChanges();
        }
    }

    public List<Computer> FindAll()
    {
        return _context.Computers.Select(e => ComputerMapper.FromEntity(e)).ToList();
    }

    public Computer? FindById(int id)
    {
        var entity = _context.Computers.Include(c => c.Organization).ThenInclude(o => o.Address)
            .FirstOrDefault(c => c.Id == id);
        return entity != null ? ComputerMapper.FromEntity(entity) : null;
    }

    public void Update(Computer computer)
    {
        _context.Computers.Update(ComputerMapper.ToEntity(computer));
        _context.SaveChanges();
    }
    
    public List<OrganizationEntity> FindAllOrganizations()
    {
        return _context.Organizations.ToList();
    }
}