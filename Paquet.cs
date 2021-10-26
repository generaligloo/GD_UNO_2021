using System;
using System.Collections.Generic;

namespace GD_UNO_2021
{
    public class Paquet
    {
        public List<Carte> paquet;

        public Paquet()
        {
            paquet = new List<Carte>();

            foreach (COULEUR col in Enum.GetValues(typeof(COULEUR)))
            {
                if (col != COULEUR.NOIR)
                {
                    foreach (VALEUR val in Enum.GetValues(typeof(VALEUR)))
                    {
                        switch (val)
                        {
                            case VALEUR.UN:
                            case VALEUR.DEUX:
                            case VALEUR.TROIS:
                            case VALEUR.QUATRE:
                            case VALEUR.CINQ:
                            case VALEUR.SIX:
                            case VALEUR.SEPT:
                            case VALEUR.HUIT:
                            case VALEUR.NEUF:

                                paquet.Add(new Carte()
                                {
                                    Carte_couleur = col,
                                    Carte_valeur = val,
                                    Carte_score = (int)val
                                });
                                paquet.Add(new Carte()
                                {
                                    Carte_couleur = col,
                                    Carte_valeur = val,
                                    Carte_score = (int)val
                                });
                                break;

                            case VALEUR.PASSE:
                            case VALEUR.INVERS:
                            case VALEUR.PLUS_DEUX:
                                paquet.Add(new Carte()
                                {
                                    Carte_couleur = col,
                                    Carte_valeur = val,
                                    Carte_score = 20
                                });
                                paquet.Add(new Carte()
                                {
                                    Carte_couleur = col,
                                    Carte_valeur = val,
                                    Carte_score = 20
                                });
                                break;

                            case VALEUR.ZERO:
                                paquet.Add(new Carte()
                                {
                                    Carte_couleur = col,
                                    Carte_valeur = val,
                                    Carte_score = 0
                                });
                                break;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        paquet.Add(new Carte()
                        {
                            Carte_couleur = col,
                            Carte_valeur = VALEUR.JOKER,
                            Carte_score = 50
                        });
                    }
                    for (int i = 1; i <= 4; i++)
                    {
                        paquet.Add(new Carte()
                        {
                            Carte_couleur = col,
                            Carte_valeur = VALEUR.PLUS_QUATRE,
                            Carte_score = 50
                        });
                    }
                }
            }
        }

        public void Melanger()
        {
            Carte tmp;
            Random al = new Random();
            List<Carte> C = paquet;
            for (int mel = C.Count - 1; mel > 0; --mel)
            {
                int n = al.Next(mel + 1);
                tmp = paquet[mel];
                paquet[mel] = paquet[n];
                paquet[n] = tmp;
            }
        }
    }
}