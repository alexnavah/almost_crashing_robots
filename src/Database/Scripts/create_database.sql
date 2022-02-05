CREATE TABLE MissionInput (
	Id			int IDENTITY(1,1) NOT NULL,
	RawString	nvarchar(max) NOT NULL,
	OutputId	int NULL,
	CONSTRAINT PK_MissionInput_Id PRIMARY KEY (Id)
);

CREATE TABLE MissionOutput (
	Id					int IDENTITY(1,1) NOT NULL,
	RawString			nvarchar(max) NOT NULL,
	ExploredPercentage	DECIMAL(2,2) NULL,
	SuccessPercentage	DECIMAL(2,2) NULL,
	InputId				int NOT NULL,
	CONSTRAINT PK_MissionOutput PRIMARY KEY (Id)
);