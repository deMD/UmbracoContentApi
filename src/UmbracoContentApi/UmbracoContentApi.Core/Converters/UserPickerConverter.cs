using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Services;

namespace UmbracoContentApi.Core.Converters
{
    public class UserPickerConverter : IConverter
    {
        private readonly IUserService _userService;

        public UserPickerConverter(IUserService userService)
        {
            _userService = userService;
        }

        public string EditorAlias => "Umbraco.UserPicker";

        public object? Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            return int.TryParse(value.ToString(), out var id) ? _userService.GetUserById(id).Name : null;
        }
    }
}
