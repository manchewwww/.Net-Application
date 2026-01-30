using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    public static class PartController
    {
        const string Path = "parts";

        public static void MapPartEndpoints(this WebApplication app)
        {
            app.MapPost($"/{Path}", (PartDto part, PartService service) =>
            {
                return service.AddPart(part);
            });

            app.MapGet($"/{Path}", (PartService service) =>
            {
                return service.GetAllParts();
            });

            app.MapGet($"/{Path}/{{id:int}}", (int id, PartService service) =>
            {
                return service.GetPartById(id);
            });

            app.MapPut($"/{Path}/{{id:int}}", (int id, PartDto part, PartService service) =>
            {
                part.Id = id;
                return service.UpdatePart(part);
            });
        }
    }
}
