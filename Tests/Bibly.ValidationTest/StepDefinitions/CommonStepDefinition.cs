using Bibly.Application.Common.Exceptions;
using Bibly.Core.Dtos;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class CommonStepDefinition
    {
        public static Exception? exception;

        [Then("une erreur de validation est retournee")]
        public void ThenUneErreurDeValidationEstRetournee()
        {
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ValidationException>();
        }

        [Given]
        public void GivenUneListeDauteurs(DataTable dataTable)
        {
            var authors = dataTable.CreateSet<AuthorDto>();
        }
    }
}
