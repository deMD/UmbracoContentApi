using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;

namespace UmbracoContentApi.Converters
{
    internal class MemberGroupPickerConverter : IConverter
    {
        private readonly IMemberGroupService _memberGroupService;

        public MemberGroupPickerConverter(IMemberGroupService memberGroupService)
        {
            _memberGroupService = memberGroupService;
        }

        public string EditorAlias => "Umbraco.MemberGroupPicker";

        public object Convert(object value)
        {
            if (int.TryParse(value.ToString(), out var id))
            {
                return _memberGroupService.GetById(id).Name;
            }

            return null;
        }
    }
}
