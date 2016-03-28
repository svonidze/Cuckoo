namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class ConfigurationSerializer<T>
    {
        private readonly XmlSerializer _serializer;

        private readonly XmlSerializerNamespaces _namespaces;

        public ConfigurationSerializer()
        {
            this._serializer = new XmlSerializer(typeof(T));
            this._namespaces = CreateEmptyNamespaces();
        }

        public T Deserialize(string input)
        {
            var result = (T)this._serializer.Deserialize(new StringReader(input));
            return result;
        }

        public string Serialize(T input)
        {
            using (var writer = new StringWriter())
            using (XmlWriter xmlWriter = CreateXmlWriter(writer))
            {
                this._serializer.Serialize(xmlWriter, input, this._namespaces);
                return writer.ToString();
            }
        }

        private static XmlWriter CreateXmlWriter(TextWriter writer)
        {
            var settings = new XmlWriterSettings
                               {
                                   Indent = false, 
                                   NamespaceHandling = NamespaceHandling.OmitDuplicates, 
                                   OmitXmlDeclaration = true, 
                               };
            return XmlWriter.Create(writer, settings);
        }

        private static XmlSerializerNamespaces CreateEmptyNamespaces()
        {
            var ns = new XmlSerializerNamespaces(new[] { new XmlQualifiedName() });

            // ns.Add( "", "" );
            return ns;
        }
    }
}