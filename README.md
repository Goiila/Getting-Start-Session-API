# Session API for CIBS 
- Copy Folder "Session_API" and Paste in same level of Folder "Controller" and "Model" on Your Project.
- Must have 3 file 
1. Session_API.cs
2. Session_API.js
3. TSI_Users_Model.cs 
and Checck namespace of your project.
--------------------------------------------------------------------------------------
# Get start with Session_API CIBS

# Easy to understand concept.
1. If Login call .postSession send with object TSI_USERS_Model go to save in Session API .
2. If client use call .getSession() and .checkStateSession() for check session Login and Bring information you get to do something.......
3. If Logout call .postSession send with object TSI_USERS_Model only EMPLOYEE_ID and LogginNow is false.
3.1 On Server site or Location:85 -- > call .postSession and clear session["Users"] .
3.2 On Client site --> Clear session["Users"] and Redirect to Server Site.

# Setting On Server site or main site(localhost:85) 
- After Login sucess call class .postSession for Insert data to Session API
- When Logout from localhost:85 or client site call class .postSession for Update data on Session API

# Setting On Client site
- Class getAllSession Get all user in Session API CIBS
- Class getSession(EMPLOYEE_CODE) Get only employee in Session API CIBS
-------------------------------------------------------------------------------------