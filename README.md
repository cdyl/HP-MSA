# HP-MSA

## Purpose
The purpose of this system is to provide a mobile based application that displays storage analytics for a series of storage units belonging to HP. The application generates graphical and visual representations of the data depending on how the user chooses to view it. The application periodically has its data updated to ensure data accuracy and reliability.

## Functionality
The app will allow users to:
1. View data for an individual system
2. View data aggregated across all of their systems
3. Search for systems that fit specific criteria
4. Filter displayed systems by specific criteria
5. Receive alerts when the data indicates a problem with one of the user’s systems

## Future Requirements
1. Real Time Updates
The app needs to dynamically update the information about systems based on real time updates from the database instead of relying on pre-uploaded data.
2. Authentication
The app needs to support a login/logout feature but does not need to lock features behind authenticated user accounts. The future requirement would be to implement an authentication system so that certain functions would only appear to the proper registered users.
3. Export Dashboard View as PDF
The app needs the ability to export the dashboard view as a PDF for an easy ability to share current statistics or keep records of the previous states of the system.
4. Capacity Trend Prediction
The app needs to predict when drives would approach max capacity based on historical data to be able to proactively alert users when they are approaching their maximum capacity.
