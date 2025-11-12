using gestion_etudiant.Entity;
using System.Collections.Generic;
using System.Linq;

namespace gestion_etudiant.Service
{
    public class NoteServiceImpl : NoteService
    {
        private List<Note> notes = new List<Note>();
        private int nextId = 1;

        public void Ajouter(Etudiant etu, double valeur)
        {
            notes.Add(new Note { Id = nextId++, Etudiant = etu, Valeur = valeur });
        }

        public List<Note> NotesEtudiant(int idEtudiant)
        {
            return notes.Where(n => n.Etudiant != null && n.Etudiant.Id == idEtudiant).ToList();
        }

        public double MoyenneEtudiant(int idEtudiant)
        {
            var n = NotesEtudiant(idEtudiant);
            return n.Count > 0 ? n.Average(x => x.Valeur) : 0;
        }

        public double MoyenneClasse()
        {
            return notes.Count > 0 ? notes.Average(x => x.Valeur) : 0;
        }

        public Etudiant? MeilleurEtudiant()
        {
            var groupes = notes.GroupBy(n => n.Etudiant)
                               .Select(g => new { Etudiant = g.Key, Moyenne = g.Average(x => x.Valeur) })
                               .OrderByDescending(x => x.Moyenne)
                               .FirstOrDefault();
            return groupes?.Etudiant;
        }
    }
}
