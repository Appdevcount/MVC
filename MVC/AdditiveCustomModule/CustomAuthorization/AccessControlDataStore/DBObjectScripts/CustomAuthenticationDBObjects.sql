Create Table UserProfile
(
UserID Bigint identity primary key ,
Username varchar(100),
Password varchar(100),
Email varchar(100),--Optional
RetryAttempt int,--Optional
LockedOut bit,--Optional
CreatedDate datetime,--Optional
UserActive bit,
RoleID Bigint,
constraint [FK_Role] foreign key (RoleID) references Role(RoleID)
)

Create Table Role
(
RoleID bigint identity primary key,
RoleType varchar(100),
RoleDescription varchar(250)
)

--Create Procedure AuthenticateUser @Username varchar(100),@Password varchar(100),@AuthenticationStatus int=0 out
--as
--Begin
--Declare @UserExist int
----Declare @AuthorizationStatus int

--Select @UserExist = COUNT(UserName) from UserProfile
-- where UserName = @UserName and Password = @Password and LockedOut=0
----Select RoleId from UserProfile
---- where UserName = @UserName and Password = @Password 
  
-- if(@UserExist >0)
-- Begin
--select @AuthenticationStatus=1
-- End
-- Else
-- Begin
--select  @AuthenticationStatus=0
-- End

--End


--Create Procedure Authorize @Username varchar(100),@Password varchar(100),@AuthenticationStatus int=0 out
--as
--Begin
--Declare @UserExist int
----Declare @AuthorizationStatus int

--Select @UserExist = COUNT(UserName) from UserProfile
-- where UserName = @UserName and Password = @Password and LockedOut=0
----Select RoleId from UserProfile
---- where UserName = @UserName and Password = @Password 
  
-- if(@UserExist >0)
-- Begin
--select @AuthenticationStatus=1
-- End
-- Else
-- Begin
--select  @AuthenticationStatus=0
-- End

--End
