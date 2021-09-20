using System;

namespace JeuxRapides
{
    class Program
    {
        /**
        * Détermine le choix de la catégorie. 
        * 
        * @return categorie : la catégorie choisie par l'utilisateur
        **/
        static string ChoisirCategorie() 
        {
            Console.WriteLine("Veuillez inscrire la catégorie désirée.");
            Console.WriteLine(" 1 - Jeux de cartes");
            Console.WriteLine(" 2 - Exercices mathématiques");
            Console.Write("\nCatégorie: ");
            
            return Console.ReadLine();
        }

        /**
        * Détermine le choix du jeu de cartes. 
        * 
        * @return categorie : la jeu de cartes choisi par l'utilisateur
        **/
        static string ChoisirJeuDeCartes() 
        {
            Console.WriteLine("Veuillez inscrire le jeu de cartes désiré.");
            Console.WriteLine(" 1 - In-Between");
            Console.WriteLine(" 2 - Red Or Black");
            Console.WriteLine(" 3 - Figures");
            Console.Write("\nJeu: ");            
            
            return Console.ReadLine();
        }

        /**
        * Jeu In-Between. 
        **/
        static void InBetween()
        {
            Random valeurAleatoire = new Random();

            int carte1 = valeurAleatoire.Next(1, 13+1);  // n'oubliez pas que la valeur supérieure est exclusive!
            int carte2 = valeurAleatoire.Next(1, 13+1);
            int carte3 = valeurAleatoire.Next(1, 13+1);

            string reponseJoueur = "";

            bool entre = false;

            /* la carte 3 est entre la carte 1 et la carte 2 
            *  SI :
            *  elle est >= carte 1 et <= carte 2
            *  OU
            *  elle est >= carte 2 et <= carte 1
            *  Note : les parenthères sont implicites car le ET a priorité sur le OU
            * if((carte3 >= carte1 && carte3 <= carte2) || (carte3 >= carte2 && carte3 <= carte1)) */
            if(carte3 >= carte1 && carte3 <= carte2 || carte3 >= carte2 && carte3 <= carte1)
            {
                entre = true;
            }

            Console.WriteLine($"Voici les 2 premières cartes du paquet: \nCarte 1: {carte1} \nCarte 2 : {carte2}");
            Console.WriteLine("La troisième se retrouve-t-elle entre ces 2 cartes (inclusivement)? (O/N)");
            reponseJoueur = Console.ReadLine();

            Console.WriteLine($"Carte 3 : {carte3}");

            if(reponseJoueur.ToUpper() == "O" && entre == true ||
                reponseJoueur.ToUpper() == "N" && entre == false) 
            {
                Console.WriteLine("Vous avez gagné!");
            }
            else
            {
                Console.WriteLine("Vous avez perdu!");
            }
        }
        
        /**
        * Jeu Red Or Black. 
        **/
        static void RedOrBlack()
        {
            
        }

        /**
        * Jeu Figures. 
        **/
        static void Figures()
        {
            
        }

        /**
        * Détermine le choix de l'opération. 
        * 
        * @return operation : l'opération choisie par l'utilisateur
        **/
        static string ChoisirOperation()
        {
            Console.WriteLine("Veuillez choisir l'opératation désirée :");
            Console.WriteLine(" + : addition");
            Console.WriteLine(" - : soustraction");
            Console.WriteLine(" * : multiplication");            
            Console.WriteLine(" / : division");
            Console.Write("Opération : ");

            return Console.ReadLine();
        }

        /**
        * Détermine le niveau de difficulté. 
        * 
        * @return operation : le niveau de difficulté choisi par l'utilisateur
        **/
        static string ChoisirNiveauDifficulte()
        {
            Console.WriteLine("\nVeuillez choisir le niveau de difficulté :");
            Console.WriteLine("1 - facile : nombres aléatoires générés entre 1 et 10​");            
            Console.WriteLine("2 - intermédiaire : nombres aléatoires générés entre 11 et 20​");
            Console.WriteLine("3 - difficile : nombres aléatoires générés entre 20 et 50​");
            Console.Write("Niveau de difficulté : ");

            return Console.ReadLine();
        }

        /**
        * Effectue le traitement de l'exercice mathématique. 
        *
        * @param operation : L'opération mathématique à effectuer
        * @param niveauDifficulté : Le niveau de difficulté choisi par l'utilisateur
        **/
        static void EffecturerExerciceMath(string operation, string niveauDifficulte)
        {
            Random nombreAleatoire = new Random();
            int nombre1 = 0;
            int nombre2 = 0;
            int reponseOperation = 0;
            int reponseUtilisateur = 0;
            bool parametresValides = true;

            switch(niveauDifficulte)
            {
                case "1":
                    nombre1 = nombreAleatoire.Next(1, 10+1);
                    nombre2 = nombreAleatoire.Next(1, 10+1);
                    break;
                case "2":
                    nombre1 = nombreAleatoire.Next(10, 20+1);
                    nombre2 = nombreAleatoire.Next(10, 20+1);
                    break;
                case "3":
                    nombre1 = nombreAleatoire.Next(20, 50+1);
                    nombre2 = nombreAleatoire.Next(20, 50+1);
                    break;
                default:
                    parametresValides = false;
                    nombre1 = -1;
                    nombre2 = -1;
                    break;
            }

            switch(operation)
            {
                case "+":  
                    reponseOperation = nombre1 + nombre2;                  
                    break;
                case "-":  
                    reponseOperation = nombre1 - nombre2;
                    break;
                case "*":  
                    reponseOperation = nombre1 * nombre2;
                    break;
                case "/":  
                    reponseOperation = nombre1 / nombre2;
                    break;
                default:
                    parametresValides = false;
                    break;
            }

            if(parametresValides) 
            {
                Console.Write($"Combien font {nombre1} {operation} {nombre2} (résultat entier)? ");
                int.TryParse(Console.ReadLine(), out reponseUtilisateur);
                if(reponseOperation == reponseUtilisateur)
                {
                    Console.WriteLine("Bonne réponse!");
                }
                else
                {
                    Console.WriteLine($"Erreur! La bonne réponse est {reponseOperation}");
                }
            } 
            else
            {
                Console.WriteLine("Les paramètres entrés sont invalides. \nIl est impossible de réaliser l'exercice mathématique.");
            }
        }

        /**
        * Exercice mathématique. 
        **/
        static void ExerciceMath()
        {
            string operation = ChoisirOperation();
            string niveauDifficulte = ChoisirNiveauDifficulte();
            
            Console.Clear();

            EffecturerExerciceMath(operation, niveauDifficulte);
        }

        /**
        * Fonction principale Main 
        * 
        * @param args : arguments que nous utilisons pas pour le moment!
        **/
        static void Main(string[] args)
        {
            string categorieChoisie = "";
            string jeuChoisi = "";

            Console.WriteLine("Bonjour! Voici un programme conçu pour exercer votre cerveau!");

            categorieChoisie = ChoisirCategorie();
            Console.Clear();

            if(categorieChoisie == "1") 
            {
                jeuChoisi = ChoisirJeuDeCartes();
                Console.Clear();
                switch(jeuChoisi)
                {
                    case "1":
                        InBetween();
                        break;
                    case "2":
                        RedOrBlack();
                        break;
                    case "3":
                        Figures();
                        break;
                    default:
                        Console.WriteLine("Choix de jeu invalide");
                        break;
                }
            } 
            else if(categorieChoisie == "2")
            {
                ExerciceMath();
            }
            else 
            {
               Console.WriteLine("Catégorie invalide"); 
            }

            Console.ReadLine();
        }
    }
}
