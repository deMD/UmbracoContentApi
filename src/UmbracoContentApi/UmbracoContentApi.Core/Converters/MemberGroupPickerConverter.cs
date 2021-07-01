using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
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
            var values = value.ToString().Split(',').Select(int.Parse);
            return _memberGroupService.GetByIds(values).Select(x => x.Name);
        }
    }
}
