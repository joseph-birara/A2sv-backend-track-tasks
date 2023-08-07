-- Retrieve first names, last names, cities, and states of persons along with their addresses.
-- If there is no address for a person, the person's information will still be displayed.
SELECT Person.firstName AS firstName, Person.lastName AS lastName, Address.city AS city, Address.state AS state
FROM Person
LEFT JOIN Address ON Person.personId = Address.personId;
