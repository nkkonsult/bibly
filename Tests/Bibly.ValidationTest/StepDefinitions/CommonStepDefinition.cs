using Bibly.Application.Common.Exceptions;

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

        [Then("une exception (.*) est retournee")]
        public void ThenUneExceptionNotFoundEstRetournee(string exceptionType)
        {
            Exception.Should().NotBeNull();
            Exception!.GetType().Name.Should().Be(exceptionType + "Exception");
        }


        [Then("Le message d erreur est {string}")]
        public void ThenLeMessageDErreurEst(string p0)
        {
            Exception.Message.Should().Be(p0);
        }

 


    }
}
