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

