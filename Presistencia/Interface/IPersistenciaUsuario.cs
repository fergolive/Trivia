using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaUsuario
    {
        Usuario Logueo_Usuario(String user,String pass);
        int Chequeo_Usuario(String user, String pass);
    }
}
