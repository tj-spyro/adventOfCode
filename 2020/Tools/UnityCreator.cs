using System.IO.Abstractions;
using Unity;

namespace Tools
{
    public class UnityCreator
    {
        public static IUnityContainer BuildDefaultUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IConsoleTools, ConsoleTools>();
            container.RegisterType<IFileSystem, FileSystem>();
            container.RegisterType<IFileHandler, FileHandler>();
            container.RegisterType<ICookieRequestor, CookieRequestor>();
            container.RegisterType<IPuzzleInput, PuzzleInput>();
            return container;
        }
    }
}