# My.WebApp-Tax-Calculator
Asp.net core application to process some tax inputs and output to sql and mongo.

Tech stack.
1. Asp.net core 2.1 mvc 
2. Ms sql server 2016
3. Rabbit mq messaging broker
4. Mongo db
5. Ms .net core unit tests

There are two bool flags to publish and consumer from rabbit, this can be switched off, if you do not have a local rabbit and mongo installed.
Nothing fancy, just a readonly bool been set to check or not.

:)
