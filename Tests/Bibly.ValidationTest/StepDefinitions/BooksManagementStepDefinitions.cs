using Bibly.Application.Books;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{

    [Binding]
    public class BooksManagementStepDefinitions : Testing, IDisposable
    {
        private AddBookCommandBuilder? _addBookCommandBuilder;
        private AddBookCommand? _addBookCommand;

        [Given("un livre")]
        public void GivenUnLivre()
        {
            _addBookCommandBuilder = new();
        }

        [Given("son titre est {string}")]
        public void GivenSonTitreEst(string title)
        {
            _addBookCommandBuilder.WithTitle(title);
        }

        [Given("l id de son auteur est {int}")]
        public void GivenLIdDeSonAuteurEst(int authorId)
        {
            _addBookCommandBuilder.WithAuthorId(authorId);
        }

        [Given("sa date de publication est {DateTime}")]
        public void GivenSaDateDePublicationEst(DateTime dateTime)
        {
            _addBookCommandBuilder.WithPublicationDate(dateTime);
        }

        [When("j ajoute le livre")]
        public async Task WhenJAjouteLeLivre()
        {
            _addBookCommand = _addBookCommandBuilder.Build();

            await SendAsync(_addBookCommand);
        }

        [Then("le livre est ajoute")]
        public void ThenLeLivreEstAjoute()
        {
            FakeBookRepository.Books.Should().NotBeEmpty();
            var item = FakeBookRepository.Books.FirstOrDefault().Value;
            item.Title.Should().Be(_addBookCommand.Title);
            item.AuthorId.Should().Be(_addBookCommand.AuthorId);
            item.PublicationDate.Should().Be(_addBookCommand.PublicationDate);
        }

        [When("j ajoute le livre {int} fois")]
        public void WhenJAjouteLeLivreFois(int p0)
        {
            throw new PendingStepException();
        }

        [Given("une liste de livre")]
        public void GivenUneListeDeLivre(DataTable dataTable)
        {
            var books = dataTable.CreateSet<Book>().ToList();
        }

        [Given("que sa date de publication est ulterieure a la date actuelle")]
        public void GivenQueSaDateDePublicationEstUlterieureALaDateActuelle()
        {
            throw new PendingStepException();
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

        public void Dispose()
        {
            FakeBookRepository.Books.Clear();
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }

    }

    public class AddBookCommandBuilder
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }

        public AddBookCommandBuilder() { }

        public AddBookCommandBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public AddBookCommandBuilder WithAuthorId(int authorId)
        {
            AuthorId = authorId;
            return this;
        }

        public AddBookCommandBuilder WithPublicationDate(DateTime publicationDate)
        {
            PublicationDate = publicationDate;
            return this;
        }

        public AddBookCommand Build()
        {
            return new AddBookCommand(Title, AuthorId, PublicationDate);
        }
    }

}
