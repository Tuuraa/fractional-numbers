_Данный класс был разработан на языке `C#`_.
Он позволяет спокойно работать с дробными числами, производить математические вычисления, находить целую часть дробного чила, приводить к другим типам данных. Для данного класса были перегружены самые важные и нужные методы, такие как метод `Equals()`, который возвращает `true`, если у двух дробных чисел совпадают числитель и знаменатель, метод `ToString()`, возвращающий строковое представление дробного числа, например, `"3/4"`. Подробнее все методы и свойства описаны ниже.

<h2 >Конструкторы класса</h2>

+ Первый конструктор принимает два числа типа `Int32`, первое число - числитель, второе число знаменатель.
```C#
var frac1 = new Fractional(1, 2);
```
+ Второй конструктов принимает такое же число `Fractional` и создает подобную копию.
```C#
var frac1 = new Fractional(1, 2);
var frac2 = new Fractional(frac1);
```
```C#
var frac = new Fractional(new Fractional(1, 2));
```
+ В третем конструкторе можно вводить число в виде строки, например, `"-3/4"`.
```C#
var frac1 = new Fractional("3/4");
var frac2 = new Fractional("-5/3");
```

<h2> Методы </h2>

+  `GetDenominator()` возвращает знаменатель.
```C#
Fractional frac = new Fractional(1, 2);
Console.WriteLine(frac.GetDenominator());
```
+  `GetNumerator()` возвращает числитель.
```C#
Fractional frac = new Fractional(1, 2);
Console.WriteLine(frac.GetNumerator());
```

+  `GetWholeNumber()` возвращает целое число нашего `Fractional` в виде `Int32`.
```C#
Fractional frac = new Fractional(3, 2);
Console.WriteLine(frac.GetWholeNumber());
```

+  ` GetDecimal()` возвращает целое число нашего `Fractional` в виде `double`.
```C#
Fractional frac = new Fractional(1, 2);
Console.WriteLine(frac.GetDecimal());
```

+  ` GetPositivelyDecimal()` возвращает целое положительное число нашего `Fractional` в виде `double`.
```C#
Fractional frac = new Fractional(-1, 2);
Console.WriteLine(frac.GetPositivelyDecimal());
```

+  ` Swap()` меняет местами числитель с знаменателем
```C#
Fractional frac = new Fractional(1, 2);
frac.Swap();
```

+  ` CreateWholeNumber()` формирует целое число в нашем `Fractional`, изменяя числитель и знаменатель.
```C#
Fractional frac = new Fractional(5, 4);
frac.CreateWholeNumber();
```
