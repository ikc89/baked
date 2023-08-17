// This file will be auto-generated

using Do.Orm;
using Microsoft.AspNetCore.Mvc;

namespace Do.Test;

[ApiController]
public class EntityController
{
    readonly IServiceProvider _serviceProvider;

    public EntityController(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    [HttpGet]
    [Route("entities")]
    public List<Entity> By([FromQuery] string @string = default)
    {
        var target = _serviceProvider.GetRequiredService<Entities>();

        return target.By(@string);
    }

    [HttpGet]
    [Route("entities/{id}")]
    public Entity Get(Guid id)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>();

        return target.SingleById(id);
    }

    public record NewRequest(Guid Guid, string String, string StringData, int Int32, Uri Uri, object Dynamic);

    [HttpPost]
    [Route("entities")]

    public Entity New([FromBody] NewRequest request)
    {
        var target = _serviceProvider.GetRequiredService<Entity>();

        return target.With(request.Guid, request.String, request.StringData, request.Int32, request.Uri, request.Dynamic);
    }

    [HttpDelete]
    [Route("entities/{id}")]
    public void Delete([FromRoute] Guid id)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>().SingleById(id);

        target.Delete();
    }

    public record UpdateRequest(Guid Guid, string String, string StringData, int Int32, Uri Uri, object Dynamic,
        bool useTransaction = false,
        bool throwError = false
    );

    [HttpPut]
    [Route("entities/{id}")]
    public async Task Update([FromRoute] Guid id, [FromBody] UpdateRequest request)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>().SingleById(id);

        await target.Update(request.Guid, request.String, request.StringData, request.Int32, request.Uri, request.Dynamic,
            useTransaction: request.useTransaction,
            throwError: request.throwError
        );
    }
}