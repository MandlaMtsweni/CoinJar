create table coin(
  id int primary key auto_increment ,
  amount decimal(10,2),
  volume decimal(10,2),
  created_date datetime,
  updated_date datetime
);

/*-------------------------------------------*/
create table jar
(
    id int primary key auto_increment,
    volume decimal(10,2),
    total decimal(10,2)
);
/*-------------------------------------------*/
create procedure coin_jar_get_total_amount()
begin
    select total
    from jar;
end;
/*---------------------------------------------------------*/
create procedure coin_jar_add_coin_new(p_amount decimal(10,2), p_volume decimal(10,2))
begin
    insert into coin(amount, volume,created_date, updated_date)
    values(p_amount,p_volume, now(), null) ;
end;
/*---------------------------------------------------------*/
create procedure coin_jar_get_reset()
begin
    update jar
        set total = 0
    where id = 1 ;
end;
/*---------------------------------------------------------*/
create procedure coin_jar_update_total(p_amount decimal)
begin
    update jar
        set total = total + p_amount
    where id = 1;
end;
