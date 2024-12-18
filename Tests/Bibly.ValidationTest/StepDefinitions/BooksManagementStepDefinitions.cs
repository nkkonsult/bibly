using Bibly.Application.Books;
using Bibly.Core.Dtos;
using Bibly.ValidationTest.Drivers;

namespace Bibly.ValidationTest.StepDefinitions
{

    [Binding]
    public class BooksManagementStepDefinitions : Testing, IDisposable
    {
        private AddBookCommandBuilder? _addBookCommandBuilder;
        private AddBookCommand? _addBookCommand;
        private List<BookDto> _books;

        [Given("un livre")]
        public void GivenUnLivre()
        {
            _addBookCommandBuilder = new();

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

        [When("j ajoute le livre 2 fois")]
        public async Task WhenJAjouteLeLivre2Fois()
        {
            try
            {
                _addBookCommand = _addBookCommandBuilder.Build();

                FakeAuthorRepository repository = new FakeAuthorRepository();
                await repository.ExistById(_addBookCommand.AuthorId);

                await SendAsync(_addBookCommand);
                await SendAsync(_addBookCommand);
            }
            catch (Application.Common.Exceptions.NotFoundException ex)
            {
                CommonStepDefinition.Exception = ex;
            }

        }


        [Given("une liste de livre")]
        public void GivenUneListeDeLivre(DataTable dataTable)
        {
            _books = dataTable.CreateSet<BookDto>().ToList();
        }


        [When("j ajoute la liste de livre")]
        public async Task WhenJAjouteLaListeDeLivre()
        {
            try
            {
                await SendAsync(new AddBookListCommand(_books));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Then("la liste de livre est ajoute")]
        public void ThenLaListeDeLivreEstAjoute()
        {
            FakeBookRepository.Books.Should().NotBeEmpty();
            FakeBookRepository.Books.Count.Should().Be(_books.Count);
        }

        [Then("une erreur de auteur non trouvé est retournee")]
        public void ThenUneErreurDeAuteurNonTrouveEstRetournee()
        {
            throw new PendingStepException();
        }


        [Given("la date de publication est ulterieure a la date actuelle")]
        public void GivenLaDateDePublicationEstUlterieureALaDateActuelle()
        {
            _addBookCommandBuilder.WithPublicationDate(DateTime.Now.AddDays(1));
        }

        [Given("son titre est (.*)")]
        public void GivenSonTitreEstLeSeigneurDesAnneaux(string title)
        {
            _addBookCommandBuilder.WithTitle(title);
        }

        public void Dispose()
        {
            FakeAuthorRepository.Authors.Clear();
            FakeBookRepository.Books.Clear();
        }
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
