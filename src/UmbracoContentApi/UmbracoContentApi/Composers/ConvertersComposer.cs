using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Resolvers;

namespace UmbracoContentApi.Composers
{
    internal class ConvertersComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IContentResolver, ContentResolver>();

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
            composition.Register<IConverter, ColorPickerConverter>();
            composition.Register<IConverter, DateTimeConverter>();
            composition.Register<IConverter, TagsConverter>();
            composition.Register<IConverter, TrueFalseConverter>();
            composition.Register<IConverter, CheckBoxListConverter>();
            composition.Register<IConverter, DropdownFlexibleConverter>();
            composition.Register<IConverter, RadioButtonListConverter>();
            composition.Register<IConverter, MemberPickerConverter>();
            composition.Register<IConverter, SliderConverter>();
            composition.Register<IConverter, MultipleTextstringConverter>();
            composition.Register<IConverter, MultinodeTreepickerConverter>();
            composition.Register<IConverter, MarkdowneditorConverter>();
            composition.Register<IConverter, MemberGroupPickerConverter>();
            composition.Register<IConverter, UserPickerConverter>();
        }
    }
}