using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Webionic.SlickGalleryElement.Helpers
{
    public static class XmlHelper
    {
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static T Deserialize<T>(string xml) where T : class {
            var xmlserializer = new XmlSerializer(typeof(T));

            T result;

            using (var reader = new StringReader(xml)) {
                result = xmlserializer.Deserialize(reader) as T;
            }

            return result;
        }
    }
}