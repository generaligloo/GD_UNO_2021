using System.Collections.Generic;
using System.Linq;

namespace GD_UNO_2021
{
    public class jeu
    {
        public const int nb_joueur = 2;
        public Paquet Pioche { get; set; }
        public List<Joueur> Joueurs { get; set; }
        public List<Carte> Defausse { get; set; }

        public void charger(List<Carte> J1_c, List<Carte> J2_c, List<Carte> Pioche_c, List<Carte> Defausse_c)
        {
            Pioche.paquet = Pioche_c;
            Defausse = Defausse_c;
            Joueurs[0].Main = J1_c;
            Joueurs[1].Main = J2_c;
        }

        public jeu()
        {
            Joueurs = new List<Joueur>();
            Pioche = new Paquet();
            Defausse = new List<Carte>();

            Pioche.Melanger();

            for (int i = 1; i <= nb_joueur; i++)
            {
                Joueurs.Add(new Joueur());
            }

            int CarteADist = 7 * Joueurs.Count;
            int CarteDist = 0;

            while (CarteDist < CarteADist)
            {
                for (int i = 0; i < nb_joueur; i++)
                {
                    Joueurs[i].Main.Insert(0, Pioche.paquet[0]);
                    Pioche.paquet.RemoveAt(0);
                    CarteDist++;
                }
            }

            Defausse = new List<Carte>();
            Defausse.Insert(0, Pioche.paquet[0]);
            Pioche.paquet.RemoveAt(0);

            while (Defausse[0].Carte_valeur == VALEUR.JOKER || Defausse[0].Carte_valeur == VALEUR.PLUS_QUATRE)
            {
                Defausse.Insert(0, Pioche.paquet[0]);
                Pioche.paquet.RemoveAt(0);
            }
        }

        public void Remelanger()
        {
            var Carte_defausse = Defausse.First();
            Pioche.paquet = Defausse.Skip(1).ToList();
            Pioche.Melanger();
            Defausse = new List<Carte>();
            Defausse.Add(Carte_defausse);
        }

        public void refresh()
        {
            Pioche.paquet.Clear();
            for (int i = 0; i < nb_joueur; i++)
            {
                Joueurs[i].Main.Clear();
            }
            Defausse.Clear();
            Joueurs = new List<Joueur>();
            Pioche = new Paquet();
            Defausse = new List<Carte>();
            Pioche.Melanger();

            for (int i = 1; i <= nb_joueur; i++)
            {
                Joueurs.Add(new Joueur());
            }

            int CarteADist = 7 * Joueurs.Count;
            int CarteDist = 0;

            while (CarteDist < CarteADist)
            {
                for (int i = 0; i < nb_joueur; i++)
                {
                    Joueurs[i].Main.Insert(0, Pioche.paquet.First());
                    Pioche.paquet.RemoveAt(0);
                    CarteDist++;
                }
            }

            Defausse = new List<Carte>();
            Defausse.Insert(0, Pioche.paquet.First());
            Pioche.paquet.RemoveAt(0);

            while (Defausse[0].Carte_valeur == VALEUR.JOKER || Defausse[0].Carte_valeur == VALEUR.PLUS_QUATRE)
            {
                Defausse.Insert(0, Pioche.paquet[0]);
                Pioche.paquet.RemoveAt(0);
            }
        }
    }
}