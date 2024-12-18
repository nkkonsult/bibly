using Bibly.Application.Books;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class BooksManagementStepDefinitions : Testing, IDisposable
    {
        private Book book;

        [Given("un livre")]
        public void GivenUnLivre()
        {
            book = new Book();
        }

        [Given("son titre est {string}")]
        public void GivenSonTitreEst(string title)
        {
            book.Title = title;
        }

        [Given("l id de son auteur est {int}")]
        public void GivenLIdDeSonAuteurEst(int authorId)
        {
            book.AuthorId = authorId;
        }

        [Given("sa date de publication est {DateTime}")]
        public void GivenSaDateDePublicationEst(DateTime publicationDate)
        {
            book.PublicationDate = publicationDate;
        }

        [When("j ajoute le livre")]
        public async Task WhenJAjouteLeLivre()
        {
            var command = new AddBookCommand(book.Title, book.AuthorId, book.PublicationDate);

            await SendAsync(command);
        }

        [Then("le livre est ajoute")]
        public async Task ThenLeLivreEstAjoute()
        {
            FakeBookRepository.Books.Should().NotBeEmpty();
            FakeBookRepository.Books.Count.Should().Be(1);
        }

        [When("j ajoute le livre {int} fois")]
        public async Task WhenJAjouteLeLivreFois()
        {
            var command = new AddBookCommand(book.Title, book.AuthorId, book.PublicationDate);

            try
            {
                await SendAsync(command);
                await SendAsync(command);
            }
            catch (Exception ex)
            {
                CommonStepDefinition.exception = ex;
            }
        }

        [Given("sa date de publication est ulterieure a la date actuelle")]
        public void GivenSaDateDePublicationEstUlterieureALaDateActuelle()
        {
            throw new PendingStepException();
        }

        [Given("une liste de livre")]
        public void GivenUneListeDeLivre(DataTable dataTable)
        {
            List<Book> books = dataTable.CreateSet<Book>().ToList();
        }

        [When("j ajoute la liste de livre")]
        public void WhenJAjouteLaListeDeLivre()
        {
            throw new PendingStepException();
        }

        [Then("la liste de livre est ajoute")]
        public void ThenLaListeDeLivreEstAjoute()
        {
            throw new PendingStepException();
        }

        public void Dispose() => FakeBookRepository.Books.Clear();

        class Book
        {
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public DateTime PublicationDate { get; set; }
        }
    }
}
