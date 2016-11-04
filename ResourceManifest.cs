using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Webionic.SlickGalleryElement
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineStyle("SlickSlider").SetUrl("slick.min.css", "slick.css");

            manifest.DefineScript("SlickSlider").SetUrl("slick.min.js", "slick.js").SetDependencies("jQuery");
        }
    }
}