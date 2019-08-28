using Umbraco.Core.Services;

namespace UmbracoContentApi.Core.Converters
{
    internal class UserPickerConverter : IConverter
    {
        private readonly IUserService _userService;

        public UserPickerConverter(IUserService userService)
        {
            _userService = userService;
        }

        public string EditorAlias => "Umbraco.UserPicker";

        public object Convert(object value)
        {
            if (int.TryParse(value.ToString(), out int id))
            {
                return _userService.GetUserById(id).Name;
            }

            return null;
        }
    }
}
