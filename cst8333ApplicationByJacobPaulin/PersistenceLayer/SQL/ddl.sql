CREATE TABLE IF NOT EXISTS vegetableRecords(
   `id`              INT NOT NULL AUTO_INCREMENT PRIMARY KEY
  ,`REF_DATE`        VARCHAR(7)
  ,`GEO`             VARCHAR(50)
  ,`DGUID`           VARCHAR(50)
  ,`Type_of_product` VARCHAR(30)
  ,`Type_of_storage` VARCHAR(40)
  ,`UOM`             VARCHAR(15)
  ,`UOM_ID`          INT 
  ,`SCALAR_FACTOR`   VARCHAR(10) 
  ,`SCALAR_ID`       INT 
  ,`VECTOR`          VARCHAR(7) 
  ,`COORDINATE`      VARCHAR(10) 
  ,`VALUE`           INTEGER 
  ,`STATUS`          VARCHAR(1)
  ,`SYMBOL`          VARCHAR(30)
  ,`TERMINATED`      VARCHAR(30)
  ,`DECIMALS`        INT 
);

CREATE INDEX IDX_RefDate ON vegetableRecords(REF_DATE);
CREATE INDEX IDX_GEO ON vegetableRecords(GEO);
CREATE INDEX IDX_TypeOfProduct ON vegetableRecords(Type_of_product);