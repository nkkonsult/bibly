Feature: Gestion des Auteurs

Scenario: Ajouter un auteur
	Given un auteur
	 And son nom est "Doe"
	 And son prenom est "John"
	 And sa date de naissance est 1985-03-01
	When j ajoute lauteur
	Then lauteur est ajoute

Scenario: Ajouter le meme auteur 2 fois
	Given un auteur
	And son nom est "Doe"
	And son prenom est "John"
	And sa date de naissance est 1985-03-01
	When j ajoute lauteur 2 fois
	Then une errreur de validation est retournee