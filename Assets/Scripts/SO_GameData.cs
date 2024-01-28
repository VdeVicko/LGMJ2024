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
    public float Score = 0;
    public float HappinessTotal = 0;
    public float IrritationTotal = 0;
    public float SuccessTotal = 0;
    public float indictment = 0;
    public float Popularity = 0;

    public NPCData[] GetNPCDataByLevel(int levelId)
    {
        NPCData[] data = new NPCData[6]; 

        data[0] = npcDB[0];
        data[1] = npcDB[0];
        data[2] = npcDB[0];
        data[3] = npcDB[0];
        data[4] = npcDB[0];
        data[5] = npcDB[0];


        return data;
    }

    public JokeData GetNewRandomJoke()
    {
        int rnd = Random.Range(0, jokes.Length);

        return jokes[rnd];
    }

    JokeData[] jokes = new JokeData[] 
    {
new(1,"Conversando con las zapatillas 'Converse'","Estaba con un amigo el otro día y lo veo hablando solo. Me acerco y le pregunto, '¿Qué haces hablando con tus zapatillas?' Y él, con la mayor seriedad del mundo, me responde, 'Pues dice Converse'. Me lo quedo mirando raro, y el solo se queda pensando y dice, 'Oye, es publicidad engañosa si no responden, ¿no crees?' Allí recordé que sus papas eran hermanos y todo cobró sentido.",2,5,1,"",0,""),
new(2,"El alemán 'Alzheimer' del que no me olvido","Fui al médico el otro día porque estaba teniendo problemas de memoria. Le pregunto al doctor, '¿Quién es ese hombre alemán que me hace olvidar las cosas?' Y el doctor, sin perder el ritmo, me dice 'Alzheimer'. Yo pensé, 'Vaya, debe ser un tipo famoso, porque no hay día que no se me olvide su nombre.'",3,6,1,"Salud",1,"Alzheimer"),
new(3,"Que se necesita para colgar un cuadro de Jesús","Estaba en una exposición de arte el otro día y me encontré con un cuadro de Jesús. Y empiezo a reflexionar sobre las diferencias entre el cuadro y el propio Jesús. Llegué a la conclusión de que solo necesitas un clavo para colgar el cuadro. Es un poco oscuro, lo sé, pero luego pensé que al menos el cuadro no te juzgará por tus pecados.",4,5,1,"Religion",8,""),
new(4,"Chiste 4","El otro día, la mamá de mi esposa visitó a su medico y le pregunto: 'Doctor, ¿Qué me dijo antes? ¿Géminis, Libra?' Y él me responde con seriedad, 'Cáncer'. Ahí me di cuenta de que tal vez leer el  horóscopo  puede traer mas problemas de lo que parece.",3,3,0,"Esoterismo",3,""),
new(5,"Chiste 5","Mi esposa toda la vida a sido esotérica, y ya cansa. El otro día me dice, vino un astrologo a ver a mi papa y me dijo que es cáncer. Yo sabiendo que si papá nació en diciembre le digo: Mujer, estás mal, tu papa no puede ser cáncer. Resulta que mi mujer también es disléxica, no el que vino no era astrologo, era oncólogo.",4,4,1,"Esoterismo",3,"Horoscopo"),
new(6,"Chiste 6","Escuché a dos jubilados charlando el otro día. Uno le dice al otro, 'Juan, estoy mal, cada mañana a las 7 voy al baño.' Y Juan, le responde, '¿Y eso qué tiene de malo?' 'Que me levanto a las 8.' Ah, la vejez, esa época de la vida en la que tu cuerpo se convierte en un despertador muy eficiente.",3,4,0,"Salud",1,""),
new(7,"Chiste 7","Las mamas de ahora no son como las de antes. Yo tenia un vecinito que le decía a su mama, 'Mamá, mamá, ¿me das una galleta?' Y ella, le dice 'Están encima de la nevera.' Pero el niño insiste, 'Mamá, es que no tengo brazos.' Y la madre, le responde, 'Ah… sin brazos no hay galletas.' Pobre mi amigo, le decíamos capitán Garfio.",4,7,2,"Salud",1,""),
new(8,"Chiste 8","Estaba pensando el otro día sobre cómo la infancia varía tanto dependiendo de dónde creces. Me acordé de esta historia de dos niños, uno rico y otro pobre, hablando sobre sus comidas en casa. El niño rico, presumiendo un poco, le dice al niño pobre, 'En mi casa comemos a la carta: lo que pedimos, nos lo sirven.' Imagínense, menú personalizado en casa, el sueño de todo gourmet infantil. Pero el niño pobre, sin perder el ritmo, le contesta, 'Ah, eso no es nada. En mi casa también comemos a la carta, pero es un poco diferente: el que saca la carta más alta, come.",6,6,1,"",0,""),
new(9,"Chiste 9","Estaba en un bar el otro día, y presencié algo totalmente inesperado. Entran un protón y un electrón y se sientan en la barra. El protón, siempre con esa actitud positiva de 'la vida es maravillosa', pide una cerveza. El electrón, después de un suspiro bien negativo, también pide una. Llega el momento de pagar, y el protón, todo entusiasmado, dice: '¡Gracias amigo, la mejor cerveza!' Pero el electrón, fiel a su naturaleza, frunce el ceño y dice: 'Cerveza de porquería, no me gustó nada.' Hasta ahí, todo normal, ¿verdad? Pero de repente, entra un neutrón. Y ahí se arma un alboroto. El dueño del bar sale furioso para echarlo. Yo, intrigado, pregunto: '¿Qué pasa, qué sucede?' Y el dueño me responde, '¡Ese tipo es un gorrón, no tiene para pagar... no carga nada!'",8,6,0,"Ciencia",6,"Partículas"),
new(10,"Chiste 10","¿Han oído el de qué es un epiléptico en una bañera? Una lavadora. Sí, es terrible, lo sé. Pero me hizo pensar, si eso es una lavadora, ¿qué sería un epiléptico en una discoteca? ¿Una bola de disco?",2,9,3,"Salud",1,""),
new(11,"Chiste 11","Dos viejos amigos se encuentran después de muchos años. Uno le dice al otro, '¿Sabes que tengo un hijo en la facultad de medicina?' El otro, impresionado, pregunta, '¿En serio? ¿Y en qué año está?' 'No, está en un frasco.' Me hizo pensar, eso es llevar el concepto de 'estudiante perpetuo' a un nivel completamente nuevo.",4,6,1,"Ciencia",6,""),
new(12,"Chiste 12","Hoy en día, todo es inteligente, ¿no? Tienes tu smartphone, tu smart TV... hasta tu reloj es más inteligente que tú. Compré un frigorífico inteligente el otro día y ahora se niega a abrirse porque dice que estoy comiendo demasiado tarde. ¡Mi propio frigorífico me está juzgando!",4,3,0,"Tecnología",4,""),
new(13,"Chiste 13","Empecé a ir al gimnasio porque mi doctor me dijo que necesitaba ejercicio. El primer día, el entrenador me pregunta, '¿Cuál es tu meta?' Le digo, 'Quiero impresionar a una mujer.' Entonces me muestra la sección de cardio y dice, 'Esta máquina te ayudará a correr más rápido.' Y yo le digo, eso me ayudará a que me vea mejor?  'No, eso te ayudará a moverte tan rapido que no vea tu rostro.'",5,2,0,"Bienestar",2,""),
new(14,"Chiste 14","En el trabajo, mi jefe siempre dice, 'Hay que pensar fuera de la caja.' Y yo siempre pienso, 'Me encantaría, pero mi cubículo es una caja.' Un día, decido tomarlo literalmente y me siento fuera de mi cubículo. Y cuando mi jefe pasa, le digo, 'Estoy pensando fuera de la caja.' No se rió. Ahora mi caja es un poco más pequeña.",4,3,0,"Social",7,""),
new(15,"Chiste 15","Las redes sociales son geniales. Te permiten ser odiado por gente de todo el mundo, no solo por tus amigos y familiares. Y lo mejor es que puedes ser juzgado por desconocidos que no tienen nada mejor que hacer que comentar en tus fotos: 'Esa no es tu mejor pose.' Gracias, desconocido, tu aprobación es lo que me faltaba para completar mi día.",6,3,0,"Social",7,""),
new(16,"Chiste 16","Comer saludable es una tendencia tan rara. Pagas el triple por comida que sabe a cartón. Ahora, siempre hay alguien que dice, 'Es un gusto adquirido.', y generalmente es un compañero vegano. Sabes que mas es adquirido amigo vegano? La anemia, se que tu sabes de eso.",4,7,1,"Bienestar",2,""),
new(17,"Chiste 17","Las relaciones en la era digital son complicadas. Antes te preocupabas si te dejaban en visto, ahora te preocupa si te eliminaron de sus historias de Instagram. Y si alguien te bloquea, es como si te hubieran borrado de la existencia. ¿Recuerdas tenias una relacion y terminaba en persona? Bueno, para eso tendrías que haber estado en una relacion primero.",4,6,1,"Tecnología",4,""),
new(18,"Chiste 18","Volar es una experiencia única. Siempre me pregunto por qué en los aeropuertos te tratan como un criminal y un rey al mismo tiempo. Te registran como si fueras a escapar de prisión, pero en el avión te ofrecen bebidas como si estuvieras en un bar exclusivo. Y si te quejas de algo, el personal de vuelo te mira como si estuvieras sacrificando a tu hijo. Por favor, solo les pedí que lo mandarán en la bodega para tener mas espacio yo.",6,6,1,"Lujo",5,""),
new(19,"Chiste 19","Me inscribí en un gimnasio porque me dijeron que era bueno para la salud mental. Lo que no me dijeron es que también era un golpe brutal a mi autoestima. Estoy allí, corriendo en la cinta, y a mi lado hay alguien corriendo dos veces más rápido. Pero bueno, aprendí la lección, ahora salgo a correr todos los días, y en vez de ir al gimnasio corro frente a un McDonald. Los mejores 5 minutos de mi días.",5,5,0,"Bienestar",2,""),
new(20,"Chiste 20","Viajar en avión se supone que es un lujo. Pero, ¿alguna vez has estado en un vuelo de 10 horas en clase turista? Es como jugar a 'Twister' con desconocidos. Y siempre hay un bebé llorando. Siempre. Cuando compras el asiento en la web deberías poder ver si estas cerca de un bebe o no, así al menos ya te vas mentalizando, o puedes tomarte una botella de ron para ir dormido todo el viaje.",6,3,0,"Lujo",5,""),
new(21,"Chiste 21","Ahora todo el mundo está obsesionado con los autos eléctricos. 'Salva el medio ambiente', dicen. Pero nadie habla de la ansiedad de quedarse sin batería en medio de la nada. Al menos con la gasolina, puedes caminar avergonzado a una estación. Con un eléctrico, ¿Qué haces? ¿Le pides a un granjero que te deje enchufar tu auto a una de sus vacas? Es decir, se que los granjeros hacen cosas raras, pero no creo que lleguen a ese extremo",5,7,2,"Tecnología",4,"")
    };

    NPCData[] npcDB = new NPCData[] {
        new(1,
            1,
            new int[]{1,2,3},
            new string[]{"starwars", "gatos"}),
         new(1,
            1,
            new int[]{1,2,3},
            new string[]{})
    };
}