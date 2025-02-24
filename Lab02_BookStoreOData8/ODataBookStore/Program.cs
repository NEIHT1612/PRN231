using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore;
using ODataBookStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Enable OData parameters to appear properly in Swagger UI
    options.OperationFilter<ODataOperationFilter>();
});
builder.Services.AddDbContext<BookStoreContext>(options =>
                options.UseInMemoryDatabase("InMemory")
            );
builder.Services.AddControllers().AddOData(o => o.Select().Filter()
            .Count().OrderBy().Expand().SetMaxTop(100)
            .AddRouteComponents("odata", GetEdmModel()));
builder.Services.AddRouting();
var app = builder.Build();
//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseODataBatching();
//app.Use((context, next) =>
//{
//    var endpoints = context.GetEndpoint();
//    if (endpoints == null)
//    {
//        return next();
//    }

//    IEnumerable<string> templates;
//    IODataRoutingMetadata metadata = endpoints.Metadata.GetMetadata<IODataRoutingMetadata>();

//    if (metadata != null)
//    {
//        templates = metadata.Template.GetTemplates();
//    }

//    return next();
//});

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.MapControllers();

app.Run();
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Book>("Books");
    builder.EntitySet<Press>("Presses");
    return builder.GetEdmModel();
}