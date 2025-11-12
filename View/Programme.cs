using System;
using gestion_etudiant.Service;

namespace gestion_etudiant.View
{
    public class Programme
    {
        public static void Lancer()
        {
            var etuService = new EtudiantService();
            var noteService = new NoteService();
            var etuView = new EtudiantView(etuService);
            var noteView = new NoteView(etuService, noteService);

            while (true)
            {
                Console.WriteLine("\nQue souhaitez-vous faire ?");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher les étudiants");
                Console.WriteLine("3. Ajouter une note à un étudiant");
                Console.WriteLine("4. Afficher les notes d’un étudiant avec appréciation");
                Console.WriteLine("5. Supprimer un étudiant");
                Console.WriteLine("6. Afficher le meilleur étudiant");
                Console.WriteLine("7. Afficher la moyenne de la classe");
                Console.WriteLine("8. Quitter");
                Console.Write("Choix : ");

                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1": etuView.Ajouter(); break;
                    case "2": etuView.Lister(); break;
                    case "3": noteView.AjouterNote(); break;
                    case "4": noteView.AfficherNotes(); break;
                    case "5": etuView.Supprimer(); break;
                    case "6": noteView.MeilleurEtudiant(); break;
                    case "7": noteView.MoyenneClasse(); break;
                    case "8": return;
                    default: Console.WriteLine("Choix invalide !"); break;
                }
            }
        }
    }
}
