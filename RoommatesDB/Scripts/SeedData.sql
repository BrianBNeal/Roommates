/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Room 
    ([Name], MaxOccupancy)
VALUES 
    ('Front Bedroom', 4),
    ('Back Bedroom', 6),
    ('Living Room', 6),
    ('Kitchen', 2),
    ('Attic', 20),
    ('Basement', 12);


INSERT INTO Roommate
    (FirstName, LastName, RentPortion, MoveInDate, RoomId)
VALUES
    ('Wilma', 'Heartgoon', 10, '2019-10-31', 3),
    ('Juan', 'Piesapestosos', 10, '2019-10-31', 5),
    ('Karen', 'Kidsthesedays', 50, '1981-07-01', 1);


INSERT INTO Chore ([Name])
VALUES 
    ('Taking out the trash'), 
    ('Wash the dishes'), 
    ('Water the plants'), 
    ('Vacuum'), 
    ('Change air filters')

INSERT INTO RoommateChore 
    (RoommateId, ChoreId)
VALUES
    (2, 2),
    (3, 2),
    (1, 4)