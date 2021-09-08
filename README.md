#TimeManagementAPI
Тестовое задание (TODO - Fix model creating (Cannot create a DbSet for 'User' because this type is not included in the model for the context.))

# Сервис - Учет времени

Необходимо реализовать REST API для учета отработанного времени.

## Модель данных

1. Пользователь
Email уникален для пользователей. Фамилия и Имя обязательны.
    1. Email;
    2. Фамилия, Имя, Отчество.
2. Отчет о работе за день
За день может быть несколько записей. Все поля обязательны.
    1. Примечание;
    2. Кол-во часов;
    3. Дата.

## Задание

1. Реализовать сервис - Пользователи
Должны быть реализованы следующие методы работы с сущностью - Пользователь.
    1. Добавить/обновить/удалить пользователя;
    2. Получить список пользователей;
2. Реализовать сервис - Отчеты
    1. Добавить/обновить/удалить отчет;
    2. Получить список отчетов пользователя за указанный месяц.

## Технологический стек

- [ASP.NET](http://asp.NET) Core (.NET 5);
- PostgreSQL - база данных;
- Entity Framework - ORM
