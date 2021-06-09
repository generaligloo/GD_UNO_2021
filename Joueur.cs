using System.Collections.Generic;
using System.Linq;

namespace GD_UNO_2021
{
    public class Joueur
    {
        public List<Carte> Main { get; set; }

        public Joueur()
        {
            Main = new List<Carte>();
        }

        public void TrierMain()
        {
            this.Main = this.Main.OrderBy(x => x.Carte_couleur).ThenBy(x => x.Carte_valeur).ToList();
        }
    }
}