# velib

There is a main folder Velib, it contains three parts in this folder, a folder "Host" who containes the intermediary Web service (IWS) in folder "host", a folder "Client" whoe contains client-side, a folder "MonitoringClient" who contains a monitor to supervise the IWS, i put these three folder in folder "velib", to compile these codes you need to create new WCF project in VS for "Host" and "Client", and a winform project for "MonitoringClient".

It provide four functions in my project:

* A user interface which provide three button "Get Citys", "Get City", "Get Station".
"Get Citys" will show you all citys available.
"Get City" will show you all stations of the city you choice, you need to enter a city name in left list and click "Get City".
"Get Station" will show you the information of the station you choice, you need to enter a station name and click "Get Station".

* A cache in IWS which will reduce the communication time between IWS and client-side
It contains a ObjectCache which cations all informations of the citys queried.
It contains a JArray which contains the information of current city.
  
* Asynchronous methods in both IWS and client-side, IWS use asynchronous methods to reduce the comminication time between IWS and https://api.jcdecaux.com/, client-side use asynchronous methods to reduce the time between client-side and IWS.

* A monitor with graphic interface to supervise three values， the number of client who has connected to this IWS, the average time of communication between IWS and client, the sum of the number of requests of all clients.
