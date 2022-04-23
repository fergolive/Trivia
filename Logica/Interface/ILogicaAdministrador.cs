using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaAdministrador
    {
        void Alta_Administrador(Administrador a);
        void Baja_Administrador(Administrador a);
        void Modificacion_Administrador(Administrador a);
		Administrador Buscar_Administrador(int documento);
		List<Administrador> Listar_Administrador();
        void CrearUsuarioLogueoBD(String usuario,String pass,String rol,String Permiso);
    }
}
