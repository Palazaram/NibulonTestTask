# NibulonTestTask

## Про додаток

Це веб-додаток, розроблений за допомогою ASP.NET Core MVC, що реалізує архітектуру Onion. В інтерфейсі використовуються бібліотеки jQuery і Bootstrap.

### NibulonTestTask.Core

Цей проект містить усі основні сутності програми, інтерфейси, які визначають контракти для взаємодії з даними, а також папку DTO для обміну даними між рівнями застосунку.

### NibulonTestTask.Persistence

Цей проект обробляє підключення до бази даних через клас `NibulonTestTaskDbContext`. Він включає класи конфігурації таблиць, міграції баз даних і репозиторії, які реалізують інтерфейси з `NibulonTestTask.Core`.

### NibulonTestTask.Application

У цьому проекті містяться сервіси, які використовують методи репозиторію для виконання бізнес-логіки.

### NibulonTestTask

Основний проект, який об'єднує всі вищезазначені компоненти.

## Архітектура бази даних

![image](https://github.com/user-attachments/assets/aa7346d7-48f1-422e-b030-67028a03f9b0)

## Запуск програми

Щоб запустити програму, оновіть рядок підключення до бази даних у `NibulonTestTask --> appsettings.Development.json`.

Щоб створити базу даних, відкрийте `Package Manager Console` (`View --> Other Windows --> Package Manager Console`) і виконайте команду: `dotnet ef database update -p NibulonTestTask.Persistence -s NibulonTestTask`.

Після цього скористайтеся командою `Rebuild Solution`.

## Робочий файл

Для обробки поштових індексів використовувався файл: `postindex.xlsx`.
