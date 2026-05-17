---------------------------------------------------
-- DELETE OLD DATA
---------------------------------------------------

DELETE FROM MemberWorkoutPlan;
DELETE FROM WorkSchedule;
DELETE FROM Payment;
DELETE FROM Member;
DELETE FROM WorkoutPlan;
DELETE FROM Trainer;
DELETE FROM Membership;

---------------------------------------------------
-- RESET IDENTITY
---------------------------------------------------

DBCC CHECKIDENT ('MemberWorkoutPlan', RESEED, 0);
DBCC CHECKIDENT ('WorkSchedule', RESEED, 0);
DBCC CHECKIDENT ('Payment', RESEED, 0);
DBCC CHECKIDENT ('Member', RESEED, 0);
DBCC CHECKIDENT ('WorkoutPlan', RESEED, 0);
DBCC CHECKIDENT ('Trainer', RESEED, 0);
DBCC CHECKIDENT ('Membership', RESEED, 0);

---------------------------------------------------
-- MEMBERSHIP
---------------------------------------------------

INSERT INTO Membership (Type, Duration, Price)
VALUES
('Basic',30,400),
('Standard',30,500),
('Premium',30,700),
('Quarterly',90,1200),
('VIP',365,5000);

---------------------------------------------------
-- TRAINER
---------------------------------------------------

INSERT INTO Trainer (Name, Phone, Specialization, Salary)
VALUES
('Ahmed Hassan','01011111111','Bodybuilding',8000),
('Mohamed Ali','01022222222','Fitness',7500),
('Sara Adel','01033333333','Yoga',7000),
('Khaled Samy','01044444444','CrossFit',8500),
('Nour Emad','01055555555','Cardio',7200),
('Youssef Tarek','01066666666','Strength',9000),
('Mona Ashraf','01077777777','Pilates',6800);

---------------------------------------------------
-- WORKOUT PLAN
---------------------------------------------------

INSERT INTO WorkoutPlan
(PlanName, Description, DifficultyLevel, TrainerID)
VALUES
('Beginner Plan','Basic training',1,1),
('Muscle Gain','Mass building',4,1),
('Weight Loss','Fat burning',3,2),
('Yoga Flex','Yoga exercises',2,3),
('CrossFit','CrossFit program',5,4),
('Cardio Blast','Cardio workout',3,5),
('Strength Builder','Strength training',4,6),
('Pilates Core','Pilates exercises',2,7);

---------------------------------------------------
-- MEMBERS (50)
---------------------------------------------------

INSERT INTO Member
(Name, JoinDate, Email, Phone, MembershipID)
VALUES
('Member 1',GETDATE(),'member1@gmail.com','01100000001',1),
('Member 2',GETDATE(),'member2@gmail.com','01100000002',2),
('Member 3',GETDATE(),'member3@gmail.com','01100000003',3),
('Member 4',GETDATE(),'member4@gmail.com','01100000004',4),
('Member 5',GETDATE(),'member5@gmail.com','01100000005',5),
('Member 6',GETDATE(),'member6@gmail.com','01100000006',1),
('Member 7',GETDATE(),'member7@gmail.com','01100000007',2),
('Member 8',GETDATE(),'member8@gmail.com','01100000008',3),
('Member 9',GETDATE(),'member9@gmail.com','01100000009',4),
('Member 10',GETDATE(),'member10@gmail.com','01100000010',5),

('Member 11',GETDATE(),'member11@gmail.com','01100000011',1),
('Member 12',GETDATE(),'member12@gmail.com','01100000012',2),
('Member 13',GETDATE(),'member13@gmail.com','01100000013',3),
('Member 14',GETDATE(),'member14@gmail.com','01100000014',4),
('Member 15',GETDATE(),'member15@gmail.com','01100000015',5),
('Member 16',GETDATE(),'member16@gmail.com','01100000016',1),
('Member 17',GETDATE(),'member17@gmail.com','01100000017',2),
('Member 18',GETDATE(),'member18@gmail.com','01100000018',3),
('Member 19',GETDATE(),'member19@gmail.com','01100000019',4),
('Member 20',GETDATE(),'member20@gmail.com','01100000020',5),

('Member 21',GETDATE(),'member21@gmail.com','01100000021',1),
('Member 22',GETDATE(),'member22@gmail.com','01100000022',2),
('Member 23',GETDATE(),'member23@gmail.com','01100000023',3),
('Member 24',GETDATE(),'member24@gmail.com','01100000024',4),
('Member 25',GETDATE(),'member25@gmail.com','01100000025',5),
('Member 26',GETDATE(),'member26@gmail.com','01100000026',1),
('Member 27',GETDATE(),'member27@gmail.com','01100000027',2),
('Member 28',GETDATE(),'member28@gmail.com','01100000028',3),
('Member 29',GETDATE(),'member29@gmail.com','01100000029',4),
('Member 30',GETDATE(),'member30@gmail.com','01100000030',5),

('Member 31',GETDATE(),'member31@gmail.com','01100000031',1),
('Member 32',GETDATE(),'member32@gmail.com','01100000032',2),
('Member 33',GETDATE(),'member33@gmail.com','01100000033',3),
('Member 34',GETDATE(),'member34@gmail.com','01100000034',4),
('Member 35',GETDATE(),'member35@gmail.com','01100000035',5),
('Member 36',GETDATE(),'member36@gmail.com','01100000036',1),
('Member 37',GETDATE(),'member37@gmail.com','01100000037',2),
('Member 38',GETDATE(),'member38@gmail.com','01100000038',3),
('Member 39',GETDATE(),'member39@gmail.com','01100000039',4),
('Member 40',GETDATE(),'member40@gmail.com','01100000040',5),

('Member 41',GETDATE(),'member41@gmail.com','01100000041',1),
('Member 42',GETDATE(),'member42@gmail.com','01100000042',2),
('Member 43',GETDATE(),'member43@gmail.com','01100000043',3),
('Member 44',GETDATE(),'member44@gmail.com','01100000044',4),
('Member 45',GETDATE(),'member45@gmail.com','01100000045',5),
('Member 46',GETDATE(),'member46@gmail.com','01100000046',1),
('Member 47',GETDATE(),'member47@gmail.com','01100000047',2),
('Member 48',GETDATE(),'member48@gmail.com','01100000048',3),
('Member 49',GETDATE(),'member49@gmail.com','01100000049',4),
('Member 50',GETDATE(),'member50@gmail.com','01100000050',5);

---------------------------------------------------
-- PAYMENTS
---------------------------------------------------

INSERT INTO Payment
(Amount, PaymentMethod, PaymentDate, MemberID)
SELECT
500,
CASE
WHEN MemberID % 2 = 0 THEN 'Visa'
ELSE 'Cash'
END,
GETDATE(),
MemberID
FROM Member;

---------------------------------------------------
-- WORK SCHEDULE
---------------------------------------------------

INSERT INTO WorkSchedule
(ScheduleDate, StartTime, EndTime, Hall, TrainerID, PlanID)
VALUES
('2026-05-20','09:00','10:00',1,1,1),
('2026-05-20','10:00','11:00',2,2,2),
('2026-05-20','11:00','12:00',3,3,3),
('2026-05-20','12:00','13:00',4,4,4),
('2026-05-20','13:00','14:00',5,5,5);

---------------------------------------------------
-- MEMBER WORKOUT PLAN
---------------------------------------------------

INSERT INTO MemberWorkoutPlan
(MemberID, PlanID, StartDate, EndDate)
SELECT
MemberID,
((MemberID - 1) % 8) + 1,
GETDATE(),
DATEADD(MONTH,3,GETDATE())
FROM Member;