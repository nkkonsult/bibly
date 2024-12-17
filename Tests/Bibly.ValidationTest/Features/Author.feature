Feature: Gestion des Auteurs

Scenario: Ajouter un auteur
	Given un auteur
	And son nom est "Doe"
	* son prenom est "John"
	And sa date de naissance est 1985-03-01
	When j ajoute l'auteur
	Then l auteur est ajoute

Scenario: Ajouter le meme auteur 2 fois
	Given un auteur
	And son nom est "Doe"
	* son prenom est "John"
	And sa date de naissance est 1985-03-01
	When j ajoute l auteur 2 fois
	Then une erreur de validation est retournee