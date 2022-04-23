use Master;
GO
IF EXISTS (SELECT * FROM SysDataBases WHERE NAME='Trivia')
BEGIN
	DROP DATABASE Trivia
END
GO

CREATE DATABASE Trivia 
ON
(
	NAME=Trivia,
	FILENAME='D:\Compartir\Trabajos\trivia\Trivia.mdf'
) 
GO

Use Trivia
GO

/*------------------------------------------------------------
--------------------------------------------------------------
///////////////////////// TABLAS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\
--------------------------------------------------------------
--------------------------------------------------------------*/


CREATE TABLE Administrador                
(
	documento int not null primary key,
	usuario varchar(20) not null,
	pass varchar(20) not null,
	nombre varchar(20) not null,
	genEstadisticas bit not null,
)
go

CREATE TABLE Jugador           
( 
	documento int not null primary key,
	usuario varchar(20) not null,
	pass varchar(20) not null,
	nombre varchar(20) not null,
	nombrePublico varchar(20) not null,
	activo bit not null,
)
go

CREATE TABLE Juego             
(
	numero int not null primary key identity,
	fechaHoraInicio datetime not null,
	fechaHoraFin datetime,
	cantMovimientos int,
	numeroJugador int not null,
	contestacionesOK int not null,
	activo bit not null,
	Foreign Key(numeroJugador) references Jugador(documento),
)
go  


create TABLE Juego_EstadoDePreguntas           
(
	id int primary key identity,
	numeroJuego int  not null,
	estado int not null,
	Foreign Key(numeroJuego) references Juego(numero)
)
go 

CREATE TABLE Respuesta                 
( 
	id int not null primary key identity,
	numero int not null,
	texto varchar(70),
	correcto bit
	
)
go

CREATE TABLE Pregunta                
( 
	numero int not null PRIMARY KEY Identity,
	texto varchar(200) not null,
	tipo varchar(20) not null,
	idRespuesta1 int not null,
	idRespuesta2 int not null,
	idRespuesta3 int not null,
	activo bit not null,
	Foreign Key(idRespuesta1) references Respuesta(id),
	Foreign Key(idRespuesta2) references Respuesta(id),
	Foreign Key(idRespuesta3) references Respuesta(id),
	--Foreign Key(numeroCategoria) references Categoria(numero),
)
go

CREATE TABLE Juego_Pregunta             
(
	numeroJuego int not null,
	numeroPregunta int not null,
	Primary key(numeroJuego,numeroPregunta),
	Foreign Key(numeroJuego) references Juego(numero),
	Foreign Key(numeroPregunta) references Pregunta(numero),
)
go  



/*-------------------------------------------------------------
\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////////////
----------------PROCEDIMIENTOS ALMACENADOS--------------------
/////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
-------------------------------------------------------------*/


						/*//////////////////////////
						///////// USUARIO /////////
						\\\\\\\\\\\\\\\\\\\\\\\\\\*/
						
						
/*AUTENTICACION DE USUARIO*/						
CREATE PROC Chequeo_Usuario

	@user varchar(20),
	@pass varchar(20)

as
Begin 
	if exists(select * from Jugador where usuario=@user and pass=@pass)
		return 8
	else if exists (select * from Administrador where usuario=@user and pass=@pass)
		return 9
	else
		return 1
end
go

/*CREAR USUARIO DE LOGUEO Y BASE DE DATOS*/
CREATE PROC CrearUsuarioLogueoBD

	@usuario varchar(20),
	@pass varchar(20),
	@rol varchar(20),
	@permiso varchar(20)		
	
