using Bibly.Application.Common.Exceptions;
using Bibly.Core.Dtos;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class CommonStepDefinition
    {
        public static Exception? Exception;


        [Then("une errreur de validation est retournee")]
        public void ThenUneErrreurDeValidationEstRetournee()
        {
            Exception.Should().NotBeNull();
            Exception.Should().BeOfType<ValidationException>();
        }
    }
}
