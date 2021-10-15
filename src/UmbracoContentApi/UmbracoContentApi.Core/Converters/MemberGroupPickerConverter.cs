using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Services;

namespace UmbracoContentApi.Core.Converters
{
    public class MemberGroupPickerConverter : IConverter
    {
        private readonly IMemberGroupService _memberGroupService;

        public MemberGroupPickerConverter(IMemberGroupService memberGroupService)
        {
            _memberGroupService = memberGroupService;
        }

        public string EditorAlias => "Umbraco.MemberGroupPicker";

        public object? Convert(object value, Dictionary<string, object>? options = null)
        {
            var values = (value.ToString() ?? string.Empty).Split(',').Select(int.Parse).ToList();
            return !values.Any() ? null : _memberGroupService.GetByIds(values).Select(x => x.Name);
        }
    }
}