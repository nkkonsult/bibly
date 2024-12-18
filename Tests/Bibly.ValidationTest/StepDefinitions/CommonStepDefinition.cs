using Bibly.Application.Common.Exceptions;

namespace Bibly.ValidationTest.StepDefinitions
{
    public class CommonStepDefinition : Testing
    {
        public Exception? exception;

        [Then("une erreur de validation est retournee")]
        public void ThenUneErreurDeValidationEstRetournee()
        {
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ValidationException>();
        }
    }
}
