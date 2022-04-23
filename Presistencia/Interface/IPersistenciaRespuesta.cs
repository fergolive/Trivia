using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaRespuesta
    {
        void Alta_Respuestas(Pregunta pregunta);
        void Baja_Respuesta(Respuesta a);
        void Modificacion_Respuesta(Respuesta a);
		Respuesta Buscar_Respuesta(int numRespuesta);
		List<Respuesta> Listar_Respuesta();

    }
}
