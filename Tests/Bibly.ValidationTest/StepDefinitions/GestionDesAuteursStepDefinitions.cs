using Bibly.Application.Author.Command;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class GestionDesAuteursStepDefinitions
    {
        private AddAuthorCommand command;
        private string LastName;
        private string FirstName;
        private DateTime BirthDay;

        private AddAuthorCommandHandler handler;

        public GestionDesAuteursStepDefinitions()
        {
            handler = new AddAuthorCommandHandler(new FakeAuthorRepository());
        }

        [Given("un auteur")]
        public void GivenUnAuteur()
        {
        }

        [Given("son nom est {string}")]
        public void GivenSonNomEst(string lastName)
        {
            LastName = lastName;
        }

        [Given("son prenom est {string}")]
        public void GivenSonPrenomEst(string firstName)
        {
            FirstName = firstName;
        }

        [Given("sa date de naissance est {DateTime}")]
        public void GivenSaDateDeNaissanceEst(DateTime date)
        {
            BirthDay = date;
        }

        [When("j ajoute l'auteur")]
        public async Task WhenJAjouteLauteur()
        {
            command = new AddAuthorCommand(FirstName, LastName, BirthDay);

            await handler.Handle(command, CancellationToken.None);
        }

        [Then("l auteur est ajoute")]
        public void ThenLAuteurEstAjoute()
        {
            FakeAuthorRepository.Authors.Count.Should().Be(1);
            FakeAuthorRepository.Authors.First().Value.FirstName.Should().Be(FirstName);
            FakeAuthorRepository.Authors.First().Value.LastName.Should().Be(LastName);
            FakeAuthorRepository.Authors.First().Value.BirthDay.Should().Be(BirthDay);
        }
    }
}
