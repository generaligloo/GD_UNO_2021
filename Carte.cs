using System;

namespace GD_UNO_2021
{
    [Serializable]
    public class Carte
    {
        public COULEUR Carte_couleur { get; set; }
        public VALEUR Carte_valeur { get; set; }
        public int Carte_score { get; set; }

        public Carte()
        {
        }

        public Carte(string couleur, string valeur, int score)
        {
            switch (couleur)
            {
                case "ROUGE":
                    Carte_couleur = COULEUR.ROUGE;
                    break;

                case "JAUNE":
                    Carte_couleur = COULEUR.JAUNE;
                    break;

                case "BLEU":
                    Carte_couleur = COULEUR.BLEU;
                    break;

                case "VERT":
                    Carte_couleur = COULEUR.VERT;
                    break;

                case "NOIR":
                    Carte_couleur = COULEUR.NOIR;
                    break;
            }
            switch (valeur)
            {
                case "ZERO":
                    Carte_valeur = VALEUR.ZERO;
                    break;

                case "UN":
                    Carte_valeur = VALEUR.UN;
                    break;

                case "DEUX":
                    Carte_valeur = VALEUR.DEUX;
                    break;

                case "TROIS":
                    Carte_valeur = VALEUR.TROIS;
                    break;

                case "QUATRE":
                    Carte_valeur = VALEUR.QUATRE;
                    break;

                case "CINQ":
                    Carte_valeur = VALEUR.CINQ;
                    break;

                case "SIX":
                    Carte_valeur = VALEUR.SIX;
                    break;

                case "SEPT":
                    Carte_valeur = VALEUR.SEPT;
                    break;

                case "HUIT":
                    Carte_valeur = VALEUR.HUIT;
                    break;

                case "NEUF":
                    Carte_valeur = VALEUR.NEUF;
                    break;

                case "PLUS_DEUX":
                    Carte_valeur = VALEUR.PLUS_DEUX;
                    break;

                case "INVERS":
                    Carte_valeur = VALEUR.INVERS;
                    break;

                case "PASSE":
                    Carte_valeur = VALEUR.PASSE;
                    break;

                case "PLUS_QUATRE":
                    Carte_valeur = VALEUR.PLUS_QUATRE;
                    break;

                case "JOKER":
                    Carte_valeur = VALEUR.JOKER;
                    break;
            }
            Carte_score = score;
        }

        public string DisplayValue
        {
            get
            {
                return Carte_couleur.ToString() + "_" + Carte_valeur.ToString();
            }
        }
    }
}