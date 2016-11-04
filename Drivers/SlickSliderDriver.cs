using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Webionic.SlickGalleryElement.Elements;
using Webionic.SlickGalleryElement.Models;
using Webionic.SlickGalleryElement.ViewModels;
using ContentItem = Orchard.Layouts.Elements.ContentItem;
using XmlHelper = Webionic.SlickGalleryElement.Helpers.XmlHelper;

namespace Webionic.SlickGalleryElement.Drivers
{
    public class SlickSliderDriver : ElementDriver<SlickSlider>
    {
        private readonly IContentManager _contentManager;
        public SlickSliderDriver(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        protected override EditorResult OnBuildEditor(SlickSlider element, ElementEditorContext context)
        {
            var viewModel = new SlickSliderEditorViewModel();
            var editor = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.SlickSlider", Model: viewModel);

            if (context.Updater != null)
            {
                context.Updater.TryUpdateModel(viewModel, context.Prefix, null, null);
                element.MediaItemIds = ContentItem.Deserialize(viewModel.ContentItemIds);
                element.SliderId = viewModel.SliderId;
                element.Config = XmlHelper.Serialize(viewModel.Config);
            }

            var contentItemIds = element.MediaItemIds;
            var layoutPart = context.Content;
            var layoutId = layoutPart != null ? layoutPart.Id : 0;

            viewModel.ContentItems = GetContentItems(RemoveCurrentContentItemId(contentItemIds, layoutId)).ToArray();
            viewModel.SliderId = element.SliderId;
            viewModel.Config = GetConfigObjectFromString(element.Config);

            return Editor(context, editor);
        }

        protected override void OnDisplaying(SlickSlider element, ElementDisplayingContext context)
        {
            var viewModel = new SlickSliderElementViewModel();
            var contentItemIds = RemoveCurrentContentItemId(element.MediaItemIds, context.Content.Id);
            var contentItems = GetContentItems(contentItemIds).ToArray();
            viewModel.ContentItems = contentItems;
            viewModel.SliderId = element.SliderId;

            viewModel.Config = GetConfigObjectFromString(element.Config);

            context.ElementShape.ViewModel = viewModel;
        }

        protected IEnumerable<Orchard.ContentManagement.ContentItem> GetContentItems(IEnumerable<int> ids)
        {
            return _contentManager.GetMany<IContent>(ids, VersionOptions.Published, QueryHints.Empty).Select(x => x.ContentItem);
        }

        // The user can't pick the content that will host the selected content to prevent an infinite loop / stack overflow.
        protected IEnumerable<int> RemoveCurrentContentItemId(IEnumerable<int> ids, int currentId)
        {
            return ids.Where(x => x != currentId);
        }

        protected SlickSliderConfig GetConfigObjectFromString(string xml) {

            if (string.IsNullOrEmpty(xml))
                return new SlickSliderConfig();

            return XmlHelper.Deserialize<SlickSliderConfig>(xml);



        }
    }
}