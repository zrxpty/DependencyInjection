using DependencyInjection.App.DIContainer;
using Services.CatService;

var container = new DIContainer();

container.AddServiceSingleton<ICatService, CatService>();

var service = container.GetService<ICatService>();

Console.WriteLine(service.Meow());

