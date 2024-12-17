using Bibly.Application.Author;
using Bibly.Application.Common.Exceptions;
using Bibly.Core.Dtos;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class GestionDesAuteursStepDefinitions : Testing
    {
        private AddAuthorCommand command;
        private string LastName;
        private string FirstName;
        private DateTime BirthDay;

        private Exception exception;    

       
        [Given("un auteur")]
        public void GivenUnAuteur()
        {            
        }

        [Given("son nom est {string}")]
        public void GivenSonNomEst(string doe)
        {
            LastName = doe;
        }

        [Given("son prenom est {string}")]
        public void GivenSonPrenomEstJohn(string name)
        {
            FirstName = name;
        }

        [Given("sa date de naissance est {DateTime}")]
        public void GivenSaDateDeNaissanceEst(DateTime date)
        {
            BirthDay = date;
        }

  

        [When("j ajoute lauteur")]
        public async  Task WhenJAjouteLauteur()
        {            
            command = new AddAuthorCommand(FirstName, LastName, BirthDay);

            await SendAsync(command);
        }

        [Then("lauteur est ajoute")]
        public void ThenLauteurEstAjoute()
        {
            FakeAuthorRepository.Authors.Count.Should().Be(1);
            FakeAuthorRepository.Authors.First().Value.FirstName.Should().Be(FirstName);
            FakeAuthorRepository.Authors.First().Value.LastName.Should().Be(LastName);
            FakeAuthorRepository.Authors.First().Value.BirthDay.Should().Be(BirthDay);
        }


        [When("j ajoute lauteur {int} fois")]
        public async Task WhenJAjouteLauteurFoisAsync(int p0)
        {
            command = new AddAuthorCommand(FirstName, LastName, BirthDay);

            try
            {
                await SendAsync(command);
                await SendAsync(command);
            }
            catch (Exception ex)
            {

                exception = ex;
            }
        }

        [Then("une errreur de validation est retournee")]
        public void ThenUneErrreurDeValidationEstRetournee()
        {
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ValidationException>();
        }
    }
}
