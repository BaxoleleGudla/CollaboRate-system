CREATE TABLE tblUser (
	User_ID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(50) NOT NULL UNIQUE,
	Email NVARCHAR(70) NOT NULL UNIQUE,
	PasswordHash NVARCHAR(30) NOT NULL,
	Created_At DATETIME2 DEFAULT SYSUTCDATETIME()
);

CREATE TABLE tblGroup (
	Group_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_Name VARCHAR(100) NOT NULL,
	Group_Description VARCHAR(200),
	Creator INT NOT NULL,
	Created_At DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_GROUP_USER FOREIGN KEY (Creator) REFERENCES tblUser(User_ID)
);

CREATE TABLE tblGroupMember (
	Group_Member_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_ID INT NOT NULL,
	User_ID INT NOT NULL,
	User_Role VARCHAR(10) NOT NULL CHECK (User_Role IN ('Admin', 'Member')),
	Join_Status VARCHAR(10) NOT NULL CHECK (Join_Status IN ('Pending', 'Accepted', 'Declined')),
	Joined_At DATETIME2 NULL,

	CONSTRAINT FK_GROUP_MEMBER_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID),
	CONSTRAINT FK_GROUP_MEMBER_USER FOREIGN KEY (User_ID) REFERENCES tblUser(User_ID),
	CONSTRAINT UQ_GROUP_MEMBER_GROUP_USER UNIQUE (Group_ID, User_ID)
);

CREATE TABLE tblRating (
	Rating_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_ID INT NOT NULL,
	Rater_ID INT NOT NULL,
	Ratee_ID INT NOT NULL,
	Score TINYINT NOT NULL CHECK (Score BETWEEN 1 AND 5),
	Rated_At DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_RATING_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID),
	CONSTRAINT FK_RATING_RATER FOREIGN KEY (Rater_ID) REFERENCES tblUser(User_ID),
	CONSTRAINT FK_RATING_RATEE FOREIGN KEY (Ratee_ID) REFERENCES tblUser(User_ID),
	CONSTRAINT UQ_RATING_GROUP_RATER_RATEE UNIQUE (Group_ID, Rater_ID, Ratee_ID)
);

CREATE TABLE tblMeeting (
	Meeting_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_ID INT NOT NULL,
	Meeting_Title VARCHAR(200) NOT NULL,
	Meeting_Description	VARCHAR(700) NOT NULL,
	Meeting_Date DATETIME2 NOT NULL,
	Created_At	DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_MEETING_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID)
);

CREATE TABLE tblTask (
	Task_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_ID INT NOT NULL,
	Task_Title VARCHAR(200) NOT NULL,
	Task_Description VARCHAR(700) NULL,
	Deadline DATETIME2 NOT NULL,
	Created_At DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_TASK_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID)
);

CREATE TABLE tblTaskAssignment (
	Task_Assignmet_ID INT IDENTITY(1,1) PRIMARY KEY,
	Task_ID INT NOT NULL,
	User_ID INT NOT NULL,
	Is_Completed BIT NOT NULL DEFAULT 0,
	Completed_At DATETIME2 NULL,
	Note VARCHAR(500) NULL,

	CONSTRAINT FK_TASK_ASSIGNMENT_TASK FOREIGN KEY (Task_ID) REFERENCES tblTask(Task_ID),
	CONSTRAINT FK_TASK_ASSIGNMENT_USER FOREIGN KEY (User_ID) REFERENCES tblUser(User_ID),
	CONSTRAINT UQ_TASK_ASSIGNMENT_TASK_USER UNIQUE (Task_ID, User_ID)
);

CREATE TABLE tblGroupNotification (
	Group_Notification_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_ID INT NOT NULL,
	Notification_Type VARCHAR(50) NULL,
	Notification_Message VARCHAR(200) NULL,
	Created_At DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_GROUP_NOTIFICATION_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID)
);

