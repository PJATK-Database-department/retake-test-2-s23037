-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-06-21 08:30:56.575

-- tables
-- Table: Action
CREATE TABLE Action (
    IdAction int  NOT NULL,
    StartTime datetime  NOT NULL,
    EndTime datetime  NULL,
    NeedSpecialEquipment bit  NOT NULL,
    CONSTRAINT Action_pk PRIMARY KEY  (IdAction)
);

-- Table: FireTruck
CREATE TABLE FireTruck (
    IdFireTruck int  NOT NULL,
    OperationalNumber nvarchar(10)  NOT NULL,
    SpecialEquipment bit  NOT NULL,
    CONSTRAINT FireTruck_pk PRIMARY KEY  (IdFireTruck)
);

-- Table: FireTruck_Action
CREATE TABLE FireTruck_Action (
    IdFireTruckAction int  NOT NULL,
    AssignmentDate datetime  NOT NULL,
    IdAction int  NOT NULL,
    IdFireTruck int  NOT NULL,
    CONSTRAINT FireTruck_Action_pk PRIMARY KEY  (IdFireTruckAction)
);

-- Table: Firefighter
CREATE TABLE Firefighter (
    IdFirefighter int  NOT NULL,
    FirstName nvarchar(30)  NOT NULL,
    LastName nvarchar(50)  NOT NULL,
    CONSTRAINT IdFirefighter PRIMARY KEY  (IdFirefighter)
);

-- Table: Firefighter_Action
CREATE TABLE Firefighter_Action (
    IdFirefighter int  NOT NULL,
    IdAction int  NOT NULL,
    CONSTRAINT Firefighter_Action_pk PRIMARY KEY  (IdFirefighter,IdAction)
);

-- foreign keys
-- Reference: FireTruck_Action_Action (table: FireTruck_Action)
ALTER TABLE FireTruck_Action ADD CONSTRAINT FireTruck_Action_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: FireTruck_Action_FireTruck (table: FireTruck_Action)
ALTER TABLE FireTruck_Action ADD CONSTRAINT FireTruck_Action_FireTruck
    FOREIGN KEY (IdFireTruck)
    REFERENCES FireTruck (IdFireTruck);

-- Reference: Table_2_Action (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Table_2_Action
    FOREIGN KEY (IdAction)
    REFERENCES Action (IdAction);

-- Reference: Table_2_Firefighter (table: Firefighter_Action)
ALTER TABLE Firefighter_Action ADD CONSTRAINT Table_2_Firefighter
    FOREIGN KEY (IdFirefighter)
    REFERENCES Firefighter (IdFirefighter);
INSERT INTO Firefighter(IdFirefighter, FirstName, LastName) VALUES (1, 'Andrew', 'Killar');
INSERT INTO Action(IdAction, StartTime, EndTime, NeedSpecialEquipment) VALUES (1, 12-08-2008, null, 1) 
INSERT INTO FireTruck(IdFireTruck, OperationalNumber, SpecialEquipment) VALUES (1, '4029', 1);
INSERT INTO FireTruck_Action(IdFireTruckAction, AssignmentDate, IdAction, IdFireTruck) VALUES (1, 10-08-2008, 1, 1);
INSERT INTO FireFighter_Action(IdFireFighter, IdAction) VALUES (1, 1);
-- End of file.

