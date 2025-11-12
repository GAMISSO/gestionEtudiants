using System;
using gestion_etudiant.Service;
using gestion_etudiant.Entity;

namespace gestion_etudiant.View
{
    public class EtudiantView
    {
        private EtudiantService service;

        public EtudiantView(EtudiantService service)
        {
            this.service = service;
        }

        public void Ajouter()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine() ?? "";

            service.Ajouter(nom, prenom);
            Console.WriteLine("Étudiant ajouté !");
        }

        public void Lister()
        {
            Console.WriteLine("\n=== Liste des étudiants ===");
            foreach (var e in service.Lister())
            {
                Console.WriteLine($"{e.Id}. {e.Nom} {e.Prenom}");
            }
        }

        public void Supprimer()
        {
            Console.Write("ID de l’étudiant à supprimer : ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            if (service.Supprimer(id))
                Console.WriteLine(" Étudiant supprimé !");
            else
                Console.WriteLine("Étudiant introuvable !");
        }
    }
}
