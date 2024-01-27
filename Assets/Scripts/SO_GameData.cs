using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//using JokeData;




[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public Joke CurrentJoke = null;
    public float Score = 0;
    public float HappinessTotal = 0;
    public float IrritationTotal = 0;
    public float SuccessTotal = 0;
    public float indictment = 0;
    public float Popularity = 0;


    public JokeData GetNewRandomJoke()
    {
        int rnd = Random.Range(0, jokes.Length);

        return jokes[rnd];
    }

    JokeData[] jokes = new JokeData[] {
        new(1,
            "\"Estaba con un amigo el otro d�a y lo veo hablando solo. Me acerco y le pregunto, '�Qu� haces hablando con tus zapatillas?' Y �l, con la mayor seriedad del mundo, me responde, 'Pues dice Converse'. Me lo quedo mirando raro, y el solo se queda pensando y dice, 'Oye, es publicidad enga�osa si no responden, �no crees?' All� record� que sus papas eran hermanos y todo cobr� sentido." ),
        new(2,
            "\"Fui al m�dico el otro d�a porque estaba teniendo problemas de memoria. Le pregunto al doctor, '�Qui�n es ese hombre alem�n que me hace olvidar las cosas?' Y el doctor, sin perder el ritmo, me dice 'Alzheimer'. Yo pens�, 'Vaya, debe ser un tipo famoso, porque no hay d�a que no se me olvide su nombre.'\"" )
    };



}