as
BEGIN
	Declare @VarSentenciaSql varchar(200)
	Declare @VarSentenciaLogueo varchar(200)
	if not exists(select * from Administrador where usuario=@usuario and pass=@pass)
	begin
		begin transaction
			Set @VarSentenciaSql = 'Create User [' +  @usuario + '] From Login [' + @usuario + ']' -- creo el usuario de base de datos
			Exec (@VarSentenciaSql)
		
			if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end	
			
			Exec sp_addrolemember @rolename=@rol, @membername=@usuario --segundo asigno rol especificao al usuario recien creado
		
			if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end	
			
			Set @VarSentenciaLogueo = 'CREATE LOGIN [' +  @usuario + '] WITH PASSWORD = ' + QUOTENAME(@pass, '''') --primero creo el usuario de logueo
			Exec (@VarSentenciaLogueo)
		
			if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end	
		
			Exec sp_addsrvrolemember @loginame=@usuario, @rolename=@Rol  --segundo asigno rol especificao al usuario recien creado
			
			if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end	
		commit transaction
		return 1
	end			
	else
		return 2
END
go
					
						/*//////////////////////////
						///// ADMINISTRADOR //////
						\\\\\\\\\\\\\\\\\\\\\\\\\\*/

/*LOGUEO*/
CREATE PROC Logueo_Administrador

	@user varchar(20),
	@pass varchar(20)
	
as
begin 
	if exists(select * from Administrador where usuario=@user and pass=@pass)
		select * from Administrador where usuario=@user and pass=@pass
	else 
		return 1

end	
go
	
/*ALTA*/
CREATE PROC Alta_Administrador                

	@documento int,
	@user varchar(20),
	@pass varchar(20),
	@nombre varchar(20),
	@genEstadisticas bit

as
Begin
	if not exists(select * from Administrador where usuario=@user)
		if not exists (select * from Administrador where documento=@documento)
			insert into Administrador values(@documento,@user,@pass,@nombre,@genEstadisticas)
		else
			return 3
	else
		return 2 
End
go

/*BAJA*/
CREATE PROC Baja_Administrador                

	@documento int

as
Begin
	if not exists(select * from Administrador where documento=@documento)
		return 2
	else 
		delete from Administrador where documento=@documento
End
go

/*MODIFICACION*/
CREATE PROC Modificacion_Administrador                

	@documento int,
	@user varchar(20),
	@pass varchar(20),
	@nombre varchar(20),
	@genEstadisticas bit 

as 
Begin
	if not exists(select * from Administrador where documento=@documento)
		return 2
	else
 		update Administrador set usuario=@user,pass=@pass,nombre=@nombre,genEstadisticas=@genEstadisticas where documento=@documento
End
go


/*BUSCAR TODOS - LISTAR TODOS*/
CREATE PROC Listar_Administrador                
as
Begin
	select * from Administrador
End
go

/*BUSCAR UNO POR DOCUMENTO*/
CREATE PROC Buscar_Administrador                

	@documento int

as
Begin
	if not exists(select * from Administrador where documento=@documento)
		return 1
	else
		select * from Administrador where documento=@documento
End
go

						--/\\\\\\\\\\\\\\\\\\\\\
						--/////// JUGADOR ////////
						--//////////////////////


/*LOGUEO*/
CREATE PROC Logueo_Jugador

	@user varchar(20),
	@pass varchar(20)
	
as
begin
	if exists(select * from Jugador where usuario=@user and pass=@pass)
		select * from Jugador where usuario=@user and pass=@pass
	else 
		return 1

end	
go
						
/*ALTA*/
CREATE PROC Alta_Jugador             

	@documento int,
	@user varchar(20),
	@pass varchar(20),
	@nombre varchar(20),
	@nombrePublico varchar(20)

as
Begin
	if not exists(select * from Jugador where documento=@documento)
		insert into Jugador values(@documento,@user,@pass,@nombre,@nombrePublico,1)  --1=true=activado
	else
		return 2 
end
go

/*BAJA*/
CREATE PROC Baja_Jugador             

	@documento int

as
Begin
	if not exists(select * from Jugador where documento=@documento)
		return 1
	else 
		Begin
		if not exists(select * from Juego where numeroJugador=@documento)
			delete from Jugador where documento=@documento	
		else
			update Jugador set activo=0 
		end	
end
go

/*MODIFICACION*/
CREATE PROC Modificacion_Jugador             

	@documento int,
	@user varchar(20),
	@pass varchar(20),
	@nombre varchar(20),
	@genEstadisticas varchar(20)

as
Begin
	if not exists(select * from Jugador where documento=@documento)
		return 1
	else
 		update Administrador set usuario=@user,pass=@pass,nombre=@nombre,genEstadisticas=@genEstadisticas where documento=@documento
end
go

/*BUSCAR TODOS - LISTAR TODOS*/
CREATE PROC Listar_Jugador             
as
Begin
	select * from Jugador
end
go

create PROC ListarJugadoresJuegosFinalizados
as
begin
	select distinct documento,nombre,nombrePublico from  Jugador inner join Juego
	on Juego.numeroJugador=Jugador.documento
	where Juego.fechaHoraFin>Juego.fechaHoraInicio
end
go

/*BUSCAR UNO POR DOCUMENTO*/
CREATE PROC Buscar_Jugador             

	@documento int

as
Begin
	if not exists(select * from Jugador where documento=@documento)
		return 1
	else
		select * from Jugador where documento=@documento
end
go

						--/\\\\\\\\\\\\\\\\\\\\\
						--//////// JUEGO ////////
						--///////////////////////

CREATE proc GenerarNumeroAleatorio

@lower int,
@upper int

as
begin 
declare @Random int
select @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

return @Random
end
go

/*ALTA*/ 

CREATE PROC Alta_Juego 

	@fechaHInicio datetime,
	@numeroJugador int

as
Begin
	declare @Random int
	declare @Upper int
	declare @Lower int
	declare @numJuego int
	declare @contador int
	
	Begin transaction
	
		insert into Juego values(@fechaHInicio,null,0,@numeroJugador,0,1)  --0 es la cantidad de movimientos
				
				if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end	
					
		set	@Lower = 1
		set @contador=0
		select @numJuego=@@IDENTITY from Juego
		select @Upper = @@IDENTITY from Pregunta 
		
				if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end
					
		
		while (@contador<9)  
		begin	
			exec @Random=GenerarNumeroAleatorio @Lower,@Upper --Ramdom va a ser el numero de una pregunta
			if @@ERROR<>0
						begin
							rollback transaction
							return -1
						end	
			if not exists(select * from Juego_Pregunta where Juego_Pregunta.numeroJuego=@numJuego and Juego_Pregunta.numeroPregunta=@Random)
				begin
					if exists (select * from Pregunta where Pregunta.numero=@Random)
					begin
							insert into Juego_Pregunta values (@numJuego,@Random)
							SET @contador=@contador+1
								if @@ERROR<>0
								begin
									rollback transaction
									return -1
								end	
					end
				end
		end
		
		select * from Juego where numero=@numJuego
		
				if @@ERROR<>0
					begin
						rollback transaction
						return -1
					end
					
		commit transaction	

End
go 




/*BAJA*/
CREATE PROC Baja_Juego 

	@numero int,
	@numeroJugador int

as
Begin
	if not exists(select * from Juego where numero=@numero)
		return 1
	else --debe preguntar si el jugador del juego esta desactivado para desactivar el mismo
		begin
			if exists(select * from Jugador where Jugador.documento=@numeroJugador and activo=1)
				return 3 --el jugador para este juego esta activado
			else
				update Juego set activo=0 -- si el jugador de este juego esta desactivado 
										  -- desactivo el juego
		end
End
go

/*MODIFICACION*/
create PROC Guardar_Juego 

	@numero int,
	@fechaHoraInicio date,
	@fechaHoraFin date,
	@cantMovimientos int,
	@numeroJugador int,
	@contestacionesOk int,
	@estado1 int,
	@estado2 int,
	@estado3 int,
	@estado4 int,
	@estado5 int,
	@estado6 int,
	@estado7 int,
	@estado8 int,
	@estado9 int,
	@finalizado bit
	
as
Begin
	Begin transaction
		if not exists(select * from Juego where numero=@numero)
			return 1
		else
		    begin
		    if @finalizado=0 --si no se finaliza el juego, solamente lo guardamos
				update Juego set fechaHoraInicio=@fechaHoraInicio,cantMovimientos=@cantMovimientos,numeroJugador=@numeroJugador,contestacionesOK=@contestacionesOK where numero=@numero 
			else --lo guardamos pero le pondemos fecha final
				update Juego set fechaHoraInicio=@fechaHoraInicio,fechaHoraFin=@fechaHoraFin,cantMovimientos=@cantMovimientos,numeroJugador=@numeroJugador,contestacionesOK=@contestacionesOK where numero=@numero 	
			end
		delete from Juego_EstadoDePreguntas where numeroJuego=@numero
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado1)	
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado2)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado3)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado4)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado5)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado6)
		if @@ERROR<>0
			begin
			rollback transaction 
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado7)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado8)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
		insert into Juego_EstadoDePreguntas values(@numero,@estado9)
		if @@ERROR<>0
			begin
			rollback transaction
			return -1
			end
			commit transaction
			return 1
		
End
go

/*BUSCAR TODOS - LISTAR TODOS*/
CREATE PROC Listar_Juego 
as
Begin
	select * from Juego
End
go

/*BUSCAR UNO POR NUMERO*/
CREATE PROC Buscar_Juego 

	@numero int
	
as
Begin
	if not exists(select * from Juego where numero=@numero)
		return 1
	else
		select * from Juego where numero=@numero
End
go

/*LISTAR JUEGOS FINALIZADOS*/
CREATE PROC ListarJuegosFinalizados
as
Begin
	select * from Juego where fechaHoraFin > fechaHoraInicio
End
go

/*BUSCAR JUEGOS X NUMERO DE JUGADOR*/
CREATE PROC Buscar_Juegos_xJugador

	@documento int
	
as
Begin
	Select * from Juego inner join Jugador
	on Jugador.documento=Juego.numeroJugador
	where Juego.fechaHoraFin>Juego.fechaHoraInicio and Jugador.documento=@documento
End
go

CREATE PROC ComprobarDisponibilidadDeJuego

	@documento int
	
as
Begin
	if not exists (select distinct * from Juego inner join Jugador
				on Jugador.documento=Juego.numeroJugador
				where Juego.fechaHoraFin is null and Jugador.documento=@documento)
				return 1 --true
	else
		return 0 --false		
End
go

CREATE PROC Buscar_Juego_Pendiente

	@documento int
	
as
Begin
	select * from Juego where Juego.numeroJugador=@documento and Juego.fechaHoraFin is null
End
go

CREATE PROC Buscar_Estado_Juego

@numeroJuego int

as
BEGIN
	select estado from Juego_EstadoDePreguntas inner join Juego 
	on Juego.numero=Juego_EstadoDePreguntas.numeroJuego
	where numeroJuego=@numeroJuego
ENd
go


						/*/\\\\\\\\\\\\\////////////////
						//////// PREGUNTA //////////////
						////////////////\\\\\\\\\\\\\\*/



/*BAJA*/
CREATE PROC Baja_Pregunta                
 
	@numero int

as
Begin
		if not exists(select * from Juego_Pregunta where numeroPregunta=@numero) --si la pregunta no esta relacionada con un juego la borro
			delete from Pregunta where numero=@numero
		else
			begin --preguntamos si el juego esta desactivado, para desactivar la pregunta
				if not exists(select * from Juego inner join Juego_Pregunta inner join Pregunta
				on Pregunta.numero=Juego_Pregunta.numeroPregunta
				on Juego_Pregunta.numeroJuego=Juego.numero
				where Pregunta.numero=@numero and Juego.activo=0)
					return 3--no se puede desactivar la pregunta ya que el juego esta activo
				else
					update Pregunta set activo=0 where numero=@numero--si existe alguna relacion solamente la desactivamos
			end
End
go

/*MODIFICACION*/
CREATE PROC Modificacion_Pregunta                               

	@numeroPregunta int,
	@textoPregunta varchar(200),
	@tipo varchar(20),
	@numero int,
	@numero1 int,
	@numero2 int,
	@texto varchar(70),
	@texto1 varchar(70),
	@texto2 varchar(70),
	@correcto bit,
	@correcto1 bit,
	@correcto2 bit

as
	begin
	declare @idRespuesta1 int
	declare @idRespuesta2 int
	declare @idRespuesta3 int
		begin transaction 
			 update Respuesta set  texto=@texto,correcto=@correcto where id=@idRespuesta1 --modifico la primera pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end	
			update Respuesta set texto=@texto1,correcto=@correcto1 where id=@idRespuesta2 --modifico la segunda pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			update Respuesta set texto=@texto2,correcto=@correcto2 where id=@idRespuesta3 --modifico la tercera pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			update Pregunta set texto=@textoPregunta,tipo=@tipo where Pregunta.numero=@numeroPregunta--modifico la pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
		commit transaction
		return 1		
end
	
go


/*BUSCAR TODOS - LISTAR TODOS*/
CREATE PROC Listar_Pregunta 
as
Begin
	select * from Pregunta
End
go

/*BUSCAR UNA POR NUMERO*/
CREATE PROC Buscar_Pregunta 

	@numero int
	               
as
Begin
	if not exists(select * from Pregunta where numero=@numero)
		return 1
	else
		select * from Pregunta where numero=@numero
End
go

CREATE PROC Buscar_Preguntas_xnumJuego

	@numeroJuego int
	               
as
Begin 
	if not exists(select * from Pregunta inner join Juego_Pregunta 
	on Juego_Pregunta.numeroPregunta=Pregunta.numero
	where Juego_Pregunta.numeroJuego=@numeroJuego)
		return 1
	else
	  begin
		select * from Pregunta inner join Juego_Pregunta 
		on Juego_Pregunta.numeroPregunta=Pregunta.numero
		where Juego_Pregunta.numeroJuego=@numeroJuego
	  end
End
go

						/*/\\\\\\\\\\\\\////////////////
						----------- RESPUESTA -----------
						////////////////\\\\\\\\\\\\\\\\*/


/*ALTA*/
CREATE PROC Alta_Respuestas               /*DA DE ALTA UNA PREGUNTA CON SUS RESPUESTAS */  

	
	@textoPregunta varchar(200),
	@tipo varchar(20),
	@numero int,
	@numero1 int,
	@numero2 int,
	@texto varchar(70),
	@texto1 varchar(70),
	@texto2 varchar(70),
	@correcto bit,
	@correcto1 bit,
	@correcto2 bit

as
	begin
	declare @idRespuesta1 int
	declare @idRespuesta2 int
	declare @idRespuesta3 int
		begin transaction
			insert into Respuesta values (@numero,@texto,@correcto) --inserto la primera pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end	
				select @idRespuesta1=@@IDENTITY from Respuesta --guardo la ultima id ingresada de la respuesta 1
				if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end	
			insert into Respuesta values (@numero1,@texto1,@correcto1) --inserto la segunda pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			select @idRespuesta2=@@IDENTITY from Respuesta --guardo la ultima id ingresada de la respuesta 2
				if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			insert into Respuesta values (@numero2,@texto2,@correcto2) --inserto la tercera pregunta
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			select @idRespuesta3=@@IDENTITY from Respuesta --guardo la ultima id ingresada de la respuesta 3
				if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
			insert into Pregunta values (@textoPregunta,@tipo,@idRespuesta1,@idRespuesta2,@idRespuesta3,1) --inserto la pregunta con sus respuestas
			if @@ERROR<>0
				begin
					rollback transaction
					return -1
				end
		commit transaction
		return 1			
end
	
go


/*BUSCAR UNO POR NUMERO*/
CREATE PROC Buscar_Respuesta 

	@numero int

as
Begin
	select * from Respuesta where id=@numero
	
End
go



						/*/\\\\\\\\\\\\\////////////////
						//////// JUEGO_PREGUNTA ////////
						////////////////\\\\\\\\\\\\\\*/

/*ALTA*/
CREATE PROC Alta_Juego_Pregunta             

	@numeroJuego int,
	@numeroPregunta int

as
Begin
	if not exists(select * from Juego_Pregunta where numeroJuego=@numeroJuego and numeroPregunta=@numeroPregunta)
		insert into Juego_Pregunta values(@numeroJuego,@numeroPregunta)
	else
		return 2
End
go 


						--/////////////////////////////	INGRESO DE DATOS /////////////////////////////////////////


insert into Jugador values(42332432,'mumu123','123','nombre1 apellido1','eeeee',1)
insert into Jugador values(40090,'lolio','lolio','nombre1 apellido1','eeeee',1)
insert into Jugador values(12611,'nue','nue','nombre1 apellido1','eeeee',1)
insert into Administrador values(44296766,'admin','admin123','Fernando Garcia',1)
insert into Jugador values(7777,'ee','ee','nombre1 apellido1','eeeee',1)
insert into Jugador values(789789789,'e','e','nombre1 apellido1','eeeee',1)
insert into Jugador values(987987,'e','e','nombre1 apellido1','eeeee',1)
insert into Jugador values(123123,'jugador1','jugador1','nombre1 apellido1','jug1',1)
insert into Jugador values(1111111,'jugador1','jugador1','nombre1 apellido1','jug1',1)
insert into Jugador values(2222222,'jugador2','jugador2','nombre2 apellido2','jug2',1)
insert into Jugador values(3333333,'jugador3','jugador3','nombre3 apellido3','jug3',1)
insert into Jugador values(4444444,'jugador4','jugador4','nombre4 apellido4','jug4',1)
insert into Jugador values(5555555,'jugador5','jugador5','nombre5 apellido5','jug5',1)
insert into Jugador values(6666666,'jugador6','jugador6','nombre6 apellido6','jug6',1)
insert into Jugador values(8888888,'admin','admin123','Fernando Garcia','fgarcia',1)
insert into Jugador values(23232323,'suco','suco123','Fernando Garcia','fgarcia',1)

insert into Respuesta values(1,'respuesta1',1)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta1?','Deporte',1,2,3,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',1)
insert into Pregunta values('pregunta2?','Ciencia',4,5,6,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',1)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta3?','Geografia',7,8,9,1)

insert into Respuesta values(1,'respuesta1',1)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta4?','Deporte',10,11,12,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',1)
insert into Pregunta values('pregunta5?','Ciencia',13,14,15,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',1)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta6?','Geografia',16,17,18,1)


insert into Respuesta values(1,'respuesta1',1)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta7?','Deporte',19,20,21,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',0)
insert into Respuesta values(3,'respuesta3',1)
insert into Pregunta values('pregunta8?','Ciencia',22,23,24,1)

insert into Respuesta values(1,'respuesta1',0)
insert into Respuesta values(2,'respuesta2',1)
insert into Respuesta values(3,'respuesta3',0)
insert into Pregunta values('pregunta9?','Geografia',25,26,27,1)

/*
declare @o int
set @o=1
while (@o<10)
begin

exec Alta_Juego '1/2/2008',3333333
set @o=@o+1
end
GO
*/


insert into Juego values('1/1/15 15:00','1/1/15 15:05',42,1111111,0,1)
insert into Juego values('2/1/2015 16:00','2/1/2015 16:10',56,2222222,0,1)
insert into Juego values('2/1/2015 17:00','2/1/2015 17:50',22,3333333,0,1)
insert into Juego values('2/1/2015 22:00','2/1/2015 23:00',105,3333333,0,1)
insert into Juego values('2/1/2015 17:00',null,66,3333333,0,1)
insert into Juego values('2/1/2015 22:00',null,77,3333333,0,1)
insert into Juego values('2/1/2015 17:00',null,66,4444444,0,1)
insert into Juego values('2/1/2015 22:00',null,77,4444444,0,1)
insert into Juego values('5/1/2015 22:00','5/1/2015 22:15',77,3333333,0,1)

insert into Juego_Pregunta values(1,1) 
insert into Juego_Pregunta values(1,2)
insert into Juego_Pregunta values(1,3)
insert into Juego_Pregunta values(1,4)
insert into Juego_Pregunta values(1,5)
insert into Juego_Pregunta values(1,6)
insert into Juego_Pregunta values(1,7)
insert into Juego_Pregunta values(1,8)
insert into Juego_Pregunta values(1,9)

insert into Juego_Pregunta values(2,1)
insert into Juego_Pregunta values(2,2)
insert into Juego_Pregunta values(2,3)
insert into Juego_Pregunta values(2,4)
insert into Juego_Pregunta values(2,5)
insert into Juego_Pregunta values(2,6)
insert into Juego_Pregunta values(2,7)
insert into Juego_Pregunta values(2,8)
insert into Juego_Pregunta values(2,9)


insert into Juego_Pregunta values(3,9)
insert into Juego_Pregunta values(3,7)
insert into Juego_Pregunta values(3,5)
insert into Juego_Pregunta values(3,3)
insert into Juego_Pregunta values(3,1)
insert into Juego_Pregunta values(3,8)
insert into Juego_Pregunta values(3,4)
insert into Juego_Pregunta values(3,2)
insert into Juego_Pregunta values(3,6)

insert into Juego_Pregunta values(5,1)
insert into Juego_Pregunta values(5,2)
insert into Juego_Pregunta values(5,3)
insert into Juego_Pregunta values(5,4)
insert into Juego_Pregunta values(5,5)
insert into Juego_Pregunta values(5,6)
insert into Juego_Pregunta values(5,7)
insert into Juego_Pregunta values(5,8)
insert into Juego_Pregunta values(5,9)

