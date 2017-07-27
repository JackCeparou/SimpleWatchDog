using System;
using System.Configuration;

namespace SimpleWatchDog.Configuration
{
    public class WatchDogConfig : ConfigurationSection
    {
        [ConfigurationProperty("watchDogs")]
        public WatchDogElementCollection WatchDogs
        {
            get
            {
                return this["watchDogs"] as WatchDogElementCollection;
            }
        }
    }

    public class WatchDogElement : ConfigurationElement
    {
        [ConfigurationProperty("runningProcessName", IsRequired = true, IsKey = true)]
        public string RunningProcessName
        {
            get
            {
                return this["runningProcessName"] as string;
            }
            set
            {
                this["runningProcessName"] = value;
            }
        }

        [ConfigurationProperty("watchProcessName", IsRequired = true)]
        public string WatchProcessName
        {
            get
            {
                return this["watchProcessName"] as string;
            }
            set
            {
                this["watchProcessName"] = value;
            }
        }

        [ConfigurationProperty("launchPath", IsRequired = true)]
        public string LaunchPath
        {
            get
            {
                return this["launchPath"] as string;
            }
            set
            {
                this["launchPath"] = value;
            }
        }

        [ConfigurationProperty("timer", IsRequired = false, DefaultValue = 1000)]
        public int Timer
        {
            get
            {
                return (int)this["timer"];
            }
            set
            {
                this["timer"] = value;
            }
        }
    }

    public class WatchDogElementCollection : ConfigurationElementCollection
    {
        public WatchDogElement this[object key]
        {
            get
            {
                return base.BaseGet(key) as WatchDogElement;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "watchDog";
            }
        }

        protected override bool IsElementName(string elementName)
        {
            bool isName = false;
            if (!String.IsNullOrEmpty(elementName))
                isName = elementName.Equals("watchDog");
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new WatchDogElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WatchDogElement)element).RunningProcessName;
        }
    }
}