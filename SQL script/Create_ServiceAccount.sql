-- Create a login for the service account
CREATE LOGIN ServiceAccount
    WITH PASSWORD = 'ElephantNoodlesWater8124!';

-- Map the login to a user in the newly created database
USE MartinHuiDatabase;
CREATE USER ServiceAccount FOR LOGIN ServiceAccount;

-- Grant appropriate permissions to the user within the database
-- Example: Granting SELECT, INSERT, UPDATE, DELETE permissions
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO ServiceAccount;