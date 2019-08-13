using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoContentApi.Converters;

namespace UmbracoContentApi.Composers
{
    internal class ConvertersComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IConverter, TextBoxConverter>();
            composition.Register<IConverter, TextAreaConverter>();
            composition.Register<IConverter, TinyMceConverter>();
            composition.Register<IConverter, MediaPickerConverter>();
            composition.Register<IConverter, ImageCropperConverter>();
            composition.Register<IConverter, ContentPickerConverter>();
            composition.Register<IConverter, MultiUrlPickerConverter>();
            composition.Register<IConverter, IntegerConverter>();
            composition.Register<IConverter, NestedContentConverter>();
            composition.Register<IConverter, LabelConverter>();
            composition.Register<IConverter, UploadFieldConverter>();
        }
    }
}