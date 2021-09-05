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
Print '### START POST DEPLOYMENT'

Print 'START CaroleNashRenewal'

--BEGIN TRANSACTION CaroleNashRenewal
--:r ..\Data\Client.sql
--:r ..\Data\OnlineRenewalsProcessingData.sql
--:r ..\Data\OnlineRenewalsStatus.sql
--:r ..\Data\Policy.sql
--IF @@ERROR = 0 COMMIT TRAN CaroleNashRenewal ELSE ROLLBACK TRAN CaroleNashRenewal

Print 'END CaroleNashRenewal'