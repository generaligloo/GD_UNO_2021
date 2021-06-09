namespace GD_UNO_2021
{
    public class Carte
    {
        public COULEUR Carte_couleur { get; set; }
        public VALEUR Carte_valeur { get; set; }
        public int Carte_score { get; set; }

        public string DisplayValue
        {
            get
            {
                return Carte_couleur.ToString() + "_" + Carte_valeur.ToString();
            }
        }
    }
}