﻿//необхідно створити консольний проект з класом, який зчитує config.json файл, в якому записана конфігурація підключення до бази даних, опціональний параметр string param1 і обов'язковий параметр bool param2. Підключитись до бази даних і вивести зчитані параметри.

using ReadConfig;

var config = new ConfigReader(@"C:\Users\brati\source\repos\ReadConfig\ReadConfig\config.json");
config.LoadConfig();
