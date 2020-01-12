# TU_Shortest_Path_In_Graph_Visualization

Описание

Приложението представлява визуализация и имплементация на алгоритъм на Дейкстра за намиране на къс път в не насочен, тегловен, произволно голям граф. Приложението е написано с .Net Framework, спазва добрите практики за създаването на програми чрез ООП парадигмата и следва SOLID принципи за качествен код. Визуализацията е постигната с помощта на Windows Forms. Тя се състои от 2 форми – Graph Creator и Dijkstra Algorithm. Graph Creator формата се използва за създаване и променяне на графа, а Dijkstra Algorithm се използва за визуализация на стъпките на самият алгоритъм.

	Приложението е разделено на 4 проекта:

1.	TU_Shortest_Path_In_Graph_Visualization – Главният проект съдържащ двете форми и началния клас Program от които се стартира програмата. 
2.	TU_Shortest_Path_In_Graph_Visualization.Models – Съдържащ логиката за върховете, ребрата и класа Graph, в които е имплементацията на алгоритъма.
3.	TU_Shortest_Path_In_Graph_Visualization.Drawing – Съдържащ логиката за рисуване на върховете и ребрата по екрана.
4.	TU_Shortest_Path_In_Graph_Visualization.IO – Съдържащ логиката записване в и четене от Xml файл на граф.

Функционалност:

	Приложението подържа следната функционалност:
  
•	Добавяне на връх.
•	Избиране на връх
•	Премахване на избора на връх.
•	Премахване на избран връх.
•	Задаване на избран връх за начален.
•	Задаване на избран връх за краен.
•	Добавяне на ребро с избрана тежест между 2 върха.
•	Избиране на ребро.
•	Премахване на избора на ребро.
•	Премахване на избрано ребро.
•	Променяне на теглото на избрано дърво.
•	Промяна на върховете, които избрано ребро свързва.
•	Записване на дърво във Xml файл.
•	Четене на дърво от Xml файл.
•	Генериране на случайно създаден граф с до 200 върха и с до 19900 ребра.
•	Визуализация на алгоритъм на Дейкстра стъпка по стъпка, с описание на извършените действия, състоянието на не/посетени листове, текущо избран връх и разстоянието на всеки връх от началния.

