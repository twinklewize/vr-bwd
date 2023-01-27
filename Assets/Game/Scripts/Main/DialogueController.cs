using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    private static Dictionary<string, Dialogue> dialogues = new Dictionary<string, Dialogue>()
    {
        {
            "Mother",
            new Dialogue(

                new Dictionary<string, DialogueStep[]>
                {
                    {
                        "First",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Ох, милочка, я тебя сразу и не заметила! Ты у меня такой красавицей стала. Вот только вчера бегала в своем сиреневом сарафанчике за голубями, а сейчас вся в делах, вечно сидишь за своими картинами! Ну ка иди обними мамашу.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Кажется вы меня спутали с мисс Крейл",
                                        "First",
                                        1
                                    ),
                                    new DialogueAnswer("Простите, у вас все хорошо?", "First", 1)
                                }
                            ),
                            new DialogueStep(
                                "Вы уж простите меня. Глаза уже совсем не те, что в молодости. Меня зовут Ольга. Вы не поможете мне найти очки? Иначе наш диалог будет довольно затруднительным.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Боюсь у меня нет выбора",
                                        "QuestFailed",
                                        action: DialogueAnswerAction.startQuest,
                                        quest: "Glasses"
                                    )
                                }
                            ),
                        }
                    },
                    {
                        "QuestFailed",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы уже нашли мои очки? Я без них совершенно ничего не вижу, вот вчера летал по дому голубь, весь день пыталась его прогнать. А потом оказалось, что это Альфред запускает бумажные самолетики. Вот же старый шалун.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Боюсь, что нет", "QuestFailed")
                                }
                            ),
                        }
                    },
                    {
                        "QuestSucceeded",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы уже нашли мои очки?  Я без них совершенно ничего не вижу, вот вчера летал по дому голубь, весь день пыталась его прогнать. А потом оказалось, что это Альфред запускает бумажные самолетики. Вот же старый шалун.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Конечно, можете их забрать! Но не могли бы вы мне больше рассказать о происходящем?",
                                        "QuestSucceeded",
                                        1,
                                        action: DialogueAnswerAction.finishQuest,
                                        quest: "Glasses"
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Разве что-то произошло. Как интересно. Всегда мечтала оказаться в центре криминальных событий. Странно, что дочка меня ни о чем не предупредила.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Разве вы не видите, весь дом стал черно-белым!",
                                        "QuestSucceeded",
                                        2
                                    ),
                                    new DialogueAnswer(
                                        "Может быть вы помните что-то подозрительное?",
                                        "QuestSucceeded",
                                        2
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Доча, у нее сегодня очередной художественный конкурс. Она к нему готовилась целый месяц. Так радовалась, говорила, что написала свою лучшую картину. А теперь что-же с ней будет. Господи, какие страсти. Нужно срочно ей позвонить!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Знаете, я приехал сюда, помочь вашей дочери, а вы можете помочь мне",
                                        "QuestSucceeded",
                                        3
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Конечно, конечно. Есть у меня одна догадка. Только никому о ней не рассказываете. Знаете, зачем я пришла в мастерскую к дочке? Я ищу старинные волшебные камни. Они давно принадлежат нашей семье. По легенде их владелец сможет управлять цветами во всем мире. Не спроста она у меня художницей стала. Пока я их искала, я и посеяла свои очки",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("И как же ваши поиски?", "QuestSucceeded", 4)
                                }
                            ),
                            new DialogueStep(
                                "Боюсь, что камни утеряны, их нигде нет, вы конечно можете поискать их по дому, но боюсь это не увенчается успехом",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я попробую их найти", "Second"),
                                    new DialogueAnswer("Боюсь мне не до этого", "Second")
                                }
                            ),
                        }
                    },
                    {
                        "Second",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы так и не отыскали волшебные камни цвета, дающую могущество их обладателю, которые пришли Кристине в наследство через десятки поколений нашего рода?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Простите, я их не видел", "Second", 1)
                                }
                            ),
                            new DialogueStep(
                                "Знаете, я все поняла, во всем виноваты вы! Вы и только вы. Странный мужчина пробравшийся в наш дом. Это вы украли камни. Я вызываю полицию!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Но мэм, я всего лишь хочу помочь",
                                        "Second",
                                        2
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Не хочу больше ничего слышать, проваливайте",
                                new DialogueAnswer[] { new DialogueAnswer("Молча, уйти", "Third") }
                            ),
                        }
                    },
                    {
                        "Third",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Живо, проваливайте из моего дома. Полиция уже в пути",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Fourth") }
                            ),
                        }
                    },
                    {
                        "Fourth",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Зачем вы опять пришли?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Кажется я раскрыл преступление!",
                                        "Fourth",
                                        1
                                    ),
                                    new DialogueAnswer("Извините, что потревожил", "Fourth")
                                }
                            ),
                            new DialogueStep(
                                "Ах да, и кто же по вашему виноват?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Все вы встроем!", "Fourth", 2)
                                }
                            ),
                            new DialogueStep(
                                "Так значит вы и курьера сюда приплели?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я про вас, Альфреда и Эмму", "Fourth", 3)
                                }
                            ),
                            new DialogueStep(
                                "И что же мы по вашему сделали?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Конечно же похитили Кристину", "Fourth", 4)
                                }
                            ),
                            new DialogueStep(
                                "Да как вы смеете, причем же здесь дом и камни",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Вы покрасили дом в черно-белый цвет",
                                        "Fourth",
                                        5
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Какая же я дура, я же говорила Эмме спрятать банки от краски",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Вы хотели продать камни подороже",
                                        "Fourth",
                                        6
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Кажется уже нет смысла скрывать. Да, Кристина мне никакая не дочь. Альфред просто подделал права на ваше имя, представился детективом и запер Кристину в кладовке на кухне, а затем мы покрасили дом",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Именно это я и хотел услышать", "Fourth", 7)
                                }
                            ),
                            new DialogueStep(
                                "Понятно, что эти два недоумка не могут держать язык за зубами, но как вы раскрыли меня?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "И кроме того, всем известно, что Кристина сирота",
                                        "Fourth",
                                        8
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Но так же известно, что у нее есть тетушка, которую она воспринимает как родную мать, боюсь ваши доказательства незначительны",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "В газетах писали, что Кристина купила камни на аукционе",
                                        "Fourth",
                                        9
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Какой кошмар!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Я рад, что вызываю в вас страх",
                                        "Win",
                                        action: DialogueAnswerAction.win
                                    )
                                }
                            ),
                        }
                    },
                    {
                        "Lose",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Живо, проваливайте из моего дома. Полиция уже в пути",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Lose") }
                            ),
                        }
                    },
                    {
                        "Win",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы все еще ждете пока приедет полиция?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Вы все еще ждете пока приедет полиция?",
                                        "Win"
                                    )
                                }
                            ),
                        }
                    },
                },
                "Mother"
            )
        },
        {
            "Courier",
            new Dialogue(
                new Dictionary<string, DialogueStep[]>
                {
                    {
                        "First",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Добрый вечер, детектив. Неужели вы пришли арестовать меня за кражу красок, которые я же сегодня утром и доставил.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я хочу просто поговорить", "First", 1)
                                }
                            ),
                            new DialogueStep(
                                "И о чем же, о том как меня держат здесь уже несколько часов и не выплачивают деньги за доставку?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я дам тебе денег", "First", 2)
                                }
                            ),
                            new DialogueStep(
                                "Апхахпхахпх, ты? Не смеши, известный детектив Роберт Авеллон, не раскрывший за последний год ни одного преступления. Нет у тебя денег",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Ты прав, я неудачник", "First", 3)
                                }
                            ),
                            new DialogueStep(
                                "Есть еще вопросы?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Прости, мне нужно прийти в себя", "Second")
                                }
                            ),
                        }
                    },
                    {
                        "Second",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "И снова вы детектив",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Хочу узнать почему ты цветной", "Second", 1)
                                }
                            ),
                            new DialogueStep(
                                "А почему ты вообще решил, что мир цветной? Может это просто затянушийся сон, в котором ты вообразил, что существуют девушки с ярко-красными губами и реки напитков карамельного цвета",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Что ты несешь?", "Second", 2)
                                }
                            ),
                            new DialogueStep(
                                "Стоит вам открыть глаза и все исчезнет, все краски смоет дождем реальности. Цвета эта сплошная выдумка, сказка, они лишь в вашей голове",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Ты случайно не дальтоник", "Second", 3)
                                }
                            ),
                            new DialogueStep(
                                "Да, вы меня раскусили, у меня полная цветовая слепота с рождения. Я понятия как выглядят эти банки краски, и ориентируюсь исключительно по названиям. Все ваше расследование не имеет для меня смысла.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Прости, мне нужно прийти в себя", "Third")
                                }
                            ),
                        }
                    },
                    {
                        "Third",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Знаете, а ведь в полной темноте слепой видит больше зрячего. Поэтому слепой не пытается отыскать свет, а именно этим вы сейчас и занимаетесь.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Помоги мне в расследовании", "Third", 1)
                                }
                            ),
                            new DialogueStep(
                                "Вы ведь не знаете, что находится за пределами дома, возможно цвет никуда и не исчезал из мира и отсутствует только в этом доме. Как жаль, что сейчас ночь, и вы никак не сможете этого проверить.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Сплошная чушь", "Third", 2)
                                }
                            ),
                            new DialogueStep(
                                "Разве вы не мечтали всю жизнь стать героем нуарного детектива, эадким Экрюлем Пуаро нашего времени?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("В детстве я любил детективы", "Third", 3)
                                }
                            ),
                            new DialogueStep(
                                "Что ж ваш звездный час настал, возможно ваша мечта сбылась, а может быть вы просто заигрались и хотите выдать желаемое за действительное.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Промолчать", "Third", 4)
                                }
                            ),
                            new DialogueStep(
                                "Если действительно хотите помощи, то тот мужчина в столовой вечно притворяется пьяным, но пока я был здесь он не выпил ни капли.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Что-то еще?", "Third", 5)
                                }
                            ),
                            new DialogueStep(
                                "Домработница вряд ли что-то смыслит в уборке, я бывал в этом доме, когда она еще здесь не работала, и здесь была абсолютная чистота",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Что скажете про Ольгу?", "Third", 6)
                                }
                            ),
                            new DialogueStep(
                                "Выглядит полной шизофреничкой, боюсь даже к ней приближаться и вам не советую",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Большое спасибо за помощь", "Win")
                                }
                            ),
                        }
                    },
                    {
                        "Win",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Надеюсь я вам помог, детектив",
                                new DialogueAnswer[] { new DialogueAnswer("Молча кивнуть", "Win") }
                            ),
                        }
                    },
                    {
                        "Lose",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Кажется вы действительно неудачник, боюсь это судьба",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Lose") }
                            ),
                        }
                    }
                },
                "Courier"
            )
        },
        {
            "Detective",
            new Dialogue(
                new Dictionary<string, DialogueStep[]>
                {
                    {
                        "First",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Приветствую, любезнейший, очень рад знакомству. Меня зовут Альфред. Я, так сказать, смотритель, присматриваю за домом, чтобы не случилось ничего из ряда вон. Но вот как видите случилось, выходит недосмотрел.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Вы очень подозрительный", "First", 1),
                                    new DialogueAnswer("Рад знакомству", "First", 2)
                                }
                            ),
                            new DialogueStep(
                                "Ну что вы, я просто немного выпил для храбрости, а то мы уже и сами все черно-белыми стали. Тут уж тяжело держаться трезвым",
                                new DialogueAnswer[] { new DialogueAnswer("Понимаю", "First", 2) }
                            ),
                            new DialogueStep(
                                "Как вы относитесь к тусовкам, детектив? Может быть поджигадрыгаем на днях?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Меня ждут расследования", "First", 3)
                                }
                            ),
                            new DialogueStep(
                                "А я ведь и сам своего рода детектив! Вот буквально на днях у нас пропало несколько бутылок довольно дорогого вина. Исходя из моих индукционно-дедукционных способностей я могу сделать вывод, что их выпил я.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Да вы шутник", "First", 4),
                                    new DialogueAnswer("Расскажите про остальных", "First", 5)
                                }
                            ),
                            new DialogueStep(
                                "Хо-хо-хо, мало кому нравится мой юмор. А вам слабо выпить литр виски залпом? Я вот такое уже проворачивал. Буквально час назад.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Довольно, расскажите про курьера?",
                                        "First",
                                        5
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Оооооо, я рад что вы спросили, я думаю курьер он во всем виноват",
                                new DialogueAnswer[] { new DialogueAnswer("Почему?", "First", 6) }
                            ),
                            new DialogueStep(
                                "Именно он приносил те акварельные краски, которые похитили пару дней назад у Кристины. Именно он, обыщите его! Это я не даю ему уйти, ведь знаю, что из-за него дом теперь черно-белый!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я попробую с ним поговорить", "Second")
                                }
                            ),
                        }
                    },
                    {
                        "Second",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Иногда мне кажется, что я просто сборник дешевых анекдотов, купленных на станции провинциального городка, чтобы заглушить стук колес плацкартного вагона.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Ваши анекдоты высший сорт", "Second", 1),
                                    new DialogueAnswer("Думаю курьер невиновен", "Second", 1)
                                }
                            ),
                            new DialogueStep(
                                "А я ведь правда когда-то был детективом, ко мне даже ФБР обращалось за помощью! Я у них конечно тоже много чему научился, например вот, документы подделывать.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Можно поподробнее", "Second", 2)
                                }
                            ),
                            new DialogueStep(
                                "Вот буквально пару дней назад всего за час изготовил водительское удостоверение на имя Роберта Авеллона. Все чистейше, не докопаешься!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Большое спасибо", "Second"),
                                    new DialogueAnswer("Обвинить во всем", "Second", 3),
                                }
                            ),
                            new DialogueStep(
                                "Ого детектив, вы считаете что дом и все эти чудеса моих рук дело? Я подозревал курьера, но кажется вы берете на себя слишком много, у вас нет доказательств",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Роберт Авеллон это я", "Second", 4)
                                }
                            ),
                            new DialogueStep(
                                "Я знаю. Но посмотрите сколько отпечатков вы оставили по дому. К тому же Кристины довольно давно нет, вы уверены, что это она вас вызвала? Возможно это вы обокрали ее и превратили дом в невесть что",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("У вас нет доказательств", "Second", 5)
                                }
                            ),
                            new DialogueStep(
                                "Вы сильно ошибаетесь детектив",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Молча уйти",
                                        "Lose",
                                        action: DialogueAnswerAction.lose
                                    )
                                }
                            ),
                        }
                    },
                    {
                        "Win",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Детектив, я уже совсем пьян! И мне хочется признаваться вам в любви. Так вот, детектив, я вас люблю. Только не говорите Эмме, она может заревновать. У нас с ней эти, как их, финтифлюшки намечаются.",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Win") }
                            ),
                        }
                    },
                    {
                        "Lose",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Ольга уже вызвала полицию",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Lose") }
                            ),
                        }
                    }
                },
                "Detective"
            )
        },
        {
            "Homekeeper",
            new Dialogue(
                new Dictionary<string, DialogueStep[]>
                {
                    {
                        "First",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Добрый вечер, господин, меня зовут Эмма. Я здешняя домработница. Работаю не так долго, но достаточно, чтобы знать о доме все. Видите эту старинную лестницу, когда-то она была в стиле рококо. А потом все завитушки поотламывались, детали стерлись, а сейчас она и вовсе выцвела. Как и весь дом. Это навевает грусть.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Здраствуйте, Эмма", "First", 1)
                                }
                            ),
                            new DialogueStep(
                                "Вы хотели что-то узнать?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Почему в доме так пыльно?", "First", 2),
                                    new DialogueAnswer("Не расскажете больше про дело?", "First", 2)
                                }
                            ),
                            new DialogueStep(
                                "Знаете, с этим черно-белым домом совсем трудно думать, я уже пару дней не прибиралась, а Альфред вечно тащит пыль с улицы в дом, вы не поможете мне найти щетку?",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Боюсь у меня нет выбора",
                                        "QuestFailed",
                                        action: DialogueAnswerAction.startQuest,
                                        quest: "Brush"
                                    )
                                }
                            )
                        }
                    },
                    {
                        "QuestFailed",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы уже нашли мою щетку? Пыль пожирает меня, боюсь в этой войне мне победить все труднее и труднее. Пожалуйста, поторопитесь!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Я пока что ее не видел!", "QuestFailed")
                                }
                            ),
                        }
                    },
                    {
                        "QuestSucceeded",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Вы уже нашли мою щетку? Пыль пожирает меня, боюсь в этой войне мне победить все труднее и труднее. Пожалуйста, поторопитесь!",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Ваша щетка, моя госпожа",
                                        "QuestSucceeded",
                                        1,
                                        action: DialogueAnswerAction.finishQuest,
                                        quest: "Brush"
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Ой, я так рада. Вы прямо мой кумир! Что бы я без вас делала. В этом доме сейчас так грустно. Еще и Крис давно не было",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Рад помочь", "QuestSucceeded", 2)
                                }
                            ),
                            new DialogueStep(
                                "Не хотите чаю? Правда у нас его нет. Просто решила, что вежливо будет предложить.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Расскажите про дом", "QuestSucceeded", 3)
                                }
                            ),
                            new DialogueStep(
                                "Какая скука. Детектив, а вы разбираетесь в искусстве? Я вот обожаю импрессионистов.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer(
                                        "Я бы хотел послушать про дом",
                                        "QuestSucceeded",
                                        4
                                    )
                                }
                            ),
                            new DialogueStep(
                                "Видите ли раньше этот дом был довольно ярким, Кристина сама его разрисовывала, в технике пуантилизма. Представьте сколько это заняло времени. Но силы природы не милосердны.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Дом?", "QuestSucceeded", 6),
                                    new DialogueAnswer("Пуантилизм?", "QuestSucceeded", 5)
                                }
                            ),
                            new DialogueStep(
                                "Техника пуантилизма? Если не перемешивать цвета, а ставить чистый цвет маленькими точками, то он кажется ярче и картина словно светится. И если раньше дом ближе к свету, то теперь он утопает во тьме.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Вы мне надоели", "QuestSucceeded", 7)
                                }
                            ),
                            new DialogueStep(
                                "Лучше расскажу про пуантилизм. Если не перемешивать цвета, а ставить чистый цвет маленькими точками, то он кажется ярче и картина словно светится. И если раньше дом ближе к свету, то теперь он утопает во тьме. ",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Вы мне надоели", "QuestSucceeded", 7)
                                }
                            ),
                            new DialogueStep(
                                "Мне все-таки не нравятся картины Кристины, она слишко долго сидит над ними, вечно перерисовывает, придумывает каждую деталь.",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("И кто вам по душе?", "QuestSucceeded", 8)
                                }
                            ),
                            new DialogueStep(
                                "Мне ближе Моне. Обожаю Мост Ватерлоо. Когда смотришь на оригинал, а не на дешевую реплику, возникает чувство будто проваливаешься в картину. Каждый день на него смотрю",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Как интересно", "QuestSucceeded", 9)
                                }
                            ),
                            new DialogueStep(
                                "Кажется я вам надоела, что ж, больше ни скажу вам не слова",
                                new DialogueAnswer[]
                                {
                                    new DialogueAnswer("Даже про дом?", "QuestSucceeded", 10)
                                }
                            ),
                            new DialogueStep(
                                "Про него тем более",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Lose") }
                            ),
                        }
                    },
                    {
                        "Lose",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Мне больше нечего вам сказать, господин. Боюсь мое сердце принадлежит другому. Не стоит питать надежд",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Lose") }
                            ),
                        }
                    },
                    {
                        "Win",
                        new DialogueStep[]
                        {
                            new DialogueStep(
                                "Мне больше нечего вам сказать, господин. Боюсь мое сердце принадлежит другому. Не стоит питать надежд",
                                new DialogueAnswer[] { new DialogueAnswer("Молча уйти", "Win") }
                            ),
                        }
                    }
                },
                "Homekeeper"
            )
        },
    };


    public static string currentActor = "None";

    public static DialogueState state = DialogueState.none;

    public static void SuggestStart(string actor)
    {
        currentActor = actor;
        state = DialogueState.suggesting;
    }

    public static void Start(string actor)
    {
        currentActor = actor;
        state = DialogueState.started;
    }

    public static void Stop()
    {
        currentActor = "None";
        state = DialogueState.none;
    }

    public static void SetLose()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.Value.SetLose();
        }
    }

    public static void SetWin()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.Value.SetWin();
        }
    }

    public static Dialogue GetDialogue(string actor)
    {
        return dialogues[actor];
    }

    public static Dialogue GetDialogueByQuestKey(string key)
    {
        if (key == "Brush") return dialogues["Homekeeper"];
        else if (key == "Glasses") return dialogues["Mother"];
        return null;
    }

    public static bool isSuggesting(string actor)
    {
        return currentActor == actor && state == DialogueState.suggesting;
    }

    public static bool isActive(string actor)
    {
        return currentActor == actor && state == DialogueState.started;
    }

    public static bool Suggest()
    {
        return DialogueController.currentActor == "None"
            && GameController.state != GameState.call
            ;
    }
}

