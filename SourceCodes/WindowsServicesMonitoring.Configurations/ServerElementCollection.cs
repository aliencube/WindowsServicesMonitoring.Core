﻿using System.Configuration;

namespace Aliencube.WindowsServicesMonitoring.Configurations
{
    /// <summary>
    /// This represents the server element collection entity.
    /// </summary>
    public class ServerElementCollection : ConfigurationElementCollection
    {
        #region Properties

        /// <summary>
        /// Gets the type of the ConfigurationElementCollection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements in the configuration file
        /// when overridden in a derived class.
        /// </summary>
        protected override string ElementName
        {
            get { return "server"; }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Gets or sets the key/value pair element at the specified index location.
        /// </summary>
        /// <param name="index">The index location of the key/value pair element to remove.</param>
        /// <returns>Returns the key/value pair element at the specified index location.</returns>
        public ServerElement this[int index]
        {
            get { return (ServerElement)this.BaseGet(index); }
            set
            {
                if (this.BaseGet(index) != null)
                    this.BaseRemoveAt(index);
                this.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Gets or sets the key/value pair element having the specified key.
        /// </summary>
        /// <param name="key">Key value.</param>
        /// <returns>Returns the key/value pair element having the specified key.</returns>
        public new ServerElement this[string key]
        {
            get { return (ServerElement)this.BaseGet(key); }
            set
            {
                var item = (ServerElement)this.BaseGet(key);
                if (item != null)
                {
                    var index = this.BaseIndexOf(item);
                    this.BaseRemoveAt(index);
                    this.BaseAdd(index, value);
                }
                this.BaseAdd(value);
            }
        }

        #endregion Indexers

        #region Methods

        /// <summary>
        /// Creates a new ConfigurationElement.
        /// </summary>
        /// <returns>Returns a new ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServerElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">ConfigurationElement to return for.</param>
        /// <returns>Returns an Object that acts as the key for the specified ConfigurationElement.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServerElement)element).Name;
        }

        /// <summary>
        /// Adds an key/value pair element to the ConfigurationElementCollection.
        /// </summary>
        /// <param name="element">Item element.</param>
        public void Add(ServerElement element)
        {
            this.BaseAdd(element);
        }

        /// <summary>
        /// Removes all key/value pair element objects from the collection.
        /// </summary>
        public void Clear()
        {
            this.BaseClear();
        }

        /// <summary>
        /// Removes an key/value pair element from the collection.
        /// </summary>
        /// <param name="key">Key value.</param>
        public void Remove(string key)
        {
            this.BaseRemove(key);
        }

        /// <summary>
        /// Removes the key/value pair element at the specified index location.
        /// </summary>
        /// <param name="index">The index location of the key/value pair element to remove.</param>
        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        #endregion Methods
    }
}