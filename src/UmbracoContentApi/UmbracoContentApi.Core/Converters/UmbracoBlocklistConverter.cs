using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class UmbracoBlocklistConverter : IConverter
    {
        private readonly Lazy<IBlockListResolver> _blockListResolver;

        public UmbracoBlocklistConverter(Lazy<IBlockListResolver> blockListResolver)
        {
            _blockListResolver = blockListResolver;
        }

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (!(value is BlockListModel model))
            {
                return null;
            }

            IEnumerable<object> typedValue = model.Select(x => _blockListResolver.Value.ResolveBlockList(x));

            return typedValue;
        }

        public string EditorAlias => "Umbraco.BlockList";
    }
}