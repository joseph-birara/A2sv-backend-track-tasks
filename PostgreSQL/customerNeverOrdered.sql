-- retrive customers who never order

SELECT Customers.name AS Customers
from Customers LEFT JOIN Orders on Orders.customerId = Customers.id 
where Orders.customerId IS NULL;