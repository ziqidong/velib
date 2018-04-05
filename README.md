# velib

### There are two branches in this reposities:
**first branche "master":**

There is a main folder Velib, it contains three parts in this folder, a folder "Host" who containes the intermediary Web service (IWS) in folder "host", a folder "Client" whoe contains client-side, a folder "MonitoringClient" who contains a monitor to supervise the IWS, i put these three folder in folder "velib", to compile these codes you need to create new WCF project in VS for "Host" and "Client", and a winform project for "MonitoringClient".

It provide four functions in my project:

1. A user interface which provide three button "Get Citys", "Get City", "Get Station".
![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client1.png)

at first, you need to click button "Get Citys" to get the list of city available, if not, it will show a error message

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client6.png)

"Get Citys" will show you all citys available.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client2.png)

"Get City" will show you all stations of the city you choice, you need to enter a city name in left list and click "Get City".

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client3.png)

if you enter a wrong city name, it will notice you that the name is not correct.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client4.png)

"Get Station" will show you the information of the station you choice, you need to enter a station name and click "Get Station".

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/client5.png)




2. A cache in IWS which will reduce the communication time between IWS and client-side

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/cache.png)

It contains a ObjectCache which cations all informations of the citys queried.
for example, it can look up information of stations.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/cache2.png)
  
3. Asynchronous methods in both IWS and client-side, IWS use asynchronous methods to reduce the comminication time between IWS and https://api.jcdecaux.com/, client-side use asynchronous methods to reduce the time between client-side and IWS.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/async1.png)
![image](https://github.com/ziqidong/velib/raw/master/Velib/images/async2.png)
![image](https://github.com/ziqidong/velib/raw/master/Velib/images/async3.png)


4. A monitor with graphic interface to supervise three values， the number of client who has connected to this IWS, the average time of communication between IWS and client, the sum of the number of requests of all clients.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/moni1.png)

after some clients connected to server, it will record the infomation of this connection and user of minitor can click button to get these informations

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/moni2.png)

**second branche "extension_velib":**

There is a main folder Velib, it contains one more folder than branch master, the folder "Eclient", it provide a console for users to subscribe these fonctions of server, it subscribe a fonction which can get all the information of stations of one city, at first, you need to enter a cityname, it will pass a string to server and search in a cache, if there are informations of this city, it will notice client and return the result, if not, it will tell client there are not related information and continue to find until there are informations corredpond, once it finds information, it will return the result to client.

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/eclient2.png)
![image](https://github.com/ziqidong/velib/raw/master/Velib/images/eclient3.png)

![image](https://github.com/ziqidong/velib/raw/master/Velib/images/eclient.png)

