using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{

    public interface IPersistenciaPregunta
    {
        int Alta_Pregunta(Pregunta p);
        void Baja_Pregunta(Pregunta p);
        void Modificacion_Pregunta(Pregunta p);
		Pregunta Buscar_Pregunta(int num);
        List<Pregunta> Buscar_Preguntas(int numJuego); //devuelve 9 preguntas
		List<Pregunta> Listar_Pregunta();

    }
}
