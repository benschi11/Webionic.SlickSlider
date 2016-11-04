using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Helpers;
using Orchard.ContentManagement;

namespace Webionic.SlickGalleryElement.Elements
{
    public class SlickSlider : Element
    {
        private const string ConfigName = "SliderConfig";
        private const string SliderIdName = "SliderId";

        public override string Category
        {
            get { return "Media"; }
        }

        public override string ToolboxIcon
        {
            get { return "\uf1c5"; }
        }

        public string SliderId
        {
            get { return this.Retrieve<string>(SliderIdName); }
            set { this.Store(SliderIdName, value); }
        }

        public string Config
        {
            get { return this.Retrieve<string>(ConfigName); }
            set { this.Store(ConfigName, value);}
        }

        public IEnumerable<int> MediaItemIds
        {
            get { return Deserialize(this.Retrieve<string>("MediaItemIds")); }
            set { this.Store("MediaItemIds", Serialize(value)); }
        }

        public static IEnumerable<int> Deserialize(string data)
        {
            if (String.IsNullOrWhiteSpace(data))
                return Enumerable.Empty<int>();

            var query =
                from x in data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                let id = XmlHelper.Parse<int?>(x)
                where id != null
                select id.Value;

            return query;
        }

        public static string Serialize(IEnumerable<int> values)
        {
            return values != null ? String.Join(",", values) : "";
        }
    }
}