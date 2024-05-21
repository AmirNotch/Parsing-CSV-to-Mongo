1) Реализовать парсер данных из файла DH_HS5_HS2_E2_Data_corr_V2.csv в MongoDB.

Шаги для настройки копирования файла
Добавьте файл CSV в проект: Убедитесь, что файл DH_HS5_HS2_E2_Data_corr_V2.csv добавлен в проект в папку Data.

Настройте свойства файла:

В обозревателе решений (Solution Explorer) найдите ваш файл CSV в папке Data.
Щелкните правой кнопкой мыши на файл и выберите "Свойства" (Properties).
В свойствах файла установите:
Build Action: Content
Copy to Output Directory: Copy if newer или Copy always


Используя команду "db.SensorDataCollection.find().sort({DateTime: 1}).limit(1)"
видим что первая строка спарселась точно.
![image](https://github.com/AmirNotch/Parsing-CSV-To-MongoDB/assets/69799846/5228bfe5-f345-4ceb-bde7-0e09967a0da7)
Так же видим что выдаёт MongoDB
![image](https://github.com/AmirNotch/Parsing-CSV-To-MongoDB/assets/69799846/e8b3bf4c-773c-48a0-bd9a-d6338fcff856)

Затем 

Используя команду "db.SensorDataCollection.find().sort({DateTime: -1}).limit(1)"
видим что последняя строка спарселась точно.
![image](https://github.com/AmirNotch/Parsing-CSV-To-MongoDB/assets/69799846/7186b392-5105-4604-bba6-d3f703242dd7)
Так же видим что выдаёт MongoDB
![image](https://github.com/AmirNotch/Parsing-CSV-To-MongoDB/assets/69799846/d68b0081-a8ef-4d87-b8bc-87b5a4b241ac)

Так же видим что MSTest прошёл проверку
![image](https://github.com/AmirNotch/Parsing-CSV-To-MongoDB/assets/69799846/bf9b33cc-4a7d-4cd3-af1b-e79436ccf254)



