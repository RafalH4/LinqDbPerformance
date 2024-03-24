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
