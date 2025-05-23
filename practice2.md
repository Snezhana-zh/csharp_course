## Предисловие.

Для сдачи заданий создайте в каждом из проектов "App" и "AppTests" папку "Practice2", все файлы с решениями и тестами этих решений создавайте внутри этих папок.

## Задание 1.

RnD-специалист нашего маркетплейса узнал в умной книжке про так называемый [закон Бенфорда](https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%BA%D0%BE%D0%BD_%D0%91%D0%B5%D0%BD%D1%84%D0%BE%D1%80%D0%B4%D0%B0). С помощью этого закона он хочет проверить, насколько честно выставляются цены на товары у конкурентов. Ваша задача - написать метод, который будет парсить входной текстовый поток по словам и получать статистику - сколько раз каждая цифра стоит на месте старшего разряда в числах.

Метод должен вернуть массив чисел, в котором на i-ой позиции находится статистика для цифры i.

Подсказка: словом считается любое непрерывное буквоцифровое сочетание.

### Код метода в проекте: 
```c#
// file: Benford.cs
static int[] GetBenfordStatistics(string text)
{
	var statistics = new int[10];
	
	// code here
	
	return statistics;
}
```

## Задание 2.

В процессе регистрации продавца на маркетплейсе нужно понимать, что перед нами реальный человек, а не злоумышленник, который вводит случайные символы в поля ввода нашей системы регистрации для ИНН ФЛ и ИП. Кроме того, есть риск того, что если не сделать валидацию входных данных, то мы породим большой поток бесполезных запросов в органы государственной регистрации и маркетплейс просто отрубят от интеграции. Нужно реализовать метод для валидации ИНН. Гарантируется, что входная строка состоит только из символов-цифр.

Подсказка 1: алгоритмы валидации словесно описаны [здесь](https://info.gosuslugi.ru/articles/%D0%92%D0%B0%D0%BB%D0%B8%D0%B4%D0%B0%D1%86%D0%B8%D1%8F/)

Подсказка 2: на вход может прийти строка, отличная от 10 и 12 символов.

Подсказка 3: алгоритмы валидации ИНН основаны на вычислении скалярного произведения, можно вынести этот код как общий и оформить его в виде отдельного метода.

### Код метода: 
```c#
// file: Requisites.cs
static bool IsValidInn(string inn) 
{
	// code here
}

// общий метод для скалярного произведения
//
```

## Задание 3.

Кроме валидации вводимых реквизитов, внутри систем маркетплейса важно уметь распознавать вручную вводимые номера мобильных телефонов для работы с различными заказчиками и поставщиками. Проблема состоит в том, что эти номера телефонов передаются менеджерам через электронную почту и поэтому никакого единого формата ввода номера телефона не существует. Нужно реализовать метод, который по входной строке извлечет цифры и по ним поймет, являются ли они мобильным номером телефона в формате РФ или нет - это поможет сократить рутину менеджеров ввода номера телефона в систему.

Подсказка: номер телефона может начинаться как с '7', так и с '8'.

### Код метода: 
```c#
// file: PhoneNumber.cs
static bool TryParsePhone(string inputString, out string parsedPhone) 
{
	// code here
}
//
```

Примеры входных данных: "+7-983-313-6827", "перезвонить по номеру 89833136827 завтра", "8(983)-313-68-27".

## Задание 4.

Недавно в отделе разработки появился отдел машинного обучения. Для того, чтобы начать его работу, понадобилось изучить статистику так называемых N-грам. N-грамма — это N соседних слов в одном предложении. 2-граммы называют биграммами. 3-граммы — триграммами. Например, из текста: "She stood up. Then she left." можно выделить следующие биграммы "she stood", "stood up", "then she" и "she left", но не "up then". И две триграммы "she stood up" и "then she left", но не "stood up then". Нужно составить словарь самых частотных продолжений биграмм и триграмм.

Если есть несколько продолжений с одинаковой частотой, используйте то, которое лексикографически меньше. Для лексикографического сравнения используйте встроенный в .NET способ сравнения Ordinal, например, с помощью метода string.CompareOrdinal.

### Пример
По тексту 
```
"a b c d. b c d. e b c a d."
```
 Должен быть составлен словарь:

```
"a": "b"
"b": "c"
"c": "d"
"e": "b"
"a b": "c"
"b c": "d"
"e b": "c"
"c a": "d"
```

### Код метода.
```c#
// file: Frequency.cs
static Dictionary<string, string> FrequencyAnalysis(string inputString) 
{
	// code here
}
//
```

## Задание 5.

Инженеры отдела разработки решили сделать чат-бота реального времени для общения с клиентами маркетплейса в тех. поддержке. Интерфейс взаимодействия очень напоминает работу примитивной вычислительной стековой машины, у которой есть всего две операции:
- push для добавления строки в конец текста
- pop удаляет с конца строки указанное число символов

На уровне кода стековой машины гарантируется, что все строки начинаются со слова push или pop и представляют собой валидные команды.

Пример кода для такой машины следующий:
```
push Привет! Это снова я! Пока!
pop 5
push Как твои успехи? Плохо?
push qwertyuiop
push 1234567890
pop 27
```

В результате выполнения на выходе мы должны увидеть следующую строку: 'Привет! Это снова я! Как твои успехи?'.

Вам необходимо реализовать метод, который по входной последовательности команд для стек-машины позволяет получить результирующую строку.

Подсказка: для операции pop гарантируется, что числовой параметр не будет превышать длину имеющейся строки в момент вызова.

### Код метода.
```c#
// file: StackMachine.cs
static string CalculateString(string[] codeLines) 
{
	// code here
}
//
```