# HappyGamesTask
FirstCommit

В грі реалізовно 2 головні способи руху об'єкта за кліком. Перший - "Рух за дистанцією" (ЗЕЛЕНИЙ  круг), другий - "Рух за часом" (ЧЕРВОНИЙ круг).

Перший спосіб плавно рухає об'єкт на вказану в інспекторі дистанцію (default - 5 units) за секунду. Дистанція може збільшуватись
відносно кількості позицій, які треба пройти, помноженої на коефіцієнт, який також вказується в інспекторі (default - 3).

Другий спосіб плавно рухає об'єкт по позиціям за вказаний в інспекторі час (default - 2 с). Таймер обнуляється при кожному додаванні позиції.
Тобто об'єкт проходить всі позиції за вказаний час від останнього кліка.

Також існує 2 способи саме руху об'єкта - звичайний та рух дугою.

В звичайному способі об'єкт рухається прямолінійно від позиції до позиції.
В русі за дугою об'єкт рухається від позиції до позиції "По дузі". Величина дуги визначається дистанцією та вказаною в інспекторі змінною.

Структура GUI:
З верхнього правого боку знаходиться Slider для налаштування загальної швидкості.
З нижнього правого боку знаходиться кнопка для входу в налаштування.
В меню налаштувань можливо обрати, які об'єкти будуть відображатись гравцеві та спосіб руху (звичайний чи по дузі).
Для закриття меню налаштувань потрібно клацнути поза меню налаштувань.

Структура коду:
BaseMove - скрипт (базовий клас) для руху об'єкта.
"AddPosition()" - додає нову позицію до колекції.
"Update()" - перевіряє наявність нової позиції та, якщо така є, то встановлюється для об'єкту, до якого цей скрипт прикріпляний.
"SetCurve()" - встановлення режиму руху по дузі.
"CalculateCurvePosition()" - обчислення позиції на дузі. 

MoveByDistance - скрипт (похідний від BaseMove) для руху об'єкта "За дистанцією" зі швидкістю, вказаною в змінних
Змінна "baseSpeed" - базова швидкість об'єкта
Змінна "additionalSpeed"- швидкість, яка додається в залежності від кількості позицій

MoveByTime - скрипт (похідний від BaseMove) для руху об'єкта "За часом" зі швидкістю, залежною від часу, вказаному в змінній
Змінна "timeForMove" - швидкість, з якою об'єкт має пройти всі позиції. Обнуляється при додаванні нової позиції

TouchController - скрипт для контролю натискань
"GetTouchPosition()" - повертає true та Vector2(out), якщо гравець натискає на екран, та не торкається UI.

BallController - скрипт для контролю об'єктів з наявним компонентом BaseMove та, відповідно, похідних від нього.
Змінна "Speed" - глобальна швидкість
"Update()" - перевіряє на наявність нової позиції (функція TouchController.GetTouchPosition()) та додає її до дочірніх об'єктів з наявним компонентом BaseMove.

SettingsController - скрипт для контролю налаштувань гри.
