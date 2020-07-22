
USE DBProject2
GO

/*----------------------------------------------------------------*/
/*-----------------------------SignUp-----------------------------*/
/*----------------------------------------------------------------*/

----------------------------(1)-------------------------------

/*
returns status = 0 if successful
		status = 1 if email not found
		status = 2 if password is wrong

*/

create procedure Login

@email varchar(30),
@password varchar(20),
@status int output,
@ID int output,
@type int output,
@Users varchar(30) output

as
begin
	if exists(select * from LoginTable where email=@email)
	BEGIN
		if @password = (select password from LoginTable where email=@email)
		BEGIN
			select @ID = LoginID, @type = [type] from LoginTable where email=@email
            select @Users = Name from Users where UserID = @ID
			set @status = 0
		END

		else
		BEGIN
			set @status = 2
			set @ID = 0
			set @type = 0
		END
	END

	else
	BEGIN
		set @status = 1
		set @ID = 0
		set @type = 0
	END
end




GO
create procedure UserSignup

@name varchar(20),
@phone char(15),
@address varchar(40),
@date Date,
@gender char(1),
@password varchar(20),
@email varchar(30),
@department varchar(30),
@status int output,
@ID int output

as
begin

	if not exists(select * from LoginTable where email=@email)
	begin
		insert into LoginTable values(@password, @email, 1)

		select @id = LoginID from LoginTable where email=@email

		insert into Users values(@id, @name, @phone, @address, @date, @gender,@department)
		set @status = 1
	end
	
	else
	begin
		set @status = 0
	end

end


GO
CREATE procedure AddTicket
@Name varchar(30) ,
@DateT Date,
@Users varchar(30),
@Descriptions varchar(1000),
@Category varchar(30),
@StatusP varchar(15),
@Asignee varchar(30)

AS
BEGIN

		
        insert into Ticket values(@DateT, @Name, @Users, @Descriptions, @Asignee,@Category,@StatusP)
END

GO

create procedure Get_Ticket

@dID int,

@Name varchar(30) output,
@DateT varchar(15) output,
@Users varchar(30) output,
@Descriptions varchar(1000) output,
@Category varchar(30) output,
@StatusP varchar(30) output,
@Asignee varchar(30) output

as
begin
	select @name=Name, @DateT=DateT, @Users=Users,@Descriptions = Descriptions, @Category = Category, @StatusP = StatusP, @Asignee = Asignee from Ticket where TicketID = @dID
end
