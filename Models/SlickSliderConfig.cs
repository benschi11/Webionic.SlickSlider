using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webionic.SlickGalleryElement.Models
{
    public class SlickSliderConfig
    {
        public SlickSliderConfig() {
            LoadDefaultConfig();
        }
        public string SyncedSliderId { get; set; }

        public int SlidesToShow { get; set; }
        public int SlidesToScroll { get; set; }
        public Boolean Dots { get; set; }
        public Boolean FocusOnSelect { get; set; }

        public Boolean AdaptiveHeight { get; set; }
        public Boolean Arrows { get; set; }


        public void LoadDefaultConfig() {
            this.SyncedSliderId = string.Empty;
            this.SlidesToScroll = 1;
            this.SlidesToShow = 1;
            this.Dots = true;
            this.FocusOnSelect = true;
            this.AdaptiveHeight = false;
            this.Arrows = true;
        }
    }
}