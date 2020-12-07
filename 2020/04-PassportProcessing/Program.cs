using System;
using PassportProcessing.FieldValidators;
using Tools;
using Unity;
using Unity.Injection;

namespace PassportProcessing
{
    class Program
    {
        static void Main()
        {
            var container = BuildUnityContainer();

            var passportProcessor = container.Resolve<IPassportProcessor>();

            Console.WriteLine($"Part 1: {passportProcessor.ValidPassports}");
            Console.WriteLine($"Part 2: {passportProcessor.ValidPassportWithFieldValidation}");
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityCreator.BuildDefaultUnityContainer();
            container.RegisterType<IFieldValidator, YearFieldValidator>(nameof(IFieldValidationService.BirthYear),
                new InjectionConstructor(1920, 2002));
            container.RegisterType<IFieldValidator, YearFieldValidator>(nameof(IFieldValidationService.IssueYear),
                new InjectionConstructor(2010, 2020));
            container.RegisterType<IFieldValidator, YearFieldValidator>(nameof(IFieldValidationService.ExpirationYear),
                new InjectionConstructor(2020, 2030));
            container.RegisterType<IFieldValidator, HeightFieldValidator>(nameof(IFieldValidationService.Height));
            container.RegisterType<IFieldValidator, HairColourValidator>(nameof(IFieldValidationService.HairColour));
            container.RegisterType<IFieldValidator, EyeColourValidator>(nameof(IFieldValidationService.EyeColour));
            container.RegisterType<IFieldValidator, PassportIdValidator>(nameof(IFieldValidationService.PassportId));
            container.RegisterType<IFieldValidationService, FieldValidationService>();
            container.RegisterType<IPassportProcessor, PassportProcessor>();
            return container;
        }
    }
}
