using System;
using gestion_etudiant.Service;

namespace gestion_etudiant.View
{
    public class NoteView
    {
        private EtudiantService etudiantService;
        private NoteService noteService;

        public NoteView(EtudiantService eService, NoteService nService)
        {
            etudiantService = eService;
            noteService = nService;
        }

        public void AjouterNote()
        {
            Console.Write("ID Étudiant : ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var etu = etudiantService.Rechercher(id);
            if (etu == null)
            {
                Console.WriteLine("⚠️ Étudiant introuvable !");
                return;
            }

            Console.Write("Valeur de la note : ");
            double note = double.Parse(Console.ReadLine() ?? "0");
            noteService.Ajouter(etu, note);
            Console.WriteLine("✅ Note ajoutée !");
        }

        public void AfficherNotes()
        {
            Console.Write("ID Étudiant : ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var etu = etudiantService.Rechercher(id);
            if (etu == null)
            {
                Console.WriteLine("⚠️ Étudiant introuvable !");
                return;
            }

            var notes = noteService.NotesEtudiant(id);
            if (notes.Count == 0)
            {
                Console.WriteLine("⚠️ Aucune note trouvée !");
                return;
            }

            Console.WriteLine($"\nNotes de {etu.Nom} {etu.Prenom} :");
            foreach (var n in notes)
            {
                string appreciation = n.Valeur >= 16 ? "Très bien" :
                                      n.Valeur >= 14 ? "Bien" :
                                      n.Valeur >= 10 ? "Passable" : "Insuffisant";
                Console.WriteLine($"- {n.Valeur} ({appreciation})");
            }
        }

        public void MeilleurEtudiant()
        {
            var meilleur = noteService.MeilleurEtudiant();
            if (meilleur != null)
                Console.WriteLine($"🏆 Meilleur étudiant : {meilleur.Nom} {meilleur.Prenom}");
            else
                Console.WriteLine("⚠️ Aucun étudiant noté !");
        }

        public void MoyenneClasse()
        {
            double m = noteService.MoyenneClasse();
            Console.WriteLine($"📊 Moyenne de la classe : {m:F2}");
        }
    }
}
