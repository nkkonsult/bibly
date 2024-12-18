using Bibly.Application.Author;
using Bibly.Core.Dtos;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class GestionDesAuteursStepDefinitions : Testing, IDisposable
    {
        private AddAuthorCommand command;
        private string LastName;
        private string FirstName;
        private DateTime BirthDay;


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
        public async Task WhenJAjouteLauteur()
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

                CommonStepDefinition.Exception = ex;
            }
        }

        [Given("une liste d'auteurs")]
        public void GivenUneListeDauteurs(DataTable dataTable)
        {
            var authors = dataTable.CreateSet<AuthorDto>();
            foreach (var item in authors)
            {
                FakeAuthorRepository.Authors.Add(item.Id, item);
            }
        }

        public void Dispose()
        {
            FakeAuthorRepository.Authors.Clear();
        }
    }
}
