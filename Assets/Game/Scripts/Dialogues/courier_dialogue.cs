using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courier_dialogue : MonoBehaviour
{
    public GameObject actorText;
    public GameObject actorCanvas;
    public GameObject playerText;
    public GameObject gameManager;

    private int winSequence = 3;
    private int loseSequence = 4;

    private DialogueStep[][] sequences = {
        new DialogueStep[]{
        new DialogueStep("Добрый вечер, детектив. Неужели вы пришли арестовать меня за кражу красок, которые я же сегодня утром и доставил.", "Я хочу просто поговорить", 1),
        new DialogueStep("И о чем же, о том как меня держат здесь уже несколько часов и не выплачивают деньги за доставку?", "Я дам тебе денег", 2),
        new DialogueStep("Апхахпхахпх, ты? Не смеши, известный детектив Роберт Авеллон, не раскрывший за последний год ни одного преступления. Нет у тебя денег", "Ты прав, я неудачник", 3),
        new DialogueStep("Есть еще вопросы?", "Прости, мне нужно прийти в себя"),
    },
        new DialogueStep[]{
        new DialogueStep("И снова вы детектив", "Хочу узнать почему ты цветной", 1),
        new DialogueStep("А почему ты вообще решил, что мир цветной? Может это просто затянушийся сон, в котором ты вообразил, что существуют девушки с ярко-красными губами и реки напитков карамельного цвета", "Что ты несешь?", 2),
        new DialogueStep("Стоит вам открыть глаза и все исчезнет, все краски смоет дождем реальности. Цвета эта сплошная выдумка, сказка, они лишь в вашей голове", "Ты случайно не дальтоник", 3),
        new DialogueStep("Да, вы меня раскусили, у меня полная цветовая слепота с рождения. Я понятия как выглядят эти банки краски, и ориентируюсь исключительно по названиям. Все ваше расследование не имеет для меня смысла.", "Приму к сведению"),
    },
        new DialogueStep[]{
        new DialogueStep("Знаете, а ведь в полной темноте слепой видит больше зрячего. Поэтому слепой не пытается отыскать свет, а именно этим вы сейчас и занимаетесь.", "Помоги мне в расследовании", 1),
        new DialogueStep("Вы ведь не знаете, что находится за пределами дома, возможно цвет никуда и не исчезал из мира и отсутствует только в этом доме. Как жаль, что сейчас ночь, и вы никак не сможете этого проверить.", "Сплошная чушь", 2),
        new DialogueStep("Разве вы не мечтали всю жизнь стать героем нуарного детектива, эадким Экрюлем Пуаро нашего времени?", "В детстве я любил детективы", 3),
        new DialogueStep("Что ж ваш звездный час настал, возможно ваша мечта сбылась, а может быть вы просто заигрались и хотите выдать желаемое за действительное.", "Промолчать", 4),
        new DialogueStep("Если действительно хотите помощи, то тот мужчина в столовой вечно притворяется пьяным, но пока я был здесь он не выпил ни капли.", "Что-то еще?", 5),
        new DialogueStep("Домработница вряд ли что-то смыслит в уборке, я бывал в этом доме, когда она еще здесь не работала, и здесь была абсолютная чистота", "Что скажете про Ольгу?", 6),
        new DialogueStep("Домработница вряд ли что-то смыслит в уборке, я бывал в этом доме, когда она еще здесь не работала, и здесь была абсолютная чистота", "Что скажете про Ольгу?", 6),
        new DialogueStep("Выглядит полной шизофреничкой, боюсь даже к ней приближаться и вам не советую", "Большое спасибо за помощь"),
    },

        new DialogueStep[]{
        new DialogueStep("Надеюсь я вам помог, детектив", "Молча кивнуть"),
        },

        new DialogueStep[]{
        new DialogueStep("Кажется вы действительно неудачник, боюсь это судьба", "Молча уйти"),
        },
};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //actorCanvas.enabled = true;
        }
    }
}