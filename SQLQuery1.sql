

create database boatsolution

use  boatsolution

  create Table RegisterBoat(       

   SrId int IDENTITY(1,1) NOT NULL primary key,     

   BoatName Varchar(50),  

   BoatSpeed NUMERIC(18,2),  

   RegisterId VARCHAR(50),  

   STATUS VARCHAR(1)     

)

create Table RentOutBoat(       

   SrId int IDENTITY(1,1) NOT NULL primary key,     

   BoatName Varchar(50),    

   CustomerName VARCHAR(100),  

   STATUS VARCHAR(1)     

)

 


--Exec RegisterBoat_Add 'Abc' , 45.5
--Exec RegisterBoat_Add 'Abc' , 45.5,1

alter procedure RegisterBoat_Add    
   @BoatName Varchar(50) ,  

   @BoatSpeed NUMERIC(18,2)   ,

   @SeriesCode varchar(10) out

As      

Begin

declare @maxId  varchar(50) 
select @maxId = max(RegisterId) from RegisterBoat


if not exists( select 'X' from RegisterBoat)

begin

set @maxId = '100'
end
else
begin

      set @maxId =  SUBSTRING(@maxId, 
                  CHARINDEX('-', @maxId) + 1, 
                  10) + 1
				  end





INSERT INTO dbo.RegisterBoat

        ( BoatName ,

          BoatSpeed ,

          RegisterId ,

          STATUS

        )

VALUES  ( @BoatName ,

          @BoatSpeed,

          @maxId , -- RegisterId - varchar(50)

          'A'  -- STATUS - varchar(1)

        )             

		set @SeriesCode = @maxId
End

 
 

 

 



CREATE PROCEDURE RegisterBoat_FetchAll  

AS

    BEGIN

 

        SELECT  BoatName ,

                BoatSpeed ,

                RegisterId

        FROM    RegisterBoat

        WHERE   STATUS = 'A'

            

    END

 

 

 

 

 

--Exec RegisterBoat_FetchSingle 'Abc'

CREATE PROCEDURE RegisterBoat_FetchSingle
      @BoatName VARCHAR(50)     
AS

    BEGIN

 

        SELECT  BoatName ,

                BoatSpeed ,

                RegisterId

        FROM    RegisterBoat

        WHERE   STATUS = 'A'

        AND BoatName = @BoatName

            

    END

 

 

 

--------------------------------------------------

 

--Exec RentOutBoat_Add 'abc','Maruti'

Create procedure RentOutBoat_Add    

      

   @BoatName VARCHAR(50)  ,

   @CustomerName Varchar(100)

   

As      

Begin

 if exists(select 'x' from RentOutBoat where BoatName = @BoatName)
 begin 
 select 0
 return
 end 

 else

INSERT INTO dbo.RentOutBoat

        ( BoatName, CustomerName, STATUS )

VALUES  ( @BoatName,

          @CustomerName,

          'A'

          )     
		  
	select 1	         

End

 

 

 
 
--Exec RentOutBoat_FetchAll 'Maruti'

create PROCEDURE RentOutBoat_FetchAll   

AS

    BEGIN

        SELECT  BoatName, CustomerName

        FROM    RentOutBoat

        WHERE   STATUS = 'A'

            

    END

 

 



--Exec RentOutBoat_FetchSingle 'abc'

CREATE PROCEDURE RentOutBoat_FetchSingle ( @BoatName VARCHAR(50) )

AS

    BEGIN

        IF EXISTS ( SELECT  'X'

                    FROM    RentOutBoat

                    WHERE   BoatName = @BoatName

                            AND STATUS = 'A' )

            BEGIN

                RAISERROR('Already Register Boat',16,1)

            END        

    END

 

 



