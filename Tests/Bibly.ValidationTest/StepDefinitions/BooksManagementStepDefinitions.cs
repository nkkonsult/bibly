using Bibly.Application.Author;
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
            try
            {
                _addBookCommand = _addBookCommandBuilder.Build();

                FakeAuthorRepository repository = new FakeAuthorRepository();
                await repository.ExistById(_addBookCommand.AuthorId);

                await SendAsync(_addBookCommand);
            }
            catch (Application.Common.Exceptions.NotFoundException ex)
            {
                CommonStepDefinition.Exception = ex;
            }
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

        [Given("sa date de publication est ulterieure a la date actuelle")]
        public void GivenSaDateDePublicationEstUlterieureALaDateActuelle()
        {
            throw new PendingStepException();
        }

        [Given("une liste de livre")]
        public void GivenUneListeDeLivre(DataTable dataTable)
        {
            var books = dataTable.CreateSet<Book>().ToList();
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

        [Then("une erreur de auteur non trouvé est retournee")]
        public void ThenUneErreurDeAuteurNonTrouveEstRetournee()
        {
            throw new PendingStepException();
        }


        public void Dispose()
        {
            FakeAuthorRepository.Authors.Clear();
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
