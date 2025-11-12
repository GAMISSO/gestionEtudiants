using System.Collections.Generic;
using gestion_etudiant.Entity;

namespace gestion_etudiant.Service
{
    public interface EtudiantService
    {
        void Ajouter(string nom, string prenom);
        List<Etudiant> Lister();
        Etudiant? Rechercher(int id);
        bool Supprimer(int id);
    }
}
