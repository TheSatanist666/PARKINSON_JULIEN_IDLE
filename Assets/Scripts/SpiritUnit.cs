using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//instaure la possibilite de creer un esprit "new_spirit" depuis le moteur de jeu
[CreateAssetMenu(fileName ="new_spirit", menuName ="Spirit/Unit",order =0)]

//crée une classe d'esprits ayant une couleur, une image et une valeur (la valeur sera aussi utilisee pour le rayon)
public class SpiritUnit : ScriptableObject
{
    public SpiritColor color;
    public int value;
    public Sprite spiritImage;
}
