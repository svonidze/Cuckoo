// Sergey Kirichenkov [kirichenkov.sa@gmail.com]

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SBeep.Private.Useful.Cuckoo.Beeper.Imp.Stuff.Help
{
    public class ConfigurationSerializer< T >
    {
        private readonly XmlSerializer _serializer;
        private readonly XmlSerializerNamespaces _namespaces;

        public ConfigurationSerializer()
        {
            _serializer = new XmlSerializer( typeof( T ) );
            _namespaces = CreateEmptyNamespaces();

        }

        public T Deserialize( string input )
        {
            var result = ( T ) _serializer.Deserialize( new StringReader( input ) );
            return result;
        }

        //-------------------------------------------------------------------------------------[]
        public string Serialize( T input )
        {
            using( var writer = new StringWriter() )
            using( var xmlWriter = CreateXmlWriter( writer ) ) {
                _serializer.Serialize(xmlWriter, input, _namespaces);
                return writer.ToString();
            }
        }

        private static XmlWriter CreateXmlWriter( TextWriter writer )
        {
            var settings = new XmlWriterSettings
            {
                Indent = false,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                OmitXmlDeclaration = true,
            };
            return XmlWriter.Create( writer, settings );
        }

        private static XmlSerializerNamespaces CreateEmptyNamespaces()
        {
            var ns = new XmlSerializerNamespaces(new[] { new XmlQualifiedName() });
            //ns.Add( "", "" );
            return ns;
        }
    }
}