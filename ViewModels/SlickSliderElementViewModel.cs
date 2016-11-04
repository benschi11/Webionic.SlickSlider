using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Webionic.SlickGalleryElement.Models;

namespace Webionic.SlickGalleryElement.ViewModels
{
    public class SlickSliderElementViewModel
    {
        public string SliderId { get; set; }
        public SlickSliderConfig Config { get; set; }

        public IList<ContentItem> ContentItems { get; set; }
    }
}