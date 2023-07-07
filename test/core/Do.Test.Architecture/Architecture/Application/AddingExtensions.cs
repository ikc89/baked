namespace Do.Test.Architecture.Application;

public class AddingExtensions : Spec
{
    [Test]
    public void Layer_is_added_without_any_options()
    {
        var build = GiveMe.ABuild();
        var layer1 = MockMe.ALayer();
        var layer2 = MockMe.ALayer();

        var app = build.As(app =>
        {
            app.Layers.Add(layer1);
            app.Layers.Add(layer2);
        });

        app.Run();

        layer1.VerifyInitialized();
        layer2.VerifyInitialized();
    }

    [Test]
    public void Feature_is_added_to_configure_layers()
    {
        var build = GiveMe.ABuild();
        var layer = MockMe.ALayer();
        var feature1 = MockMe.AFeature();
        var feature2 = MockMe.AFeature();

        var app = build.As(app =>
        {
            app.Layers.Add(layer);

            app.Features.Add(feature1);
            app.Features.Add(feature2);
        });

        app.Run();

        feature1.VerifyInitialized();
        feature2.VerifyInitialized();
    }

    [Test]
    public void Feature_configures_target_configurations_of_the_layers()
    {
        var build = GiveMe.ABuild();
        var target = new object();
        var layer = MockMe.ALayer(target: target);
        var feature = MockMe.AFeature();

        var app = build.As(app =>
        {
            app.Layers.Add(layer);

            app.Features.Add(feature);
        });

        app.Run();

        feature.VerifyConfigures(target);
    }

    [Test]
    public void Layers_can_provide_multiple_configuration_targets()
    {
        var build = GiveMe.ABuild();
        var layer = MockMe.ALayer(targets: new object[] { "text", 10 });
        var feature = MockMe.AFeature();

        var app = build.As(app =>
        {
            app.Layers.Add(layer);

            app.Features.Add(feature);
        });

        app.Run();

        feature.VerifyConfigures("text");
        feature.VerifyConfigures(10);
    }

    [Test]
    public void Layers_are_skipped_when_they_provide_no_configuration_target()
    {
        var build = GiveMe.ABuild();
        var layer = MockMe.ALayer(targets: new object[0]);
        var feature = MockMe.AFeature();

        var app = build.As(app =>
        {
            app.Layers.Add(layer);

            app.Features.Add(feature);
        });

        app.Run();

        feature.VerifyConfiguresNothing();
    }
}
