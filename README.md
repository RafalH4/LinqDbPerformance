Generate Books:
```
DECLARE @i INT = 1;
DECLARE @book_count INT = 100000;

WHILE @i <= @book_count
BEGIN
    INSERT INTO Books (Title, Author, ISBN, PublishedDate)
    VALUES 
    ('Title ' + CAST(@i AS NVARCHAR), 'Author ' + CAST(@i AS NVARCHAR), 'ISBN' + CAST(@i AS NVARCHAR), DATEADD(day, -@i, GETDATE()));
    SET @i = @i + 1;
END;
```

Generate Readers:
```
DECLARE @i INT = 1;
DECLARE @reader_count INT = 50000; -- Liczba czytelników do wygenerowania

WHILE @i <= @reader_count
BEGIN
    INSERT INTO Readers (Name, Email, MembershipStartDate)
    VALUES 
    ('Name ' + CAST(@i AS NVARCHAR), 'email' + CAST(@i AS NVARCHAR) + '@example.com', DATEADD(day, -@i, GETDATE()));
    SET @i = @i + 1;
END;
```

Generate Loans
```
DECLARE @reader_count INT;
DECLARE @book_count INT;
DECLARE @reader_id INT;
DECLARE @book_id INT;
DECLARE @i INT = 1;
DECLARE @loan_count INT = 200000; -- Liczba wypożyczeń do wygenerowania

SELECT @reader_count = COUNT(*) FROM Readers;
SELECT @book_count = COUNT(*) FROM Books;

WHILE @i <= @loan_count
BEGIN
    SET @reader_id = (1 + CAST(RAND() * @reader_count AS INT));
    SET @book_id = (1 + CAST(RAND() * @book_count AS INT));
    
    DECLARE @random_days INT;
    SET @random_days = (CAST(RAND() * 365 AS INT));
    DECLARE @issue_date DATE = DATEADD(day, -@random_days, GETDATE());
    
    SET @random_days = (1 + CAST(RAND() * 30 AS INT));
    DECLARE @due_date DATE = DATEADD(day, @random_days, @issue_date);

    INSERT INTO Loans (BookId, ReaderId, IssueDate, DueDate)
    VALUES
    (@book_id, @reader_id, @issue_date, @due_date);

    SET @i = @i + 1;
END;
```
