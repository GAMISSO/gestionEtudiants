using gestion_etudiant.Entity;
using System.Collections.Generic;
using System.Linq;

namespace gestion_etudiant.Service.impl
{
    public class EtudiantServiceImpl : EtudiantService
    {
        private List<Etudiant> etudiants = new List<Etudiant>();
        private int nextId = 1;

        public void Ajouter(string nom, string prenom)
        {
            var e = new Etudiant { Id = nextId++, Nom = nom, Prenom = prenom };
            etudiants.Add(e);
        }

        public List<Etudiant> Lister()
        {
            return etudiants;
        }

        public Etudiant? Rechercher(int id)
        {
            return etudiants.FirstOrDefault(e => e.Id == id);
        }

        public bool Supprimer(int id)
        {
            var etu = Rechercher(id);
            if (etu != null)
            {
                etudiants.Remove(etu);
                return true;
            }
            return false;
        }
    }
}
