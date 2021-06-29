using System.Collections.Generic;
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

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (int.TryParse(value.ToString(), out var id))
            {
                return _memberGroupService.GetById(id).Name;
            }

            return null;
        }
    }
}
