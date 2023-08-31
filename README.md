# Banking accounts

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
The purpose of the application is to be able to add users to the bank.
For each user, the admin can open an account entering the initial amount.
If the amount is different than zero, then new transaction is created associated with the newly created account.

The UI is simple angular web application which is used for listing the users and accounts,
but also has reactive web forms in order to add new users and accounts.

## Technologies
The project is created with:
* .NET Core 7
* Angular 15

## Setup
To run this project, clone it locally execute the command `dotnet run` in terminal. Once built open `localhost:5187` in the browser.