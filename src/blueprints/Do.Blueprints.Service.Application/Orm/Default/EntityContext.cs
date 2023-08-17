﻿using ISession = NHibernate.ISession;

namespace Do.Orm.Default;

public class EntityContext<TEntity> : IEntityContext<TEntity>
{
    readonly ISession _session;

    public EntityContext(ISession session) =>
        _session = session;

    public TEntity Insert(TEntity entity)
    {
        _session.Save(entity);

        return entity;
    }

    public void Delete(TEntity entity)
    {
        _session.Delete(entity);
    }
}