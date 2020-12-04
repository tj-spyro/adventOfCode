using System.Collections.Generic;
using System.Linq;
using PassportProcessing.FieldValidators;
using Tools;

namespace PassportProcessing
{
    public class PassportProcessor : IPassportProcessor
    {
        private readonly IPuzzleInput _puzzleInput;
        private readonly IFieldValidationService _fieldValidationService;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/4/input";

        private string _rawData;
        private string RawData => _rawData ??= _puzzleInput.GetPuzzleInput(PuzzleInputUrl);

        private IEnumerable<Passport> _passports;
        private IEnumerable<Passport> Passports => _passports ??= ProcessPassports();

        public PassportProcessor(IPuzzleInput puzzleInput, IFieldValidationService fieldValidationService)
        {
            _puzzleInput = puzzleInput;
            _fieldValidationService = fieldValidationService;
        }

        public int ValidPassports => Passports.Count(p => p.ContainsMandatoryFields);
        public int ValidPassportWithFieldValidation => Passports.Count(p => p.ValidateDataIntegrity(_fieldValidationService));

        private IEnumerable<Passport> ProcessPassports()
        {
            return RawData.Contains("\r\n\r\n")
                ? RawData.Split("\r\n\r\n").Select(Passport.CreatePassport)
                : RawData.Split("\n\n").Select(Passport.CreatePassport);
        }
    }
}