CREATE TABLE tblNotificationRecipient (
	Notification_Recipient_ID INT IDENTITY(1,1) PRIMARY KEY,
	Group_Notification_ID INT NOT NULL,
	User_ID INT NOT NULL,
	Is_Read BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_NOTIFICATION_RECIPIENT_GROUP_NOTIFICATION FOREIGN KEY (Group_Notification_ID) REFERENCES tblGroupNotification(Group_Notification_ID),
	CONSTRAINT FK_NOTIFICATION_RECIPIENT_USER FOREIGN KEY (User_ID) REFERENCES tblUser(User_ID)
);

CREATE TABLE tblGroupMessage (
	Message_ID INT IDENTITY(1,1) PRIMARY KEY,
	Sender_ID INT NOT NULL,
	Group_ID INT NOT NULL,
	Message_Text VARCHAR(1000) NOT NULL,
	Created_At DATETIME2 DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_SENDER_GROUP_MESSAGE FOREIGN KEY (Sender_ID) REFERENCES tblUser(User_ID),
	CONSTRAINT FK_GROUP_MESSAGE_GROUP FOREIGN KEY (Group_ID) REFERENCES tblGroup(Group_ID)
);

-- Indexes to speed up queries
-- tblGroup: index on Creator (FK)
CREATE NONCLUSTERED INDEX IDX_tblGroup_Creator
ON tblGroup (Creator);

-- tblGroupMember: indexes on Group_ID and User_ID (FKs)
CREATE NONCLUSTERED INDEX IDX_tblGroupMember_GroupID
ON tblGroupMember (Group_ID);

CREATE NONCLUSTERED INDEX IDX_tblGroupMember_UserID
ON tblGroupMember (User_ID);

-- tblRating: indexes on Group_ID, Rater_ID, Ratee_ID (FKs)
CREATE NONCLUSTERED INDEX IDX_tblRating_GroupID
ON tblRating (Group_ID);

CREATE NONCLUSTERED INDEX IDX_tblRating_RaterID
ON tblRating (Rater_ID);

CREATE NONCLUSTERED INDEX IDX_tblRating_RateeID
ON tblRating (Ratee_ID);

-- tblMeeting: index on Group_ID (FK)
CREATE NONCLUSTERED INDEX IDX_tblMeeting_GroupID
ON tblMeeting (Group_ID);

-- tblTask: index on Group_ID (FK)
CREATE NONCLUSTERED INDEX IDX_tblTask_GroupID
ON tblTask (Group_ID);

-- tblTaskAssignment: indexes on Task_ID and User_ID (FKs)
CREATE NONCLUSTERED INDEX IDX_tblTaskAssignment_TaskID
ON tblTaskAssignment (Task_ID);

CREATE NONCLUSTERED INDEX IDX_tblTaskAssignment_UserID
ON tblTaskAssignment (User_ID);

-- tblGroupNotification: index on Group_ID (FK)
CREATE NONCLUSTERED INDEX IDX_tblGroupNotification_GroupID
ON tblGroupNotification (Group_ID);

-- tblNotificationRecipient: indexes on Group_Notification_ID and User_ID (FKs)
CREATE NONCLUSTERED INDEX IDX_tblNotificationRecipient_GroupNotificationID
ON tblNotificationRecipient (Group_Notification_ID);

CREATE NONCLUSTERED INDEX IDX_tblNotificationRecipient_UserID
ON tblNotificationRecipient (User_ID);

CREATE NONCLUSTERED INDEX IDX_tblGroupMember_Status
ON tblGroupMember (Join_Status)
INCLUDE (Group_ID, User_ID);

CREATE NONCLUSTERED INDEX IDX_tblNotificationRecipient_UserID_IsRead
ON tblNotificationRecipient (User_ID, Is_Read);

CREATE NONCLUSTERED INDEX IDX_tblRating_RateeID_RatedAt
ON tblRating (Ratee_ID, Rated_At DESC);

-- Indexes for the message table
CREATE NONCLUSTERED INDEX IX_MESSAGE_GroupID_CreatedAT 
ON tblGroupMessage(Group_ID, Created_At DESC);

CREATE NONCLUSTERED INDEX IX_MESSAGE_SENDER_ID_CREATED_AT
ON tblGroupMessage(Sender_ID, Created_At DESC);

CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;
CREATE FULLTEXT INDEX ON tblGroupMessage(Message_Text)
KEY INDEX PK_tblGroup_Message;
