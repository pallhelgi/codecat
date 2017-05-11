# CodeCat
Online collaborative coding program where edits made by collaborators are seen in real time.

## Features
* Create a user.
* An authorized user can 
  * create a project.
  * create documents in a project.
    * Which opens a editor for javascript.
      * Keyboard shortcuts for edtior are available inside the document.
    * MORE FORMATS TO COME??
  * save a document he has access to.
    * *Note: The document saves itself automagically every second.*
  * delete a project which he is a part of.
  * delete a document in a project which he is a part of.
  * share a project with another user.
    * Up to 10 users can work on the same document together.


## Sneak peak
Here is a sneak peak on the program with the main funtionalities.
The user is greeted with a simple and friendly front page.
There you can either sign in with an old account or create a brand new one!
**MYND AF FRONT PAGE**
The 'Sign In' and 'Sign Up' features are pretty straight forward fill out forms.
**MYND AF SIGN IN OG SIGN UP**
When the user has signed in he is able to create some cool projects with bunch of documents to write some code in. If he gets lonely he can always share the project with his friends so they can code together. No cat should be lonely!
**EINHVER SCREEN SHOT AF VIRKNINNI**
Don't worry if you accidentally go astray because this little kitten will help you find your way back to the homepage.
**404 MYND**

## Architecture layout - describe how the program is built with MVC
The program was implemented with Model-View-Controller (MVC) in ASP.NET web form.
* Models
  The models in the program contain every variable needed. They are split into entity models and viewmodels.
  * Entity Models
    Contain the neccesary variables to 
    * IdentityModels - ApplicationUser
    * ProjectModel
    * DocumentModel
  * View Models
    
    * DashboardViewModel
    * ProjectViewModel
    * DocumentViewModel
    * AccountViewModel
* Views
  * Describe
* Controllers
  * Describe

## Coding standards(rules) and tools
*	Visual Studio 2015
* Git and Github for version control and issue tracking.
* Operating systems tested
  * Windows 10
* Browser tested
  * Google ChromeC:\Users\Hrafnaklukka\Documents\Verklegt2\CodeCat\CodeCat\Views\Dashboard\AddProject.cshtml
  * Mozilla Firefox

## Members
* Eydís Arnardóttir
* Eyrún Lára Hansen
* Guðrún Valdimarsdóttir
* Ingimar Rolf Björnsson
* Páll Helgi Sigurðarson
* Sigurður Ragnar W. Brynjólfsson
