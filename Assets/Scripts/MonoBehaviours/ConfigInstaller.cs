using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using Leopotam.Ecs;

public class ConfigInstaller : MonoBehaviour
{
    private const string _fileName = "conf.xml";
    private List<ResourceInteger> _resources = new List<ResourceInteger>();
    private ResourcesFeature _resourcesFeature;

    private void Start()
    {
        string ResourceName = null;
        int ResourceAmount = 0;

        string path = Application.streamingAssetsPath + "/" + _fileName;

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(path);

        XmlElement xRoot = xDoc.DocumentElement;
        if(xRoot != null)
        {
            foreach(XmlElement xNode in xRoot)
            {
                XmlNode attr = xNode.Attributes.GetNamedItem("name");
                ResourceName = attr?.Value;

                foreach(XmlNode childNode in xNode.ChildNodes)
                {
                    if(childNode.Name == "amount")
                    {
                        ResourceAmount = Convert.ToInt32(childNode.InnerText);
                    }
                }

                foreach(ResourceType type in Enum.GetValues(typeof(ResourceType)))
                {
                    if (ResourceName.Equals(type.ToString()))
                    {
                        var res = new ResourceInteger(type, ResourceAmount);
                        _resources.Add(res);
                    }
                }
            }
        }

        _resourcesFeature = new ResourcesFeature(_resources.ToArray());

        var entity = EcsStartup.world.NewEntity();
        ref var component = ref entity.Get<ResourcesFeatureComponent>();
        component.resourcesFeature = _resourcesFeature;
    }
}
