using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Interface
{
    public interface ILogicaRespuesta
    {
        void Alta_Respuesta(Respuesta a);
        void Baja_Respuesta(Respuesta a);
        void Modificacion_Respuesta(Respuesta a);
		Respuesta Buscar_Administrador(Respuesta a);
		List<Respuesta> Listar_Respuesta();

    }
}
