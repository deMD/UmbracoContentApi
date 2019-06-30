using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    public interface IConverter<in T>
    {
        object Convert(T value);
    }
}
