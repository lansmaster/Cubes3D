using Leopotam.Ecs;
using System.Linq;
using System.Xml.Linq;

sealed class ConfigSaveSystem : IEcsDestroySystem
{
    private const string _fileName = "conf.xml";

    private readonly EcsFilter<ResourcesFeatureComponent> _featureFilter = null;

    public void Destroy()
    {
        // получить путь к файлу

        XDocument xDoc = XDocument.Load(_fileName);

        foreach (var i in _featureFilter)
        {
            ref var feature = ref _featureFilter.Get1(i);

            var res = xDoc.Element("resources")?.Elements("resource").FirstOrDefault(res => res.Attribute("name")?.Value == "Coin");

            if (res != null)
            {
                var amount = res.Element("amount");
                if (amount != null)
                    amount.Value = feature.resourcesFeature.GetResourceValueString(ResourceType.Coin);

                xDoc.Save(_fileName);
            }
        }
    }
}
