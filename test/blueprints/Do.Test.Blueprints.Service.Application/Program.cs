using Do.Authentication.FixedToken;
using Do.Test.Orm;

Forge.New
    .Service(
        business: c => c.DomainAssemblies([typeof(Entity).Assembly]),
        authentications:
        [
            c => c.FixedToken(configure: options =>
            {
                options.AddIdentity("Admin", [new TokenClaimProvider()]);
            })
        ],
        authorization: c => c.ClaimBased(policies:
            [
                new("AdminOnly", policy => policy.RequireClaim("Token")),
                new("ManagerOnly", policy => policy.RequireClaim("Manager"))
            ]
        ),
        database: c => c.MySql().ForDevelopment(c.Sqlite()),
        exceptionHandling: ex => ex.Default(typeUrlFormat: "https://do.mouseless.codes/errors/{0}"),
        configure: app => app.Features.AddConfigurationOverrider()
    )
    .Run();