[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/UmbracoContentApi.Core)](https://www.nuget.org/packages/UmbracoContentApi.Core/)

# Umbraco Content Api

The Umbraco Content Api is a package that enables easy integration of Headless Api functionality into your project.
The package includes converters for all default Umbraco porperty editors and allows developers to add to and replace them at will.

Out of the box easy to use, full DI support and fast.

#### Compatibility
- The Umbraco Content Api 2.0.10 works with Umbraco 8.1.3+
- The Umbraco Content Api 3.0.0+ works with Umbraco 8.7.0+
- The Umbraco Content Api 4.0.0+ works with Umbraco 8.14.0+

#### Basic Usage:
1. Download the package from [NuGet](https://www.nuget.org/packages/UmbracoContentApi.Core/)
2. Install the package
3. Add this key into the web.config and configure your base CDN Url <add key="ContentApi:CdnUrl" value="https://cdn.contentapi.net" />
4. Create an UmbracoApiController
5. Inject the content resolver 
6. Resolve the content

```csharp
public class SampleApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public ContentApiController(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public IHttpActionResult Get(Guid id)
        { 
            IPublishedContent content = Umbraco.Content(id);
            var model = _contentResolver.Value.ResolveContent(content);
            return Ok(model);
        }
    }
```

#### Creating and adding a converter
To create a converter for your custom editor you need to implement the `IConverter` interface.
```csharp
// Converter:
public class SampleConverter : IConverter
    {
        public string EditorAlias => "My.PropertyEditorAlias";

        public object Convert(object value)
        {
            // If the value is already in a json supported format, just return it.
            // Otherwise convert it to a friendly format here.
            return value;
        }
    }
// Composer:
    [ComposeAfter(typeof(UmbracoContentApi.Core.Composers.ConvertersComposer))]
    public class ConverterComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Converters().Append<SampleConverter>();
        }
    }
```

#### Replace an exsisting converter
To replace a converter just add the following to the composer:
```csharp
composition.Converters()
    .Replace<ConverterToReplace, SampleConverter>();
```

#### Sample app login
email: admin@contentapi.comr
password: Password123!

### Changelog

#### 2.0.0

Added options params to all converters.

#### 2.0.10

Added grid editor converters.

#### 4.0.0

Added support for Umbraco MediaPicker 3
