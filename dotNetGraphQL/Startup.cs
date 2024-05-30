using dotNetGraphQL.GraphQL;
using dotNetGraphQL.IService;
using dotNetGraphQL.Service;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

namespace dotNetGraphQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddGraphQL(x => SchemaBuilder.New()
                .AddServices(x)
                .AddType<GroupType>()
                .AddType<StudentType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .Create()
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { 
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions { 
                    QueryPath = "/api",
                    Path = "/Playground"
                });
            }

            app.UseGraphQL("/api");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
