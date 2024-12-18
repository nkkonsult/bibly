namespace Bibly.ValidationTest.StepDefinitions
{
    [Binding]
    public class BooksManagementStepDefinitions
    {
        [Given("un livre")]
        public void GivenUnLivre()
        {
            throw new PendingStepException();
        }

        [Given("son titre est {string}")]
        public void GivenSonTitreEst(string p0)
        {
            throw new PendingStepException();
        }

        [Given("l id de son auteur est {int}")]
        public void GivenLIdDeSonAuteurEst(int p0)
        {
            throw new PendingStepException();
        }

        [Given("sa date de publication est {float}{int}")]
        public void GivenSaDateDePublicationEst(Decimal p0, int p1)
        {
            throw new PendingStepException();
        }

        [When("j ajoute le livre")]
        public void WhenJAjouteLeLivre()
        {
            throw new PendingStepException();
        }

        [Then("le livre est ajoute")]
        public void ThenLeLivreEstAjoute()
        {
            throw new PendingStepException();
        }

        [When("j ajoute le livre {int} fois")]
        public void WhenJAjouteLeLivreFois(int p0)
        {
            throw new PendingStepException();
        }

        [Then("une errreur de validation est retournee")]
        public void ThenUneErrreurDeValidationEstRetournee()
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
    }
}
