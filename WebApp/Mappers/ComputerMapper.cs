using Data.Entities;
using WebApp.Models;

namespace WebApp.Mappers;

public class ComputerMapper
{
    public static Computer FromEntity(ComputerEntity entity)
    {
        return new Computer()
        {
            Id = entity.Id,
            Name = entity.Name,
            Processor = entity.Processor,
            Memory = entity.Memory,
            GraphicsCard = entity.GraphicsCard,
            Manufacturer = entity.Manufacturer,
            ProductionDate = entity.ProductionDate,
        };
    }

    public static ComputerEntity ToEntity(Computer model)
    {
        return new ComputerEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Processor = model.Processor,
            Memory = model.Memory,
            GraphicsCard = model.GraphicsCard,
            Manufacturer = model.Manufacturer,
            ProductionDate = model.ProductionDate,
        };
    }
}