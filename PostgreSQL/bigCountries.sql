-- retrive big countires information
SELECT name as name , population as population , area as area
FROM world 
where area >= 3000000 or population >=25000000