using Microsoft.OpenApi.Models;

namespace Infrastructure.Common.Web.ApiExplorer.Swagger
{
    public class SwaggerOptions : OpenApiInfo
    {
        public string VersionName { get; set; } = "v1";
        public string RoutePrefix { get; set; } = "";
    }
}
