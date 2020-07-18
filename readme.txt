Team Taco - INFT3100 - Assignment Two

Team Members

	- Sean Clark c3269995

	- Aaron Moss c3282382

	- Lachlan McDonald c3259570

Home Page = landingPage.aspx

Home Page for admin = adminLandingPage.aspx

Pre-existing Site accounts (Will add when executing DB)

	Users:

		- Email: johnwick@gmail.com
		- Password: Password1#					 			

	Admin: 

		- Admin ID: 12345
		- Password: Password1#

	Products:

		- List of products will also be added for a better demo of the site

Two master pages:

	- adminMasterPage.master

		- give access to admin requirements

	- nostGamesMasterPage.master

		- general site master page

Notes:

	- SQL script is within the project folder. We have left NostalgicGamesDB.sql within the project file as well for if the correctly named SQL does not run. 

	- SSL currently runs, however would not run on one of our PCs. We are unsure if this was the site or that computers browser settings. If it does not run
	  the SSL code will need to be commented out. 

	- Email method currently in site (Reset Password), however were not able to get it to send emails. It can currently
	  get the email required just the sending process will not work. 

	- Buttons added to user master and admin master to navigate between the two to make marking easier.
	  This would not be in the main product. 

	- While Search button/bar is visable. 
	  Currently does not do anything as this was outside the scope of the project.

	- A few files are unused, however as we plan to keep building this into the future to display to potential employees they will be used. 

	- Payment page is completely dummy data and does not collect data from cart. 

	- 

References:

	- All code is ours besides one email validation on register page. Referenced in comments

Design and Coding Choices:

	- System is teired architechture as this is the objective on the project.

	- Designed to match the styling of the NES game console. 

Issues:

	- When editing product it will require you to reupload a picture, as picture is outside the scope of the 
	  project we have not fixed this issue.

	- Add to cart button with code behind is currently in the dynamically created more info page, however does not work as of now.
	  We have disabiled this button.

	- The back end for storing and collecting order details is completed. However, due to time constraints is not implemented within
	  the front end (userHistory.aspx). 
						