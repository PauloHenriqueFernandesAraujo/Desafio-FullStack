using System.Web.Http;

namespace DesafioFULL.tools.annotations
{
    public class FullRoutePrefixAttribute : RoutePrefixAttribute
    {
        public FullRoutePrefixAttribute() : base("api") { }

        public FullRoutePrefixAttribute(string prefix) : base("api/" + prefix) { }
    }
}