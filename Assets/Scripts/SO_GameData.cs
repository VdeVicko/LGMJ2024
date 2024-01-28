using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;
//using JokeData;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public Joke CurrentJoke = null;
    public float Success = 0;
    public float Claps = 0;
    public float Critic = 0;
    public int Follower = 0;


    public NPCData[] GetNPCDataByLevel(int levelId)
    {
        NPCData[] data = new NPCData[6]; 

        data[0] = GetNewRandomNPC();
        data[1] = GetNewRandomNPC();
        data[2] = GetNewRandomNPC();
        data[3] = GetNewRandomNPC();
        data[4] = GetNewRandomNPC();
        data[5] = GetNewRandomNPC();

        return data;
    }

    public JokeData GetNewRandomJoke()
    {
        int rnd = Random.Range(0, jokes.Length);

        return jokes[rnd];
    }

    public NPCData GetNewRandomNPC()
    {
        int rnd = Random.Range(0, npcDB.Length);

        return npcDB[rnd];
    }



    JokeData[] jokes = new JokeData[] 
    {
new(1,"Conversando con las zapatillas 'Converse'","Estaba con un amigo el otro d�a y lo veo hablando solo. Me acerco y le pregunto, '�Qu� haces hablando con tus zapatillas?' Y �l, con la mayor seriedad del mundo, me responde, 'Pues dice Converse'. Me lo quedo mirando raro, y el solo se queda pensando y dice, 'Oye, es publicidad enga�osa si no responden, �no crees?' All� record� que sus papas eran hermanos y todo cobr� sentido.",2,5,1,"",0,""),
new(2,"El alem�n 'Alzheimer' del que no me olvido","Fui al m�dico el otro d�a porque estaba teniendo problemas de memoria. Le pregunto al doctor, '�Qui�n es ese hombre alem�n que me hace olvidar las cosas?' Y el doctor, sin perder el ritmo, me dice 'Alzheimer'. Yo pens�, 'Vaya, debe ser un tipo famoso, porque no hay d�a que no se me olvide su nombre.'",3,6,1,"Salud",1,"Alzheimer"),
new(3,"Que se necesita para colgar un cuadro de Jes�s","Estaba en una exposici�n de arte el otro d�a y me encontr� con un cuadro de Jes�s. Y empiezo a reflexionar sobre las diferencias entre el cuadro y el propio Jes�s. Llegu� a la conclusi�n de que solo necesitas un clavo para colgar el cuadro. Es un poco oscuro, lo s�, pero luego pens� que al menos el cuadro no te juzgar� por tus pecados.",4,5,1,"Religion",8,""),
new(4,"Hor�scopo terminal","El otro d�a, la mam� de mi esposa visit� a su medico y le pregunto: 'Doctor, �Qu� me dijo antes? �G�minis, Libra?' Y �l me responde con seriedad, 'C�ncer'. Ah� me di cuenta de que tal vez leer el  hor�scopo  puede traer mas problemas de lo que parece.",3,3,0,"Esoterismo",3,""),
new(5,"Cancer�logo","Mi esposa toda la vida a sido esot�rica, y ya cansa. El otro d�a me dice, vino un astrologo a ver a mi papa y me dijo que es c�ncer. Yo sabiendo que si pap� naci� en diciembre le digo: Mujer, est�s mal, tu papa no puede ser c�ncer. Resulta que mi mujer tambi�n es disl�xica, no el que vino no era astrologo, era onc�logo.",4,4,1,"Esoterismo",3,"Oncologo"),
new(6,"Eficiente vejez","Escuch� a dos jubilados charlando el otro d�a. Uno le dice al otro, 'Juan, estoy mal, cada ma�ana a las 7 voy al ba�o.' Y Juan, le responde, '�Y eso qu� tiene de malo?' 'Que me levanto a las 8.' Ah, la vejez, esa �poca de la vida en la que tu cuerpo se convierte en un despertador muy eficiente.",3,4,0,"Salud",1,""),
new(7,"Sin manos no hay paraiso","Las mamas de ahora no son como las de antes. Yo tenia un vecinito que le dec�a a su mama, 'Mam�, mam�, �me das una galleta?' Y ella, le dice 'Est�n encima de la nevera.' Pero el ni�o insiste, 'Mam�, es que no tengo brazos.' Y la madre, le responde, 'Ah� sin brazos no hay galletas.' Pobre mi amigo, le dec�amos capit�n Garfio.",4,7,2,"Salud",1,""),
new(8,"Ante la duda, la carta m�s alta","Estaba pensando el otro d�a sobre c�mo la infancia var�a tanto dependiendo de d�nde creces. Me acord� de esta historia de dos ni�os, uno rico y otro pobre, hablando sobre sus comidas en casa. El ni�o rico, presumiendo un poco, le dice al ni�o pobre, 'En mi casa comemos a la carta: lo que pedimos, nos lo sirven.' Imag�nense, men� personalizado en casa, el sue�o de todo gourmet infantil. Pero el ni�o pobre, sin perder el ritmo, le contesta, 'Ah, eso no es nada. En mi casa tambi�n comemos a la carta, pero es un poco diferente: el que saca la carta m�s alta, come.",6,6,1,"",0,""),
new(9,"A por el neutr�n, a la carga!","Estaba en un bar el otro d�a, y presenci� algo totalmente inesperado. Entran un prot�n y un electr�n y se sientan en la barra. El prot�n, siempre con esa actitud positiva de 'la vida es maravillosa', pide una cerveza. El electr�n, despu�s de un suspiro bien negativo, tambi�n pide una. Llega el momento de pagar, y el prot�n, todo entusiasmado, dice: '�Gracias amigo, la mejor cerveza!' Pero el electr�n, fiel a su naturaleza, frunce el ce�o y dice: 'Cerveza de porquer�a, no me gust� nada.' Hasta ah�, todo normal, �verdad? Pero de repente, entra un neutr�n. Y ah� se arma un alboroto. El due�o del bar sale furioso para echarlo. Yo, intrigado, pregunto: '�Qu� pasa, qu� sucede?' Y el due�o me responde, '�Ese tipo es un gorr�n, no tiene para pagar... no carga nada!'",8,6,0,"Ciencia",6,"Part�culas"),
new(10,"Epil�ptico multiusos","�Han o�do el de qu� es un epil�ptico en una ba�era? Una lavadora. S�, es terrible, lo s�. Pero me hizo pensar, si eso es una lavadora, �qu� ser�a un epil�ptico en una discoteca? �Una bola de disco?",2,9,3,"Salud",1,""),
new(11,"Enfrascados en un l�o ","Dos viejos amigos se encuentran despu�s de muchos a�os. Uno le dice al otro, '�Sabes que tengo un hijo en la facultad de medicina?' El otro, impresionado, pregunta, '�En serio? �Y en qu� a�o est�?' 'No, est� en un frasco.' Me hizo pensar, eso es llevar el concepto de 'estudiante perpetuo' a un nivel completamente nuevo.",4,6,1,"Ciencia",6,""),
new(12,"La inteligencia te persigue, pero t� eres m�s r�pido ","Hoy en d�a, todo es inteligente, �no? Tienes tu smartphone, tu smart TV... hasta tu reloj es m�s inteligente que t�. Compr� un frigor�fico inteligente el otro d�a y ahora se niega a abrirse porque dice que estoy comiendo demasiado tarde. �Mi propio frigor�fico me est� juzgando!",4,3,0,"Tecnolog�a",4,""),
new(13,"M�s r�pido que la velocidad de tu fealdad","Empec� a ir al gimnasio porque mi doctor me dijo que necesitaba ejercicio. El primer d�a, el entrenador me pregunta, '�Cu�l es tu meta?' Le digo, 'Quiero impresionar a una mujer.' Entonces me muestra la secci�n de cardio y dice, 'Esta m�quina te ayudar� a correr m�s r�pido.' Y yo le digo, eso me ayudar� a que me vea mejor?  'No, eso te ayudar� a moverte tan rapido que no vea tu rostro.'",5,2,0,"Bienestar",2,""),
new(14,"Pensando fuera del sueldo m�nimo","En el trabajo, mi jefe siempre dice, 'Hay que pensar fuera de la caja.' Y yo siempre pienso, 'Me encantar�a, pero mi cub�culo es una caja.' Un d�a, decido tomarlo literalmente y me siento fuera de mi cub�culo. Y cuando mi jefe pasa, le digo, 'Estoy pensando fuera de la caja.' No se ri�. Ahora mi caja es un poco m�s peque�a.",4,3,0,"Social",7,""),
new(15,"Redes antisociales","Las redes sociales son geniales. Te permiten ser odiado por gente de todo el mundo, no solo por tus amigos y familiares. Y lo mejor es que puedes ser juzgado por desconocidos que no tienen nada mejor que hacer que comentar en tus fotos: 'Esa no es tu mejor pose.' Gracias, desconocido, tu aprobaci�n es lo que me faltaba para completar mi d�a.",6,3,0,"Social",7,""),
new(16,"Veg-anemicos, ahora es personal","Comer saludable es una tendencia tan rara. Pagas el triple por comida que sabe a cart�n. Ahora, siempre hay alguien que dice, 'Es un gusto adquirido.', y generalmente es un compa�ero vegano. Sabes que mas es adquirido amigo vegano? La anemia, se que tu sabes de eso.",4,7,1,"Bienestar",2,""),
new(17,"Eliminar y Olvidar: Relaciones Modernas","Las relaciones en la era digital son complicadas. Antes te preocupabas si te dejaban en visto, ahora te preocupa si te eliminaron de sus historias de Instagram. Y si alguien te bloquea, es como si te hubieran borrado de la existencia. �Recuerdas tenias una relacion y terminaba en persona? Bueno, para eso tendr�as que haber estado en una relacion primero.",4,6,1,"Tecnolog�a",4,""),
new(18,"Padre rico, padre pobre","Volar es una experiencia �nica. Siempre me pregunto por qu� en los aeropuertos te tratan como un criminal y un rey al mismo tiempo. Te registran como si fueras a escapar de prisi�n, pero en el avi�n te ofrecen bebidas como si estuvieras en un bar exclusivo. Y si te quejas de algo, el personal de vuelo te mira como si estuvieras sacrificando a tu hijo. Por favor, solo les ped� que lo mandar�n en la bodega para tener mas espacio yo.",6,6,1,"Lujo",5,""),
new(19,"Corriendo hacia la Felicidad: La Rutina de McDieta","Me inscrib� en un gimnasio porque me dijeron que era bueno para la salud mental. Lo que no me dijeron es que tambi�n era un golpe brutal a mi autoestima. Estoy all�, corriendo en la cinta, y a mi lado hay alguien corriendo dos veces m�s r�pido. Pero bueno, aprend� la lecci�n, ahora salgo a correr todos los d�as, y en vez de ir al gimnasio corro frente a un McDonald. Los mejores 5 minutos de mi d�as.",5,5,0,"Bienestar",2,""),
new(20,"Viaje en llorona clase","Viajar en avi�n se supone que es un lujo. Pero, �alguna vez has estado en un vuelo de 10 horas en clase turista? Es como jugar a 'Twister' con desconocidos. Y siempre hay un beb� llorando. Siempre. Cuando compras el asiento en la web deber�as poder ver si estas cerca de un bebe o no, as� al menos ya te vas mentalizando, o puedes tomarte una botella de ron para ir dormido todo el viaje.",6,3,0,"Lujo",5,""),
new(21,"Cuando la Bater�a Dice 'Adi�s","Ahora todo el mundo est� obsesionado con los autos el�ctricos. 'Salva el medio ambiente', dicen. Pero nadie habla de la ansiedad de quedarse sin bater�a en medio de la nada. Al menos con la gasolina, puedes caminar avergonzado a una estaci�n. Con un el�ctrico, �Qu� haces? �Le pides a un granjero que te deje enchufar tu auto a una de sus vacas? Es decir, se que los granjeros hacen cosas raras, pero no creo que lleguen a ese extremo",5,7,2,"Tecnolog�a",4,"")
    };

    NPCData[] npcDB = new NPCData[]
    {
new(1, 5f,8,new int[]{2,2,2,3,1,0,1,1}, new string[]{}),
new(2, 3f,9,new int[]{1,3,2,2,1,1,2,1}, new string[]{"Alzheimer"}),
new(3, 4f,7,new int[]{2,3,3,4,0,0,1,1}, new string[]{"Oncologo"}),
new(4, 6f,10,new int[]{1,2,2,3,2,0,0,1}, new string[]{}),
new(5, 2f,7,new int[]{0,3,3,1,0,1,2,1}, new string[]{"Part�culas"}),
new(6, 1f,5,new int[]{1,2,2,2,1,0,1,1}, new string[]{}),
new(7, 3f,4,new int[]{1,2,0,0,1,0,2,1}, new string[]{"Part�culas", "Oncologo"}),
new(8, 5f,6,new int[]{1,1,4,4,1,1,1,1}, new string[]{}),
new(9, 3f,10,new int[]{1,1,2,2,0,1,1,1}, new string[]{}),
new(10,1f,2,new int[]{0,4,1,1,1,0,0,0}, new string[]{"Part�culas"}),
new(11,2f,4,new int[]{0,1,1,0,0,0,1,0}, new string[]{"Alzheimer"}),
new(12,4f,8,new int[]{3,1,4,3,2,0,3,3}, new string[]{}),
new(13,3f,4,new int[]{2,1,2,2,4,1,2,2}, new string[]{}),
new(14,2f,2,new int[]{1,2,2,3,4,1,2,1}, new string[]{})
    };
}