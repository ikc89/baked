using Do.Architecture;

namespace Do.Test.Blueprints.Service.Greeting.WelcomePage;

public class WelcomePageGreeting : IFeature
{
    public string Path { get; }

    public WelcomePageGreeting(string path)
    {
        Path = path;
    }

    public void Configure(LayerConfigurator configurator)
    {
        configurator.ConfigureApplicationBuilder(app =>
        {
            app.UseWelcomePage(Path);
        });
    }
}
