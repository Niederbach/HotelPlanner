
-----------------------
SELECT * FROM Customers



----------------------
SELECT
	RoomId,
	RoomNumber,
	 CASE 
        WHEN RoomType = 0 THEN 'enkelrum' 
        WHEN RoomType = 1 THEN 'dubbelrum' 
    END AS RoomType,
	IsActive,
	CASE 
		WHEN HasExtraBed = 0 THEN 'Nej'
		WHEN HasExtraBed = 1 THEN 'Ja'
	END AS HasExtraBed,
	RoomSize
FROM Rooms


----------------------
SELECT * FROM Bookings


----------------------
SELECT 
	* 
FROM Rooms 
WHERE IsActive = 1
ORDER BY RoomNumber

---------------------
SELECT * 
FROM Customers AS c
INNER JOIN Bookings AS b
ON c.CustomerId = b.customerId
INNER JOIN Rooms AS r
ON b.RoomId = r.RoomId
