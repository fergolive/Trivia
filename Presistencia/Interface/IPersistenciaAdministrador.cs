using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaAdministrador
    {
        void Alta_Administrador(Administrador a);
        void Baja_Administrador(Administrador a);
        void Modificacion_Administrador(Administrador a);
		Administrador Buscar_Administrador(int documento);
		List<Administrador> Listar_Administrador();
        Administrador Logueo_Administrador(String user,String pass);
        void CrearUsuarioLogueoBD(String usuario, String pass, String rol, String Permiso);
    }
}
