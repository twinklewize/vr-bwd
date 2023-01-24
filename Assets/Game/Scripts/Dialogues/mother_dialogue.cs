using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mother_dialogue : MonoBehaviour
{
    public GameObject actorText;
    public GameObject actorCanvas;
    public Text playerText;
    private game_controller gameController;

    public GameObject mother;
    public GameObject mother_with_glasses;

    private int current_sequence = 0;
    private int сurrent_step = -1;

    private int sucess_quest_sequence = 2;
    private int failed_quest_sequence = 1;

    private int winSequence = 8;
    private int loseSequence = 5;

    private DialogueStep[][] sequences = {
        new DialogueStep[]{
        new DialogueStep("Ох, милочка, я тебя сразу и не заметила! Ты у меня такой красавицей стала. Вот только вчера бегала в своем сиреневом сарафанчике за голубями, а сейчас вся в делах, вечно сидишь за своими картинами! Ну ка иди обними мамашу.", "Кажется вы меня спутали с мисс Крейл", 1, "Простите, у вас все хорошо?", 1),
        new DialogueStep("Вы уж простите меня. Глаза уже совсем не те, что в молодости. Меня зовут Ольга. Вы не поможете мне найти очки? Иначе наш диалог будет довольно затруднительным.", "Боюсь у меня нет выбора"),
    },

        new DialogueStep[]{
        new DialogueStep("Вы уже нашли мои очки? Я без них совершенно ничего не вижу, вот вчера летал по дому голубь, весь день пыталась его прогнать. А потом оказалось, что это Альфред запускает бумажные самолетики. Вот же старый шалун.", "Боюсь, что нет"),
        },

        new DialogueStep[]{
        new DialogueStep("Вы уже нашли мои очки?  Я без них совершенно ничего не вижу, вот вчера летал по дому голубь, весь день пыталась его прогнать. А потом оказалось, что это Альфред запускает бумажные самолетики. Вот же старый шалун.", "Конечно, можете их забрать! Но не могли бы вы мне больше рассказать о происходящем?"),
        new DialogueStep("Разве что-то произошло. Как интересно. Всегда мечтала оказаться в центре криминальных событий. Странно, что дочка меня ни о чем не предупредила.", "Разве вы не видите, весь дом стал черно-белым!", 2, "Может быть вы помните что-то подозрительное?", 2),
        new DialogueStep("Доча, у нее сегодня очередной художественный конкурс. Она к нему готовилась целый месяц. Так радовалась, говорила, что написала свою лучшую картину. А теперь что-же с ней будет. Господи, какие страсти. Нужно срочно ей позвонить!", "Знаете, я приехал сюда, помочь вашей дочери, а вы можете помочь мне", 3),
        new DialogueStep("Конечно, конечно. Есть у меня одна догадка. Только никому о ней не рассказываете. Знаете, зачем я пришла в мастерскую к дочке? Я ищу старинные волшебные камни. Они давно принадлежат нашей семье. По легенде их владелец сможет управлять цветами во всем мире. Не спроста она у меня художницей стала. Пока я их искала, я и посеяла свои очки", "И как же ваши поиски?", 4),
        new DialogueStep("Боюсь, что камни утеряны, их нигде нет, вы конечно можете поискать их по дому, но боюсь это не увенчается успехом", "Я попробую их найти", -1, "Боюсь мне не до этого", -1),
        },

        new DialogueStep[]{
        new DialogueStep("Вы так и не отыскали волшебные камни цвета, дающую могущество их обладателю, которые пришли Кристине в наследство через десятки поколений нашего рода?", "Простите, я их не видел"),
        new DialogueStep("Знаете, я все поняла, во всем виноваты вы! Вы и только вы. Странный мужчина пробравшийся в наш дом. Это вы украли камни. Я вызываю полицию!", "Но мэм, я всего лишь хочу помочь"),
        new DialogueStep("Не хочу больше ничего слышать, проваливайте", "Молча, уйти"),
        },

        new DialogueStep[]{
        new DialogueStep("Вы так и не отыскали волшебные камни цвета, дающую могущество их обладателю, которые пришли Кристине в наследство через десятки поколений нашего рода?", "Простите, я их не видел"),
        new DialogueStep("Знаете, я все поняла, во всем виноваты вы! Вы и только вы. Странный мужчина пробравшийся в наш дом. Это вы украли камни. Я вызываю полицию!", "Но мэм, я всего лишь хочу помочь"),
        new DialogueStep("Не хочу больше ничего слышать, проваливайте", "Молча уйти"),
        },

         new DialogueStep[]{
        new DialogueStep("Живо, проваливайте из моего дома. Полиция уже в пути", "Молча уйти")
        },

        new DialogueStep[]{
        new DialogueStep("Зачем вы опять пришли", "Кажется я раскрыл преступление!", 1, "Извините, что потревожил")
        },

        new DialogueStep[]{
        new DialogueStep("Ах да, и кто же по вашему виноват?", "Все вы встроем!", 1),
        new DialogueStep("Так значит вы и курьера сюда приплели?", "Я про вас, Альфреда и Эмму", 2),
         new DialogueStep("И что же мы по вашему сделали?", "Конечно же похители Кристину", 3),
         new DialogueStep("Да как вы смеете, причем же здесь дом и камни", "Вы покрасили дом в черно-белый цвет", 4),
         new DialogueStep("Какая же я дура, я же говорила Эмме спрятать банки от краски", "Вы хотели продать камни подороже", 5),
         new DialogueStep("Кажется уже нет смысла скрывать. Да, Кристина мне никакая не дочь. Альфред просто подделал права на ваше имя, представился детективом и запер Кристину в кладовке на кухне, а затем мы покрасили дом", "Именно это я и хотел услышать", 6),
         new DialogueStep("Понятно, что эти два недоумка не могут держать язык за зубами, но как вы раскрыли меня?", "И кроме того, всем известно, что Кристина сирота", 7),
         new DialogueStep("Но так же известно, что у нее есть тетушка, которую она воспринимает как родную мать, боюсь ваши доказательства незначительны", "В газетах писали, что Кристина купила камни на аукционе", 8),
          new DialogueStep("Какой кошмар!", "Я рад, что вызываю в вас страх", 7),
        },

        new DialogueStep[]{
        new DialogueStep("Вы все еще ждете пока приедет полиция?", "Я должен все проконтроллировать"),
        },

};


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            playerText.enabled = true;
            if (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One))
            {

            }
        }
    }

    //playerText.text = txt;
    //playerText.enabled = false;

    void StartDialogue()
    {
        playerText.text = "";
        сurrent_step = 0;
    }


    void StopDialogue()
    {
        сurrent_step = -1;
        playerText.text = "Нажмите A, чтобы начать диалог";
        playerText.enabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        actorText.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class DialogueStep
{
    public string text { get; set; }
    public string firstAnswer { get; set; }
    public string secondAnswer { get; set; }
    public int nextOnFirst { get; set; }
    public int nextOnSecond { get; set; }


    public DialogueStep(string text, string firstAnswer, int nextOnFirst = -1, string secondAnswer = "",  int nextOnSecond = -1)
    {
        this.text = text;
        this.firstAnswer = firstAnswer;
        this.secondAnswer = secondAnswer;
        this.nextOnFirst = nextOnFirst;
        this.nextOnSecond = nextOnSecond;
    }
}