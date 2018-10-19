* from DOS command line:
sqlite3 C:\Users\Public\tax_rates.sqlite3

*** under sqlite3 prompt "sqlite>", run:
*
CREATE TABLE tax_rates
( 
  threshold_bottom number NOT NULL,
  threshold_top number NULL,
  tax_startup number NOT NULL,
  super_rate number NOT NULL
);

*
INSERT INTO tax_rates
VALUES (0,18200,0,0),
(18201,37000,0,19),
(37001,87000,3572,32.5),
(87001,180000,19822,37),
(180001,NULL,54232,45);