public enum DialogueState
{
    none,
    suggesting,
    started,
}

public class Dialogue
{
    public Dictionary<string, DialogueStep[]> sequences { get; set; }
    public string current_sequence;
    public int current_step;
    public string actor;

    public DialogueStep GetCurrentStep()
    {
        if (current_step == -1) { return null; }
        else return sequences[current_sequence][current_step];
    }

    public void Start()
    {
        current_step++;
        DialogueController.Start(actor);
    }

    public void Next(string sequence, int step)
    {
        current_sequence = sequence;
        current_step = step;
        if (current_step == -1) DialogueController.Stop();
    }

    public void SetQuestSucceeded()
    {
        current_sequence = "QuestSucceeded";
    }

    public void SetLose()
    {
        current_sequence = "Lose";
    }

    public void SetWin()
    {
        current_sequence = "Win";
    }

    public Dialogue(Dictionary<string, DialogueStep[]> sequences, string actor)
    {
        current_step = -1;
        current_sequence = "First";
        this.sequences = sequences;
        this.actor = actor;
    }
}

public class DialogueStep
{
    public string text { get; set; }
    public DialogueAnswer[] answers { get; set; }

    public DialogueStep(string text, DialogueAnswer[] answers)
    {
        this.text = text;
        this.answers = answers;
    }
}

public class DialogueAnswer
{
    public string text { get; set; }
    public string nextSequence { get; set; }
    public int nextStep { get; set; }
    public DialogueAnswerAction action { get; set; }
    public string quest { get; set; }

    public DialogueAnswer(
        string text,
        string nextSequence,
        int nextStep = -1,
        DialogueAnswerAction action = DialogueAnswerAction.none,
        string quest = ""
    )
    {
        this.text = text;
        this.nextSequence = nextSequence;
        this.nextStep = nextStep;
        this.action = action;
        this.quest = quest;
    }
}

public enum DialogueAnswerAction
{
    none,
    startQuest,
    finishQuest,
    win,
    lose,
}
