using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia.Interface
{
    public interface IPersistenciaAdministrador
    {
        void Alta_Administrador(Administrador a);
        void Baja_Administrador(Administrador a);
        void Modificacion_Administrador(Administrador a);
		Administrador Buscar_Administrador(Administrador a);
		List<Administrador> Listar_Administrador();

    }
}
