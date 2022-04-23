
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Logica
{
	internal class LogicaAdministrador:ILogicaAdministrador
	{

			private static LogicaAdministrador miInstancia=null;
			private LogicaAdministrador(){};

			public static ILogicaAdministrador GetMiInstancia()
			{

				if(miInstancia==null)
				miInstancia=new LogicaAdministrador()

				return miInstancia;
			}

			private Persistencia.IPersistenciaAdministrador unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaAdministrador();


			public void Alta_Administrador(Administrador a)
			{

				unaPersistencia.Alta_Administrador(a);

			}

			public void Baja_Administrador(Administrador a)
			{
				
				unaPersistencia.Baja_Administrador(a)
				
			}

			public void Modificacion_Administrador(Administrador a)
			{

				unaPersistencia.Modificacion_Administrador(a)

			}

			public List<Administrador> Buscar_Administrador(Administrador a) 
			{

				return naPersistencia.Buscar_Administrador(a);

			}

			public Administrador Listar_Administrador() 
			{
				
				return unaPersistencia.Listar_Administrador()

			}

	}
}