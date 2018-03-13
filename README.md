# velib

I put the intermediary Web service (IWS) in folder "host" and client-side in folder "client" and put these two folder in folder "velib", to compile these codes you need to create a new WCF project in VS for "host" and a new Cosole project for "client".

It provide two functions in TD:

* A user interface which provide three button "Get Citys", "Get City", "Get Station".
"Get Citys" will show you all citys available.
"Get City" will show you all stations of the city you choice, you need to enter a city name in left list and click "Get City".
"Get Station" will show you the information of the station you choice, you need to enter a station name and click "Get Station".

* A cache in IWS which will reduce the communication time between IWS and client-side
It contains a list which type is "List<City>" which cations all informations of the citys queried.
It contains a JArray which contains the information of current city.
These two object as a cache of IWS and will reduce communication time between host and client-side.
