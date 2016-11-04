using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Webionic.SlickGalleryElement.Models;

namespace Webionic.SlickGalleryElement.ViewModels
{
    public class SlickSliderEditorViewModel
    {
        public string SliderId { get; set; }
        public SlickSliderConfig Config { get; set; }

        public string ContentItemIds { get; set; }
        public IList<ContentItem> ContentItems { get; set; }
    }
}