// This file will be auto-generated

using Do.Orm;
using Microsoft.AspNetCore.Mvc;

namespace Do.Test;

[ApiController]
public class EntityController(IServiceProvider _serviceProvider)
{
    public record ByRequest(
        Guid guid = default,
        string @string = default,
        string stringData = default,
        int int32 = default,
        Uri uri = default,
        Status status = default,
        DateTime dateTime = default
    );

    [HttpGet]
    [Route("entities")]
    public List<Entity> By([FromQuery] ByRequest request, [FromQuery] int? take = null, [FromQuery] int? skip = null)
    {
        var target = _serviceProvider.GetRequiredService<Entities>();

        var result = target.By(
            guid: request.guid,
            @string: request.@string,
            stringData: request.stringData,
            int32: request.int32,
            uri: request.uri,
            status: request.status,
            dateTime: request.dateTime,
            take: take,
            skip: skip
        );

        return result;
    }

    [HttpGet]
    [Route("entities/{id}")]
    public Entity Get(Guid id)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>();

        return target.SingleById(id);
    }

    public record NewRequest(
        Guid Guid = default,
        string String = default,
        string StringData = default,
        int Int32 = default,
        Uri Uri = default,
        object Dynamic = default,
        Status Status = default,
        DateTime DateTime = default
    );

    [HttpPost]
    [Route("entities")]
    public Entity New([FromBody] NewRequest request)
    {
        var target = _serviceProvider.GetRequiredService<Entity>();

        return target.With(request.Guid, request.String, request.StringData, request.Int32, request.Uri, request.Dynamic, request.Status, request.DateTime);
    }

    [HttpDelete]
    [Route("entities/{id}")]
    public void Delete([FromRoute] Guid id)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>().SingleById(id);

        target.Delete();
    }

    public record UpdateRequest(
        Guid Guid = default,
        string String = default,
        string StringData = default,
        int Int32 = default,
        Uri Uri = default,
        object Dynamic = default,
        Status Status = default,
        DateTime DateTime = default,
        bool useTransaction = false,
        bool throwError = false
    );

    [HttpPut]
    [Route("entities/{id}")]
    public async Task Update([FromRoute] Guid id, [FromBody] UpdateRequest request)
    {
        var target = _serviceProvider.GetRequiredService<IQueryContext<Entity>>().SingleById(id);

        await target.Update(request.Guid, request.String, request.StringData, request.Int32, request.Uri, request.Dynamic, request.Status, request.DateTime,
            useTransaction: request.useTransaction,
            throwError: request.throwError
        );
    }
}
