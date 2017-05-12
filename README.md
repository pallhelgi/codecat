# CodeCat
Online collaborative coding program where edits made by collaborators are seen in real time.

## Features
* Create a user.
* An authorized user can: 
  * create a project.
  * create documents within a project.
    * Which opens a code editor with syntax highlighting.
      * Keyboard shortcuts for edtior are available in the editor and a list of the most common ones can be viewed in a popup model
  * save a document he has access to.
    * *Note: The document saves itself automagically every second.*
  * delete a project which he is a part of.
  * delete a document in a project which he is a part of.
  * share a project with another user.
  * sort the projects by filters such as by name, if they are created by another user, by age and so on.

## Sneak peak
Here is a sneak peak of the program with the main funtionalities.

The user is greeted with a simple and friendly front page, where he can choose to log in or register for a brand new account. After he is logged in he is automatically directed to a sleek Project Dashboard, which is empty if the user hasn't created any projects or hasn't been granted access to projects created by another user. Otherwise it gives an overview of all his projects. The user can create a new project from the Dashboard page, open his existing projects and share them with a good friend, who has to be another registered user. 
When the user opens a project he enters a Document Dashboard, where he has an overview of all the documents within that project. There he can create additional documents or open existing documents. How nice!
Opening a document brings the user to the fantastic editor where he can finally write his code! If another user has been invited to collaborate on the project and both are logged in with that document open at the same time, they can see what the other one is writing in real time. Amazing, we know!

### Front page

<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/18387227_120332000748943921_1302218760_n.jpg" alt="Front Page" width="200"/>

### Sign up and sign in
The 'Sign In' and 'Sign Up' features are pretty straight forward fill out forms. No need for superfluous information, we only request an email address and a password, but promise never to spam you with emails!

<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/18425841_120332000717051007_953507242_n.jpg" alt="Register for a new account" width="200"> <img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/18447901_120332000717569579_1117722544_n.jpg" alt="Sign up, friend" width="226.5"/>

### Dashboard
When the user has signed in he is able to create some cool projects with bunch of documents to write some code in. If he gets lonely he can always share the project with his friends so they can code together. No Code::Cat should be lonely!

<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/Dashboard.JPG" alt="Dashboard" width="600" />

### Inside of a project


<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/Project.JPG" alt="Project Page" width="600" />

### Inside of a document
<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/Document.JPG" alt="Document" alt="Document" width="600" />

### Create a new project
<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/18424780_120332000725636873_374558613_n.jpg" alt="Create a new project" width="200"/>

Don't worry if you accidentally go astray because this little kitten will help you find your way back to the homepage.

### 404 page
<img src="https://github.com/eyrunh16/CodeCat/blob/master/CodeCat/Images/18471315_120332000688769752_2057557954_n.jpg" alt="This kitty is lost" width="200"/>

## Architecture layout - describe how the program is built with MVC
The program was implemented with Model-View-Controller (MVC) in ASP.NET web form.
* Models
  
  The models in the program contain every variable needed. They are split into entity models and view models.
  * Entity Models
    
    Contain the neccesary variables to store in the database.
    * IdentityModels - ApplicationUser
    * ProjectModel
    * DocumentModel
  * View Models
    
    Contains the variables and lists needed to display in the views.
    * DashboardViewModel
    * ProjectViewModel
    * DocumentViewModel
    * AccountViewModel
* Views
  
  *See 'Views' map in the project*
  
  Handles every view whicht the user sees while using the program.
* Controllers

  The controllers fetch data from the database (through service classes - see below), send it to the views and vice versa.
  * AccountController
  * DashboardController
  * DocumentController
  * ErrorController
  * HomeController
  * NoAccessController
  * ProjectController
  
In addition to the MVC structure we used service classes to talk to our database. They are the link that both adds and fetched data from the database and hands it to the right controller.

They are as following:
* UserService
* ProjectService
* UserService

## Coding standards(rules) and tools
 * Naming conventions:
   * Classes: PascalCase.
   * Functions and variables: camelCase.
   * Global variables: UPPER_CASE.
 * Curly brackets in separete lines from code.
 * Tabs used over spaces.
 * Code and comments in English.
 * Comments above functions.
 * Newline between functions and before return statements. 
 * For HTML code we rely on coding conventions from W3Schools (https://www.w3schools.com/html/html5_syntax.asp). 
 * For CSS code we rely on conventions from Primer (http://primercss.io/guidelines/#scss).  

* Tools
  *	Visual Studio 2015
  * Git and Github for version control and issue tracking.
* Operating systems tested
  * Windows 10
* Browser tested
  * Google Chrome
  * Mozilla Firefox
  * Internet Explorer
 
## Code::Cat Members
* Eydís Arnardóttir
* Eyrún Lára Hansen
* Guðrún Valdimarsdóttir
* Ingimar Rolf Björnsson
* Páll Helgi Sigurðarson
* Sigurður Ragnar W. Brynjólfsson
