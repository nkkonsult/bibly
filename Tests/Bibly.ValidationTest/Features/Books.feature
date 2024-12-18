Feature: Books management

Scenario: Add a book
	Given un livre
	And son titre est "Le Seigneur des Anneaux"
	And l id de son auteur est 15
	And sa date de publication est 1954-07-29
	When j ajoute le livre
	Then le livre est ajoute

Scenario: Add the same book twice
	Given un livre
	And son titre est "Le Seigneur des Anneaux"
	And l id de son auteur est 15
	And sa date de publication est 1954-07-29
	When j ajoute le livre 2 fois
	Then une errreur de validation est retournee

Scenario: Add a book with a future publication date
	Given un livre
	And son titre est "Le Seigneur des Anneaux"
	And l id de son auteur est 15
	And sa date de publication est ulterieure a la date actuelle
	When j ajoute le livre
	Then une errreur de validation est retournee

Scenario: Add a list of books
	Given une liste de livre
	| Titre | Auteur | Date de publication |
	| Le Seigneur des Anneaux | 15 | 1954-07-29 |
	| Le Hobbit | 15 | 1937-09-21 |
	When j ajoute la liste de livre
	Then la liste de livre est ajoute