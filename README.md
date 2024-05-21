![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/153e4242-ee5f-4513-b257-86009c091d74)1) Реализовать парсер данных из файла DH_HS5_HS2_E2_Data_corr_V2.csv в MongoDB.

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
![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/3ca94e50-3bfb-456a-98d4-b0d00c546da0)

Так же видим что выдаёт MongoDB
![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/f00f350f-bb24-4434-98e9-f33cec7017d8)

Затем 

Используя команду "db.SensorDataCollection.find().sort({DateTime: -1}).limit(1)"
видим что последняя строка спарселась точно.
![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/5c79ec79-97fd-47e7-ac26-2ff884005972)

Так же видим что выдаёт MongoDB
![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/5daf1ee0-e867-46c9-9f12-ce9e5a022335)


Так же видим что MSTest прошёл проверку
![image](https://github.com/AmirNotch/Parsing-CSV-to-Mongo/assets/69799846/3bc57e65-a052-46c7-9e7a-8a565537d1f7)
