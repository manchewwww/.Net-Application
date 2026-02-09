using LoggerMetrics.Dtos;
using LoggerMetrics.Exceptions;

namespace LoggerMetrics.Services;

public interface IPartService
{
	Part Create(Part part);
	IEnumerable<Part> Get();
	Part Get(int id);
}

public class PartService : IPartService
{
	private static readonly string[] PartNames = new[]
	{
		"Widget", "Gadget", "Doohickey", "Thingamajig", "Whatsit"
	};
	public Part Create(Part part)
	{
		var random = new Random();
		if (part.Name == "Error")
		{
			throw new Exception("Simulated server error.");
		}
		return new Part
		{
			Id = random.Next(100, 1000),
			Name = part.Name,
			Price = part.Price
		};
	}
	public IEnumerable<Part> Get()
	{
		var random = new Random();
		return Enumerable.Range(1, 5).Select(index => new Part
		{
			Id = index,
			Name = PartNames[random.Next(PartNames.Length)],
			Price = Math.Round(random.NextDouble() * 100, 2)
		});
	}
	public Part Get(int id)
	{
		if (id < 1 || id > 5)
		{
			throw new NotFoundException($"Part with ID {id} not found.");
		}
		var random = new Random();
		return new Part
		{
			Id = id,
			Name = PartNames[random.Next(PartNames.Length)],
			Price = Math.Round(random.NextDouble() * 100, 2)
		};
	}
}