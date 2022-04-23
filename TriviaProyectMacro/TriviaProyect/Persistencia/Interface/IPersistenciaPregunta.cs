using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia.Interface
{
    public interface IPersistenciaPregunta
    {
        void Alta_Pregunta(Pregunta p);
        void Baja_Pregunta(Pregunta p);
        void Modificacion_Pregunta(Pregunta p);
		Pregunta Buscar_Administrador(Pregunta p);
		List<Pregunta> Listar_Preguntaa();

    }
}
