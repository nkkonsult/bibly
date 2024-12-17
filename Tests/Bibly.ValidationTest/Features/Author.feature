Feature: Gestion des Auteurs

Scenario: Ajouter un auteur
	Given un auteur
	And son nom est "Doe"
	* son prenom est "John"
	And sa date de naissance est 1985-03-01
	When j ajoute l'auteur
	Then l auteur est ajoute