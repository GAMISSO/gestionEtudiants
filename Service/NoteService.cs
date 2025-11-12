using System.Collections.Generic;
using gestion_etudiant.Entity;

namespace gestion_etudiant.Service
{
    public interface NoteService
    {
        void Ajouter(Etudiant etu, double valeur);
        List<Note> NotesEtudiant(int idEtudiant);
        double MoyenneEtudiant(int idEtudiant);
        double MoyenneClasse();
        Etudiant? MeilleurEtudiant();
    }
}
