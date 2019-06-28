namespace DotNetConcept.Toolkit.AspNetCore.Ocelot.Swagger
{
    using System.Collections.Generic;

    public class OcelotSwaggerConfig
    {
	    public OcelotSwaggerConfig()
	    {
		    this.SwaggerEndPoints = new List<SwaggerEndPoint>();
	    }

	    public List<SwaggerEndPoint> SwaggerEndPoints { get; set; }
    }

	public class SwaggerEndPoint
	{
		public string Url { get; set; }
		public string Name { get; set; }
	}
}
