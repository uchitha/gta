# Guess the Animal Game
This code is developed as part of a coding exercise for Empired recruitement. The given time frame is 2 hours. I took nearly 3 hours though.

## Current Status
* A working state console app in .net core 2.0

## Pre-requisites & Instructions
* Need to have .net core 2.0
* Clone the repository and cd to root folder
* `dotnet build`
* `dotnet run`

## Improvements
* The application runs on in memory using EFCore in memory capabilities. 
It's possible to run on a EF core supported database without any code changes to core game. Use the relevant db provider instead of inmemory. 

* The game data should be modelled as a [`Binary Search Tree`](https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181). It's the most efficient data structure for this kind of search activity. It will scale well with a larger data set. 

* Unit Tests should be written

* Logging - Log formatters may be modified for a better user experience

* Usability - Should allow the user to play multiple times without rerunning the application

* Data loading - It's possible to [use a json file to seed data](http://thedatafarm.com/uncategorized/seeding-ef-with-json-data/). That should get rid of some plumbing code

* Self learning - Should add capability of the application to add more animals 

