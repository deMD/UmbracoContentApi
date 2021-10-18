[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/UmbracoContentApi.Core)](https://www.nuget.org/packages/UmbracoContentApi.Core/)

# Umbraco Content Api

The Umbraco Content Api is a package that enables easy integration of Headless Api functionality into your project.
The package includes converters for all default Umbraco porperty editors and allows developers to add to and replace them at will.

Out of the box easy to use, full DI support and fast.

#### Compatibility
- The Umbraco Content Api 2.0.10 works with Umbraco 8.1.3+
- The Umbraco Content Api 3.0.0+ works with Umbraco 8.7.0+
- The Umbraco Content Api 4.0.0+ works with Umbraco 8.14.0+
- The Umbraco Content Api 9.2.0+ works with Umbraco 9.0.0+

#### Basic Usage:
1. Download the package from [NuGet](https://www.nuget.org/packages/UmbracoContentApi.Core/)
2. Install the package
3. Create an UmbracoApiController
4. Inject the content resolver 
5. Resolve the content

```csharp
[Route("api/content")]
    public class ContentApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly IPublishedContentQuery _publishedContent;

        public ContentApiController(
            Lazy<IContentResolver> contentResolver, IPublishedContentQuery publishedContent)
        {
            _contentResolver = contentResolver;
            _publishedContent = publishedContent;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var content = _publishedContent.Content(id);
            return Ok(_contentResolver.Value.ResolveContent(content));
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
    public void Compose(IUmbracoBuilder builder)
        {
            builder.Converters().Append<SampleConverter>();
        }
```

#### Replace an exsisting converter
To replace a converter just add the following to the composer:
```csharp
builder.Converters()
    .Replace<ConverterToReplace, SampleConverter>();
```

#### Sample app login
email: admin@contentapi.com
password: Password123!

### Changelog

#### 2.0.0

Added options params to all converters.

#### 2.0.10

Added grid editor converters.

#### 4.0.0

Added support for Umbraco MediaPicker 3

#### 9.2.0

Added official support for Umbraco 9

Added default BlocklistConverter. 
The BlockListConverter will use the default converter if no specific converter is specified for the block's element type.

Migrated to Github Actions for package releases.
